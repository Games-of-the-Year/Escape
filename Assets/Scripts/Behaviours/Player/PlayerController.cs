using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Globalization;

public class PlayerController : MonoBehaviour
{
    // Player ID
    private int playerID;

    [Header("Sub Behaviours")]
    public PlayerMovementBehaviour movementBehaviour;
    public PlayerAnimationBehaviour animationBehaviour;
    public CameraRotaionBehaviour cameraRotaionBehaviour;

    [Header("Input Settings")]
    public PlayerInput playerInput;
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    public Vector3 smoothInputMovement;
    private Vector3 cameraRotation;

    private string actionMapPlayer = "Player";
    private string actionMapUI = "UI";

    //Current Control Scheme
    private string currentControlScheme;

    // camera
    [SerializeField] Camera childCamera;


    // ゲームのセットアップ時にGameManagerから呼び出される
    public void SetupPlayer(int playerID)
    {
        this.playerID = playerID;

        currentControlScheme = playerInput.currentControlScheme;

        movementBehaviour.SetupBehaviour();
        animationBehaviour.SetupBehaviour();
    }


    // Input System

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnCameraRotate(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        cameraRotation = new Vector3(inputMovement.y, inputMovement.x, 0);
    }

    //public void OnTogglePause(InputAction.CallbackContext value)
    //{
    //    if (value.started)
    //    {
    //        GameManager.Instance.TogglePauseState(this);
    //    }
    //}


    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdateCameraRotation();
        UpdatePlayerMovement();
        UpdatePlayerAnimationMovement();
    }

    private void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
    }

    private void UpdateCameraRotation()
    {
        cameraRotaionBehaviour.UpdateRotaion(cameraRotation);
    }

    private void UpdatePlayerMovement()
    {
        movementBehaviour.UpdateMovementData(smoothInputMovement);
    }

    void UpdatePlayerAnimationMovement()
    {
        animationBehaviour.UpdateMovementAnimation(smoothInputMovement.magnitude);
    }

    public void SetInputActiveState(bool gameIsPaused)
    {
        switch (gameIsPaused)
        {
            case true:
                playerInput.SwitchCurrentActionMap(actionMapPlayer);
                break;
            case false:
                playerInput.SwitchCurrentActionMap(actionMapUI);
                break;
        }
    }

    public void EnableGameplayControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapPlayer);
    }

    public void EnablePauseMenuControls()
    {
        playerInput.SwitchCurrentActionMap(actionMapUI);
    }

}

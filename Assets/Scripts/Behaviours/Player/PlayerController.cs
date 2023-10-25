using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Player ID
    private int playerID;

    [Header("Sub Behaviours")]
    public PlayerMovementBehaviour movementBehaviour;
    public 

    [Header("Input Settings")]
    public PlayerInput playerInput;
    public float movementSmoothingSpeed = 10f;
    private Vector3 rawInputMovement;
    public Vector3 smoothInputMovement;
    //private Rigidbody rb;

    private string actionMapPlayer = "Player";
    private string actionMapUI = "UI";

    //Current Control Scheme
    private string currentControlScheme;

    private bool isMoving;


    // ゲームのセットアップ時にGameManagerから呼び出される
    public void SetupPlayer(int playerID)
    {
        this.playerID = playerID;

        currentControlScheme = playerInput.currentControlScheme;

        PlayerMovementBehaviour.SetupBehaviour();

    }


    // Input System

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void OnJumping(InputAction.CallbackContext value)
    {
        if (value.started)
        {
        }
    }

    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
    }


    private void CalculateMovementInputSmoothing()
    {
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, movement, Time.deltaTime * speed);
    }

    private void UpdatePlayerMovement()
    {
        //movementBehaviour
    }
}

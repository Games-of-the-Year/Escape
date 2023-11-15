using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody playerRigidbody;

    [Header("Movement Settings")]
    public float movementSpeed = 3f;
    public float turnSpeed = 0.1f;

    public Camera playerCam;
    public Camera UICam;
    private Vector3 movementDirection;

    private Quaternion targetRotation;

    private void Awake()
    {
        targetRotation = transform.rotation;
    }

    public void SetupBehaviour()
    {
        SetGameplayCamera();
    }

    void SetGameplayCamera()
    {
        playerCam.enabled = true;
        UICam.enabled = false;
    }

    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    private void FixedUpdate()
    {
        MoveThePlayer();
        TurnThePlayer();
    }

    private void MoveThePlayer()
    {
        Vector3 movement = CameraDirection(movementDirection) * movementSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    private void TurnThePlayer()
    {
        if (movementDirection.magnitude > 0.01f)
        {
            targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        //if (movementDirection.sqrMagnitude > 0.01f)
        //{

        //    Quaternion rotation = Quaternion.Slerp(playerRigidbody.rotation,
        //                                         Quaternion.LookRotation(CameraDirection(movementDirection)),
        //                                         turnSpeed);

        //    playerRigidbody.MoveRotation(rotation);

        //}
    }

    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = playerCam.transform.forward;
        var cameraRight = playerCam.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        return cameraForward * movementDirection.z + cameraRight * movementDirection.x;

    }

}

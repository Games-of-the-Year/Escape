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

    private Rigidbody rb;
    private PlayerInput playerInput;

    private Vector3 movement;
    private bool isMoving;

    [SerializeField] private float speed = 10f;

    //Current Control Scheme
    private string currentControlScheme;

    public void SetupPlayer(int playerID)
    {
        this.playerID = playerID;

        currentControlScheme = playerInput.currentControlScheme;

    }

    private void Awake()
    {
        TryGetComponent(out rb);
        TryGetComponent(out playerInput);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        movement = new Vector3(value.x, 0, value.y);
    }

    void FixedUpdate()
    {
        if (movement == Vector3.zero)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            rb.AddForce(movement * speed);
        }
    }
}

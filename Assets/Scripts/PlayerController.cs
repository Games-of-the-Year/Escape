using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput input;

    private Vector3 movement;
    private bool isMoving;

    [SerializeField] private float speed = 10f;

    private void Awake()
    {
        TryGetComponent(out rb);
        TryGetComponent(out input);
    }

    private void OnEnable()
    {
        input.actions["Move"].performed += OnMove;
        input.actions["Move"].canceled += OnMoveStop;
    }

    private void OnDisable()
    {
        input.actions["Move"].performed -= OnMove;
        input.actions["Move"].canceled -= OnMoveStop;
    }

    private void OnMoveStop(InputAction.CallbackContext context)
    {
        // ボタンを離した時に呼ばれて、移動を止める
        movement = Vector3.zero;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        Debug.Log(value);
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

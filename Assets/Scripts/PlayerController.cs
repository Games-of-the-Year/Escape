using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;    // X方向に移動する量
    private float movementZ;    // Z方向に移動する量
    private float movementSpeed;// 移動速度
    private Vector3 movement;   // 移動量

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        movementSpeed = 10f;
    }

    void FixedUpdate()
    {
        movement.Normalize();   // 移動量の正規化

        rb.AddForce(movement * movementSpeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();

        movementX = move.x;
        movementZ = move.y;

        movement = new Vector3(movementX, 0, movementZ);
    }
}

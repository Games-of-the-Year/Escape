using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Vector3 movementDirection;

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
        Vector3 movement;
    }

    private void TurnThePlayer()
    {
        throw new NotImplementedException();
    }
}

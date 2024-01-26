using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomManager2 : MonoBehaviour
{
    public GameObject USBMemory;

    private void OnTriggerEnter(Collider other)
    {
        USBMemory.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager2 : MonoBehaviour
{
    public GameObject USBMemory;
    GameManager gameManager;
    int roomNum;

    private void Start()
    {
        GameObject manager = GameObject.Find("Manager/GameManager");
        if (manager != null)
        {
            gameManager = manager.GetComponent<GameManager>();
        }
        else
        {
            Debug.Log("GameManager is null");
        }

        roomNum = SceneManager.GetActiveScene().buildIndex - 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        USBMemory.SetActive(false);
        gameManager.isEnteringRoom[roomNum] = false;
        gameManager.isExitingRoom = true;
        gameManager.clearedRoomNum++;
    }
}

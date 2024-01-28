using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager2 : MonoBehaviour
{
    public GameObject USBMemory;
    public GameObject timer;

    GameManager gameManager;
    int roomNum;
    AudioSource audioSource;
    Timer timerScript;

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

        audioSource = GetComponent<AudioSource>();

        roomNum = SceneManager.GetActiveScene().buildIndex - 2;

        timerScript = timer.GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (USBMemory.activeSelf == true)
        {
            audioSource.Play();
            timerScript.isTimerRunning = false;
            gameManager.isEnteringRoom[roomNum] = false;
            gameManager.isExitingRoom = true;
            gameManager.clearedRoomNum++;
        }
        USBMemory.SetActive(false);
    }
}

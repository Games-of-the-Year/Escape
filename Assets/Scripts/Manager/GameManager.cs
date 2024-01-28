using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    // Local Multiplayer
    public GameObject player;

    // Spawned Players
    private List<PlayerController> activePlayerControllers;
    //private bool isPaused;
    private PlayerController focusedPlayerController;

    public bool[] isEnteringRoom = new bool[4];
    public bool isExitingRoom = false;
    public int clearedRoomNum = 0;
    public bool isClear = false;

    void Start()
    {
        //isPaused = false;

        SetupBasedOnGameState();
        //SetupUI();

        for (int i = 0; i < 4; i++)
        {
            isEnteringRoom[i] = true;
        }
    }


    private void Update()
    {
        // 謎を解いた数が
        if (clearedRoomNum == 4)
        {
            isClear = true;
        }
    }

    private void SetupBasedOnGameState()
    {
        activePlayerControllers = new List<PlayerController>();

        if (player == true)
        {
            AddPlayerToActivePlayerList(player.GetComponent<PlayerController>());
        }

        SetupActivePlayers();
        SetupSinglePlayerCamera();
    }

    private void AddPlayerToActivePlayerList(PlayerController newPlayer)
    {
        activePlayerControllers.Add(newPlayer);
    }

    private void SetupActivePlayers()
    {
        for (int i = 0; i < activePlayerControllers.Count; i++)
        {
            activePlayerControllers[i].SetupPlayer(i);
        }
    }

    void SetupUI()
    {
        UIManager.Instance.SetupManager();
    }

    private void SetupSinglePlayerCamera()
    {
        CameraManager.Instance.SetupSinglePlayerCamera();
    }
}

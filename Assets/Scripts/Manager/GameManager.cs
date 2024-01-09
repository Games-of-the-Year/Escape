using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    // Local Multiplayer
    public GameObject player;

    // Spawned Players
    private List<PlayerController> activePlayerControllers;
    //private bool isPaused;
    private PlayerController focusedPlayerController;

    void Start()
    {
        //isPaused = false;

        SetupBasedOnGameState();
        //SetupUI();
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

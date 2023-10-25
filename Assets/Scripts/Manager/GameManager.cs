using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    // Local Multiplayer
    public GameObject[] playerPrefab = new GameObject[2];
    public int numberOfPlayers = 2;

    public Transform spawnRingCenter;
    public float spawnRingRadius;

    // Spawned Players
    private List<PlayerController> activePlayerControllers;
    private bool isPaused;
    private PlayerController focusedPlayerController;

    void Start()
    {
        isPaused = false;

        SetupBasedOnGameState();
        SetupUI();
    }

    private void SetupBasedOnGameState()
    {
        SpawnPlayers();

        SetupActivePlayers();
    }

    private void SpawnPlayers()
    {
        activePlayerControllers = new List<PlayerController>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Vector3 spawnPosition = CalculatePositionInRing(i, numberOfPlayers);
            Quaternion spawnRotation = CalculateRotation();

            GameObject spawnedPlayer = Instantiate(playerPrefab[i], spawnPosition, spawnRotation) as GameObject;
            AddPlayerToActivePlayerList(spawnedPlayer.GetComponent<PlayerController>());
        }
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

    private void SetupUI()
    {
    }

    public void TogglePauseState(PlayerController newFocusedPlayerController)
    {
    }


    // Spawn Utilities

    Vector3 CalculatePositionInRing(int positionID, int numberOfPlayers)
    {
        Assert.IsTrue(numberOfPlayers == 2);

        float angle = (positionID) * Mathf.PI * 2 / numberOfPlayers;
        float x = Mathf.Cos(angle) * spawnRingRadius;
        float z = Mathf.Sin(angle) * spawnRingRadius;
        return spawnRingCenter.position + new Vector3(x, 0, z);
    }

    Quaternion CalculateRotation()
    {
        return Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
    }
}
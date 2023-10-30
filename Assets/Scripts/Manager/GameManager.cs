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



    //public void TogglePauseState(PlayerController newFocusedPlayerController)
    //{
    //    focusedPlayerController = newFocusedPlayerController;

    //    isPaused = !isPaused;

    //    ToggleTimeScale();

    //    UpdateActivePlayerInputs();

    //    SwitchFocusedPlayerControlScheme();

    //    UpdateUIMenu();

    //}

    //void UpdateActivePlayerInputs()
    //{
    //    for (int i = 0; i < activePlayerControllers.Count; i++)
    //    {
    //        if (activePlayerControllers[i] != focusedPlayerController)
    //        {
    //            activePlayerControllers[i].SetInputActiveState(isPaused);
    //        }

    //    }
    //}

    //void SwitchFocusedPlayerControlScheme()
    //{
    //    switch (isPaused)
    //    {
    //        case true:
    //            focusedPlayerController.EnablePauseMenuControls();
    //            break;

    //        case false:
    //            focusedPlayerController.EnableGameplayControls();
    //            break;
    //    }
    //}

    //void UpdateUIMenu()
    //{
        //UIManager.Instance.UpdateUIMenuState(isPaused);
    //}

    //void ToggleTimeScale()
    //{
    //    float newTimeScale = 0f;

    //    switch (isPaused)
    //    {
    //        case true:
    //            newTimeScale = 0f;
    //            break;

    //        case false:
    //            newTimeScale = 1f;
    //            break;
    //    }

    //    Time.timeScale = newTimeScale;
    //}



    // Spawn Utilities

    Vector3 CalculatePositionInRing(int positionID, int numberOfPlayers)
    {
        Assert.IsTrue(numberOfPlayers == 2);

        float angle = (positionID) * Mathf.PI * 2 / numberOfPlayers;
        float x = Mathf.Cos(angle) * spawnRingRadius;
        float z = Mathf.Sin(angle) * spawnRingRadius;
        return spawnRingCenter.position + new Vector3(x, 1.35f, z);
    }

    Quaternion CalculateRotation()
    {
        return Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
    }
}

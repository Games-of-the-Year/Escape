using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEditor.ShaderKeywordFilter;
using Unity.VisualScripting;
using Unity.Burst.Intrinsics;
using System;

public class PlayerCameraLayerUpdater : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [Serializable]
    public struct PlayerLayer
    {
        public int index;
        public int layer;
    }

    [SerializeField] private PlayerLayer[] playerLayers;

    private int currentLayerIndex = -1;

    private void Awake()
    {
        if (input == null)
        {
            return;
        }

        OnIndexUpdated(input.user.index);
    }

    private void OnEnable()
    {
        if (PlayerInputManager.instance == null)
        {
            return;
        }

        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        if (PlayerInputManager.instance == null)
        {

            return;
        }

        PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        if (playerInput.user.index >= input.user.index)
        {
            return;
        }

        OnIndexUpdated(input.user.index - 1);
    }

    private void OnIndexUpdated(int index)
    {
        if (currentLayerIndex == index)
        {
            return;
        }

        var layerIndex = Array.FindIndex(playerLayers, x => x.index == index);
        if (layerIndex < 0)
        {
            return;
        }

        var playerCamera = input.camera;
        if (playerCamera == null)
        {
            return;
        }

        for (var i = 0; i < playerLayers.Length; i++)
        {
            var layer = 1 << playerLayers[i].layer;
            if (i == index)
            {
                playerCamera.cullingMask |= layer;
            }
            else
            {
                playerCamera.cullingMask &= ~layer;
            }
        }

        virtualCamera.gameObject.layer = playerLayers[layerIndex].layer;

        currentLayerIndex = index;
    }
}

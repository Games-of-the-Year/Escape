using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [Header("Component References")]
    public GameObject gameplayCameraObject;
    //public GameObject uiOverlayCameraObject;

    //[Header("Virtual Cameras")]
    //public GameObject VCamStationaryObject;
    //public GameObject VCamSinglePlayerOrbitObject;

    public void SetupManager()
    {
        SetCameraObjectNewState(gameplayCameraObject, true);
        //SetCameraObjectNewState(uiOverlayCameraObject, false);
    }

    void SetCameraObjectNewState(GameObject cameraObject, bool newState)
    {
        cameraObject.SetActive(newState);
    }


    public Camera GetGameplayCamera()
    {
        return gameplayCameraObject.GetComponent<Camera>();
    }

}

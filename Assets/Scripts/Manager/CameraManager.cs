using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [Header("Component References")]
    public GameObject gameplayCameraObject;
    public GameObject uiOverlayCameraObject;

    [Header("Virtual Camera")]
    public GameObject VCamSinglePlayerOrbitObject;

    public void SetupManager()
    {
        SetCameraObjectNewState(gameplayCameraObject, true);
        SetCameraObjectNewState(uiOverlayCameraObject, false);
    }

    public void SetupSinglePlayerCamera()
    {
        SetCameraObjectNewState(VCamSinglePlayerOrbitObject, true);
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

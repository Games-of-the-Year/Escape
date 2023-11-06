using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CameraRotaionBehaviour : MonoBehaviour
{
    private Vector3 primaryAngle;
    private Vector3 angle;

    private float rotateSpeed = 1f;

    // 最小最大の回転角度
    private float minXRotation = -50f;
    private float maxXRotation = 50f;
    private float minYRotation = -50f;
    private float maxYRotation = 50f;

    private void Start()
    {

        // カメラの初期角度を設定
        primaryAngle = Vector3.zero;

        // カメラの現在角度を初期角度に設定
        angle = primaryAngle;
        gameObject.transform.localEulerAngles = angle;

    }


    public void UpdateRotaion(Vector3 cameraRotation)
    {
        angle.x -= cameraRotation.x * rotateSpeed;
        angle.y += cameraRotation.y * rotateSpeed;

        // X軸の回転角度を制限
        if (angle.x <= primaryAngle.x + minXRotation)
        {
            angle.x = primaryAngle.x + minXRotation;
        }

        if (angle.x >= primaryAngle.x + maxXRotation)
        {
            angle.x = primaryAngle.x + maxXRotation;
        }

        // Y軸の回転角度を制限
        if (angle.y <= primaryAngle.y + minYRotation)
        {
            angle.y = primaryAngle.y + minYRotation;
        }

        if (angle.y >= primaryAngle.y + maxYRotation)
        {
            angle.y = primaryAngle.y + maxYRotation;
        }

        // カメラの角度を設定
        gameObject.transform.localEulerAngles = angle;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float countdownDuration = 180f;
    public bool isTimerRunning = false;
    public TMP_Text timerText;

    GameObject cameras;
    GameObject manager;
    GameObject nagito;
    private float currentTime = 0f;

    private void Start()
    {
        timerText.text = FormatTime(countdownDuration);
        isTimerRunning = true;
        cameras = GameObject.Find("Cameras");
        manager = GameObject.Find("Manager");
        nagito = GameObject.Find("Nagito2");
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;
            float remainingTime = Mathf.Max(0f, countdownDuration - currentTime);
            timerText.text = FormatTime(remainingTime);
            if (currentTime >= countdownDuration)
            {
                isTimerRunning = false;
                SceneManager.LoadScene("GameOver");
                Destroy(nagito);
                Destroy(cameras);
                Destroy(manager);
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

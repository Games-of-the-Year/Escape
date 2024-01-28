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

    private float currentTime = 0f;

    private void Start()
    {
        timerText.text = FormatTime(countdownDuration);
        isTimerRunning = true;
    }

    void Update()
    {
        Debug.Log(isTimerRunning);
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;
            float remainingTime = Mathf.Max(0f, countdownDuration - currentTime);
            timerText.text = FormatTime(remainingTime);
            Debug.Log(remainingTime);
            if (currentTime >= countdownDuration)
            {
                isTimerRunning = false;
                SceneManager.LoadScene("GameOver");
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

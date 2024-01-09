using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.LookDev;

public class RoomManager : MonoBehaviour
{
    public GameObject canvas;
    public TMP_InputField inputField;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }

    public void OnClick()
    {
        canvas.SetActive(false);
    }

    public void OnEndInput(string ans)
    {
        if (inputField == null)
        {
            Debug.Log("InputField is null");
        }
        string input = inputField.text;
        if (input == ans)
        {
            Debug.Log("Correct");
        }
    }
}

using UnityEngine;
using TMPro;

public class RoomManager : MonoBehaviour
{
    public GameObject canvas;
    public TMP_InputField inputField;
    public bool isCorrect = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isCorrect)
        {
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvas.SetActive(false);
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
            isCorrect = true;
            canvas.SetActive(false);
        }
    }
}

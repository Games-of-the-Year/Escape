using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class RoomManager : MonoBehaviour
{
    public GameObject canvas;
    public TMP_InputField inputField;

    GameManager gameManager;

    private void Start()
    {
        GameObject manager = GameObject.Find("Manager/GameManager");
        if (manager != null)
        {
            gameManager = manager.GetComponent<GameManager>();
        }
        else
        {
            Debug.Log("GameManager is null");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !gameManager.isEnteringRoom)
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
            gameManager.isEnteringRoom = true;
            canvas.SetActive(false);
        }
    }
}

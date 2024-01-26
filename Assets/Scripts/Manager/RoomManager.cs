using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public GameObject canvas;
    public TMP_InputField inputField;

    int roomNum;
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

        roomNum = SceneManager.GetActiveScene().buildIndex - 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !gameManager.isExitingRoom)
        {
            canvas.SetActive(true);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        canvas.SetActive(false);
    //    }
    //}

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
            gameManager.isEnteringRoom[roomNum] = false;
            gameManager.isExitingRoom = true;
            gameManager.clearedRoomNum++;
            canvas.SetActive(false);
        }
    }
}

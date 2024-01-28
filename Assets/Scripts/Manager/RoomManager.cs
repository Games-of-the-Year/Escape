using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public GameObject canvas;
    public TMP_InputField inputField;
    public GameObject timer;

    int roomNum;
    GameManager gameManager;
    AudioSource audioSource;
    Timer timerScript;

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

        audioSource = GetComponent<AudioSource>();

        roomNum = SceneManager.GetActiveScene().buildIndex - 2;

        timerScript = timer.GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !gameManager.isExitingRoom)
        {
            canvas.SetActive(true);
        }
    }

    /// <summary>
    /// ボタンクリックで入力フィールドを閉じる
    /// </summary>
    public void OnClick()
    {
        canvas.SetActive(false);
    }

    /// <summary>
    /// 入力フィールドの入力が終了したときに呼び出される
    /// </summary>
    /// <param name="ans">正しい答え</param>
    public void OnEndInput(string ans)
    {
        if (inputField == null)
        {
            Debug.Log("InputField is null");
        }
        string input = inputField.text;
        if (input == ans)
        {
            audioSource.Play();
            // この部屋に入れなくする
            gameManager.isEnteringRoom[roomNum] = false;
            // この部屋から出られるようにする
            gameManager.isExitingRoom = true;
            gameManager.clearedRoomNum++;
            timerScript.isTimerRunning = false;
            canvas.SetActive(false);
        }
    }
}

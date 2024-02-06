using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    int hallway = 1, classRoom = 2, musicRoom = 3, ComputerRoom = 4, Library = 5;

    GameManager gameManager;
    GameObject audio;
    GameObject nagito;
    GameObject cameras;


    private void Start()
    {
        audio = GameObject.Find("Audio");
        GameObject manager = GameObject.Find("Manager/GameManager");
        if (manager != null)
        {
            gameManager = manager.GetComponent<GameManager>();
            if (gameManager == null)
            {
                Debug.Log("GameManager is null");
            }
        }
        cameras = GameObject.Find("Cameras");
        nagito = GameObject.Find("Nagito2");
        audio = GameObject.Find("Audio");

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ClassroomFront" && gameManager.isEnteringRoom[0])
        {
            SceneManager.LoadScene(classRoom);
            transform.position = new Vector3(-9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "ClassroomBack" && gameManager.isEnteringRoom[0])
        {
            SceneManager.LoadScene(classRoom);
            transform.position = new Vector3(9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "MusicroomFront" && gameManager.isEnteringRoom[1])
        {
            SceneManager.LoadScene(musicRoom);
            transform.position = new Vector3(-9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "MusicroomBack" && gameManager.isEnteringRoom[1])
        {
            SceneManager.LoadScene(musicRoom);
            transform.position = new Vector3(9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "ComputerroomFront" && gameManager.isEnteringRoom[2])
        {
            SceneManager.LoadScene(ComputerRoom);
            transform.position = new Vector3(-9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "ComputerroomBack" && gameManager.isEnteringRoom[2])
        {
            SceneManager.LoadScene(ComputerRoom);
            transform.position = new Vector3(9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "Library" && gameManager.isEnteringRoom[3])
        {
            SceneManager.LoadScene(Library);
            transform.position = new Vector3(-7f, 0, 8f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "Toilet")
        {
            SceneManager.LoadScene("Toilet");
            transform.position = new Vector3(9f, 0f, -3f);
        }
        else if (other.gameObject.name == "Clear" && gameManager.isClear)
        {
            Destroy(audio);
            Destroy(nagito);
            Destroy(cameras);
            SceneManager.LoadScene("Live2DEND");
        }
        else if (SceneManager.GetActiveScene().name == "Classroom")
        {
            if (gameManager.isExitingRoom)
            {
                if (other.gameObject.name == "Back")
                {
                    SceneManager.LoadScene(hallway);
                    transform.position = new Vector3(9.5f, 0, -12f);
                }
                else if (other.gameObject.name == "Front")
                {
                    SceneManager.LoadScene(hallway);
                    transform.position = new Vector3(-20f, 0, -12f);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Musicroom")
        {
            if (gameManager.isExitingRoom)
            {
                if (other.gameObject.name == "Back")
                {
                    SceneManager.LoadScene(hallway);
                    transform.position = new Vector3(8f, 0, 15f);
                }
                else if (other.gameObject.name == "Front")
                {
                    SceneManager.LoadScene(hallway);
                    transform.position = new Vector3(-20f, 0, -12f);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Computerroom")
        {
            if (gameManager.isExitingRoom)
            {
                if (other.gameObject.name == "Back")
                {
                    SceneManager.LoadScene(hallway);
                    transform.position = new Vector3(8f, 0, 15f);
                }
                else if (other.gameObject.name == "Front")
                {
                    SceneManager.LoadScene(hallway);
                    transform.position = new Vector3(-20f, 0, -12f);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Dictionaryroom")
        {
            if (gameManager.isExitingRoom)
            {
                if (other.gameObject.name == "Exit")
                {
                    SceneManager.LoadScene(hallway);
                    transform.position = new Vector3(-122f, 0, 4f);
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Toilet")
        {
            if (other.gameObject.name == "Exit")
            {
                SceneManager.LoadScene(hallway);
                transform.position = new Vector3(-119f, 0f, -5.8f);
            }
        }
    }
}

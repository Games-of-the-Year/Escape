using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    int hallway = 1, classRoom = 2, musicRoom = 3, ComputerRoom = 4;

    GameManager gameManager;

    private void Start()
    {
        GameObject manager = GameObject.Find("Manager/GameManager");
        if (manager != null)
        {
            gameManager = manager.GetComponent<GameManager>();
        }
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
        else if (other.gameObject.name == "MusicroomFront")
        {
            SceneManager.LoadScene(musicRoom);
            transform.position = new Vector3(-9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "MusicroomBack")
        {
            SceneManager.LoadScene(musicRoom);
            transform.position = new Vector3(9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "ComputerroomFront")
        {
            SceneManager.LoadScene(ComputerRoom);
            transform.position = new Vector3(-9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
        }
        else if (other.gameObject.name == "ComputerroomBack")
        {
            SceneManager.LoadScene(ComputerRoom);
            transform.position = new Vector3(9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            gameManager.isExitingRoom = false;
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
    }
}

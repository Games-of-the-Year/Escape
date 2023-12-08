using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //[SerializeField] private int sceneToChangeTo = 1;
    //[SerializeField] private Vector3 spawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");

        if (other.gameObject.name == "ClassroomFront")
        {
            SceneManager.LoadScene(2);
            transform.position = new Vector3(-9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (other.gameObject.name == "ClassroomBack")
        {
            SceneManager.LoadScene(2);
            transform.position = new Vector3(9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (other.gameObject.name == "MusicroomFront")
        {
            SceneManager.LoadScene(3);
            transform.position = new Vector3(-9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (other.gameObject.name == "MusicroomBack")
        {
            SceneManager.LoadScene(3);
            transform.position = new Vector3(9.5f, 0, 11f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (SceneManager.GetActiveScene().name == "Classroom")
        {
            if (other.gameObject.name == "Back")
            {
                SceneManager.LoadScene(1);
                transform.position = new Vector3(9.5f, 0, -12f);
            }
            else if (other.gameObject.name == "Front")
            {
                SceneManager.LoadScene(1);
                transform.position = new Vector3(-20f, 0, -12f);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Musicroom")
        {
            if (other.gameObject.name == "Back")
            {
                SceneManager.LoadScene(1);
                transform.position = new Vector3(8f, 0, 15f);
            }
            else if (other.gameObject.name == "Front")
            {
                SceneManager.LoadScene(1);
                transform.position = new Vector3(-20f, 0, -12f);
            }
        }
    }
}

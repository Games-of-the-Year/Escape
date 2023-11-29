using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private int sceneToChangeTo = 0;
    [SerializeField] private Vector3 spawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneToChangeTo);

        GameObject nagito = GameObject.Find("Nagito2(Clone)");
        if (nagito != null)
        {
            nagito.transform.position = spawnPoint;
        }
        else
        {
            return;
        }
    }
}

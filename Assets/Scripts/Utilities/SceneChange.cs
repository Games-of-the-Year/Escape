using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private int sceneToChangeTo = 0;
    [SerializeField] Vector3 spawnPoint = new Vector3(0, 0, 0);

    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneToChangeTo);

        GameObject nagito = GameObject.Find("Nagito2(Clone)");
        if (nagito != null)
        {
            nagito.transform.position = spawnPoint;
        }
    }
}

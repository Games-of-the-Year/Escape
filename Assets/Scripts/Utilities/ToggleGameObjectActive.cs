using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleGameObjectActive : MonoBehaviour
{
    [SerializeField] GameObject QCanvas;
    GameObject nagito;

    void Start()
    {
        nagito = GameObject.Find("Nagito2");
    }

    private void Update()
    {
        if (QCanvas.activeSelf)
        {
            nagito.SetActive(false);
        }
        else if (nagito.activeSelf == false)
        {
            nagito.SetActive(true);
        }
    }
}

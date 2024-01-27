using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HintAppear : MonoBehaviour
{
    public GameObject panel;

    public void OnClick()
    {
        panel.SetActive(!panel.activeSelf);
    }
}

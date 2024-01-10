using UnityEngine;

public class DontDestroyCamera : MonoBehaviour
{
    private static DontDestroyCamera instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

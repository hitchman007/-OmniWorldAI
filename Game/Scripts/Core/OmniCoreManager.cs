using UnityEngine;

public class OmniCoreManager : MonoBehaviour
{
    public static OmniCoreManager Instance;

    public string version = "Alpha 1.0";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log(
            "OmniWorld AI iniciado " + version
        );
    }
}
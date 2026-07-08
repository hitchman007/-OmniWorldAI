using UnityEngine;

public class OmniNetworkManager : MonoBehaviour
{
    public static OmniNetworkManager Instance;

    private bool connected;

    private void Awake()
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

    public void Connect()
    {
        connected = true;

        Debug.Log(
            "Network connected"
        );
    }

    public void Disconnect()
    {
        connected = false;

        Debug.Log(
            "Network disconnected"
        );
    }

    public bool IsConnected()
    {
        return connected;
    }
}
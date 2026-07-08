using UnityEngine;

public class OmniMultiplayerWorldSystem : MonoBehaviour
{
    public static OmniMultiplayerWorldSystem Instance;

    private int connectedPlayers;

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

    public void PlayerConnected()
    {
        connectedPlayers++;

        Debug.Log(
            "Player connected. Total: "
            + connectedPlayers
        );
    }

    public void PlayerDisconnected()
    {
        connectedPlayers--;

        Debug.Log(
            "Player disconnected. Total: "
            + connectedPlayers
        );
    }

    public int GetPlayers()
    {
        return connectedPlayers;
    }
}
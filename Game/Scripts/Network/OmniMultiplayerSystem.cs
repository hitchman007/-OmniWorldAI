using UnityEngine;

public class OmniMultiplayerSystem : MonoBehaviour
{
    public int playersConnected;

    public void ConnectPlayer(string playerID)
    {
        playersConnected++;

        Debug.Log(
        "Jugador conectado: " + playerID
        );
    }

    public void DisconnectPlayer()
    {
        playersConnected--;

        Debug.Log(
        "Jugador desconectado"
        );
    }
}
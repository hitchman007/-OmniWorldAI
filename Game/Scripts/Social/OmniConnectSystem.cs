using UnityEngine;

public class OmniConnectSystem : MonoBehaviour
{
    public bool connected;

    public void ConnectPlayer(string playerID)
    {
        connected = true;

        Debug.Log(
        "Jugador conectado: " + playerID
        );
    }

    public void SendMessage(string message)
    {
        Debug.Log(
        "Mensaje: " + message
        );
    }

    public void Disconnect()
    {
        connected = false;

        Debug.Log(
        "Jugador desconectado"
        );
    }
}
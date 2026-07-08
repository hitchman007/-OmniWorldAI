using UnityEngine;

public class OmniChatSystem : MonoBehaviour
{
    public void SendMessage(string message)
    {
        Debug.Log(
        "Mensaje enviado: " + message
        );
    }

    public void ReceiveMessage(string message)
    {
        Debug.Log(
        "Mensaje recibido: " + message
        );
    }
}
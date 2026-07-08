using UnityEngine;

public class OmniNotificationSystem : MonoBehaviour
{
    public void ShowNotification(string message)
    {
        Debug.Log(
        "Notificación: " + message
        );
    }

    public void ShowEvent(string eventName)
    {
        Debug.Log(
        "Evento: " + eventName
        );
    }
}
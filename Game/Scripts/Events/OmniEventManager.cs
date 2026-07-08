using UnityEngine;

public class OmniEventManager : MonoBehaviour
{
    public string currentEvent;

    public void StartEvent(string eventName)
    {
        currentEvent = eventName;

        Debug.Log(
        "Evento iniciado: " + currentEvent
        );
    }

    public void EndEvent()
    {
        Debug.Log(
        "Evento finalizado: " + currentEvent
        );

        currentEvent = "";
    }
}
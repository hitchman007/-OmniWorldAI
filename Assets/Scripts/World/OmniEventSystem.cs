using UnityEngine;

public class OmniEventSystem : MonoBehaviour
{
    public static OmniEventSystem Instance;

    private string currentEvent;

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

    public void StartEvent(string eventName)
    {
        currentEvent = eventName;

        Debug.Log(
            "Event started: " + eventName
        );
    }

    public void EndEvent()
    {
        Debug.Log(
            "Event ended: " + currentEvent
        );

        currentEvent = null;
    }

    public string GetCurrentEvent()
    {
        return currentEvent;
    }
}
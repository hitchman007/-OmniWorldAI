using UnityEngine;
using System.Collections.Generic;

public class OmniWorldEventSystem : MonoBehaviour
{
    public List<string> activeEvents =
        new List<string>();

    public int totalEventsTriggered = 0;

    void Start()
    {
        InitializeEvents();
    }

    void InitializeEvents()
    {
        activeEvents.Add("World Creation Event");
        activeEvents.Add("AI Discovery Event");
        activeEvents.Add("Multiverse Event");

        Debug.Log("Event System Activated");
    }

    public void TriggerEvent(string eventName)
    {
        activeEvents.Add(eventName);

        totalEventsTriggered++;

        Debug.Log(
            "Event Triggered: " +
            eventName
        );
    }

    public void RemoveEvent(string eventName)
    {
        if (activeEvents.Contains(eventName))
        {
            activeEvents.Remove(eventName);

            Debug.Log(
                "Event Removed: " +
                eventName
            );
        }
    }

    public bool HasEvent(string eventName)
    {
        return activeEvents.Contains(eventName);
    }

    public int GetEventCount()
    {
        return totalEventsTriggered;
    }
}
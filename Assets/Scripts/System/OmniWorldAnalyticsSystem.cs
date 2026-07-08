using UnityEngine;
using System.Collections.Generic;

public class OmniWorldAnalyticsSystem : MonoBehaviour
{
    public int worldsVisited = 0;
    public int actionsPerformed = 0;

    public List<string> eventsTracked =
        new List<string>();

    void Start()
    {
        Debug.Log("Analytics System Activated");
    }

    public void TrackEvent(string eventName)
    {
        eventsTracked.Add(eventName);

        actionsPerformed++;

        Debug.Log(
            "Event Tracked: " + eventName
        );
    }

    public void AddWorldVisit(string worldName)
    {
        worldsVisited++;

        TrackEvent(
            "Visited: " + worldName
        );
    }

    public int GetWorldVisits()
    {
        return worldsVisited;
    }

    public int GetActionCount()
    {
        return actionsPerformed;
    }

    public int GetEventCount()
    {
        return eventsTracked.Count;
    }
}
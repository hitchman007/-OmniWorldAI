using UnityEngine;
using System.Collections.Generic;

public class OmniWorldSystemManager : MonoBehaviour
{
    public List<string> activeSystems =
        new List<string>();

    public bool initialized = false;

    void Start()
    {
        InitializeSystems();
    }

    void InitializeSystems()
    {
        activeSystems.Add("Core System");
        activeSystems.Add("AI System");
        activeSystems.Add("World System");
        activeSystems.Add("Player System");
        activeSystems.Add("Multiplayer System");

        initialized = true;

        Debug.Log(
            "OmniWorld AI Systems Initialized"
        );
    }

    public void AddSystem(string systemName)
    {
        if (!activeSystems.Contains(systemName))
        {
            activeSystems.Add(systemName);

            Debug.Log(
                "System Added: " +
                systemName
            );
        }
    }

    public bool HasSystem(string systemName)
    {
        return activeSystems.Contains(systemName);
    }

    public int GetSystemCount()
    {
        return activeSystems.Count;
    }
}
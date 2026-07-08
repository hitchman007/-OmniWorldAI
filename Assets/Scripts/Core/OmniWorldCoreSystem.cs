using UnityEngine;
using System.Collections.Generic;

public class OmniWorldCoreSystem : MonoBehaviour
{
    public string projectName = "OmniWorld AI";

    public string version = "1.0";

    public bool systemActive = true;

    public List<string> connectedSystems =
        new List<string>();

    void Start()
    {
        InitializeCore();
    }

    void InitializeCore()
    {
        connectedSystems.Add("World Generator");
        connectedSystems.Add("AI Systems");
        connectedSystems.Add("Multiplayer");
        connectedSystems.Add("Economy");
        connectedSystems.Add("Cloud Sync");

        Debug.Log(
            projectName +
            " Core System Started"
        );
    }

    public void RegisterSystem(string systemName)
    {
        if (!connectedSystems.Contains(systemName))
        {
            connectedSystems.Add(systemName);

            Debug.Log(
                "System Registered: " +
                systemName
            );
        }
    }

    public bool IsSystemConnected(string systemName)
    {
        return connectedSystems.Contains(systemName);
    }

    public int GetConnectedSystemCount()
    {
        return connectedSystems.Count;
    }

    public string GetProjectInfo()
    {
        return projectName +
            " Version " +
            version;
    }
}
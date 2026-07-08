using UnityEngine;

public class OmniWorldStartupManager : MonoBehaviour
{
    public bool startupCompleted = false;

    public string startupMessage =
        "Initializing OmniWorld AI...";

    void Start()
    {
        StartProject();
    }

    void StartProject()
    {
        Debug.Log(startupMessage);

        LoadCoreSystems();
        LoadWorldSystems();
        LoadAISystems();

        startupCompleted = true;

        Debug.Log(
            "OmniWorld AI Startup Completed"
        );
    }

    void LoadCoreSystems()
    {
        Debug.Log(
            "Core Systems Loaded"
        );
    }

    void LoadWorldSystems()
    {
        Debug.Log(
            "World Systems Loaded"
        );
    }

    void LoadAISystems()
    {
        Debug.Log(
            "AI Systems Loaded"
        );
    }

    public bool IsReady()
    {
        return startupCompleted;
    }
}
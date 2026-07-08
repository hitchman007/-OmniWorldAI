using UnityEngine;

public class OmniWorldVersionManager : MonoBehaviour
{
    public string gameVersion = "OmniWorld AI v1.0";
    public string buildNumber = "001";

    public bool releaseReady = false;

    void Start()
    {
        InitializeVersion();
    }

    void InitializeVersion()
    {
        Debug.Log(
            "Version System Activated: " +
            gameVersion
        );

        Debug.Log(
            "Build Number: " +
            buildNumber
        );
    }

    public void UpdateVersion(string newVersion)
    {
        gameVersion = newVersion;

        Debug.Log(
            "Version Updated: " +
            gameVersion
        );
    }

    public void SetReleaseReady(bool status)
    {
        releaseReady = status;

        Debug.Log(
            "Release Ready: " +
            releaseReady
        );
    }

    public string GetVersion()
    {
        return gameVersion;
    }

    public bool IsReleaseReady()
    {
        return releaseReady;
    }
}
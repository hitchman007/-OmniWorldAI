using UnityEngine;

public class OmniWorldUpdateSystem : MonoBehaviour
{
    public string currentVersion = "v1.0";
    public bool updateAvailable = false;

    void Start()
    {
        CheckForUpdates();
    }

    public void CheckForUpdates()
    {
        Debug.Log(
            "Checking OmniWorld AI Updates..."
        );

        updateAvailable = false;
    }

    public void InstallUpdate(string version)
    {
        currentVersion = version;

        updateAvailable = false;

        Debug.Log(
            "Update Installed: " +
            currentVersion
        );
    }

    public void SetUpdateAvailable(bool status)
    {
        updateAvailable = status;

        Debug.Log(
            "Update Available: " +
            updateAvailable
        );
    }

    public string GetVersion()
    {
        return currentVersion;
    }
}
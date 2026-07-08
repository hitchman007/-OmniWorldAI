using UnityEngine;

public class OmniWorldCloudSyncSystem : MonoBehaviour
{
    public bool isConnected = false;
    public string accountID = "Guest_Player";

    void Start()
    {
        InitializeCloud();
    }

    void InitializeCloud()
    {
        Debug.Log("Cloud Sync System Activated");
    }

    public void ConnectAccount(string id)
    {
        accountID = id;
        isConnected = true;

        Debug.Log(
            "Account Connected: " + accountID
        );
    }

    public void SaveToCloud(string data)
    {
        if (isConnected)
        {
            Debug.Log(
                "Saved To Cloud: " + data
            );
        }
        else
        {
            Debug.Log("Cloud Not Connected");
        }
    }

    public void LoadFromCloud()
    {
        if (isConnected)
        {
            Debug.Log("Cloud Data Loaded");
        }
        else
        {
            Debug.Log("Cloud Not Connected");
        }
    }

    public bool GetConnectionStatus()
    {
        return isConnected;
    }
}
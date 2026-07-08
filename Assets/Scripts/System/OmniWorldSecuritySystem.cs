using UnityEngine;

public class OmniWorldSecuritySystem : MonoBehaviour
{
    public bool protectionEnabled = true;
    public int securityLevel = 5;

    void Start()
    {
        InitializeSecurity();
    }

    void InitializeSecurity()
    {
        Debug.Log("Security System Activated");
        Debug.Log("Security Level: " + securityLevel);
    }

    public void EnableProtection()
    {
        protectionEnabled = true;

        Debug.Log("Protection Enabled");
    }

    public void DisableProtection()
    {
        protectionEnabled = false;

        Debug.Log("Protection Disabled");
    }

    public void IncreaseSecurity()
    {
        securityLevel++;

        Debug.Log(
            "Security Level Increased: " +
            securityLevel
        );
    }

    public bool IsProtected()
    {
        return protectionEnabled;
    }
}
using UnityEngine;

public class OmniWorldSettingsSystem : MonoBehaviour
{
    public float musicVolume = 1f;
    public float effectsVolume = 1f;

    public bool notificationsEnabled = true;
    public bool multiplayerEnabled = true;

    void Start()
    {
        LoadDefaultSettings();
    }

    void LoadDefaultSettings()
    {
        Debug.Log("Settings System Activated");
    }

    public void SetMusicVolume(float value)
    {
        musicVolume = Mathf.Clamp01(value);

        Debug.Log("Music Volume: " + musicVolume);
    }

    public void SetEffectsVolume(float value)
    {
        effectsVolume = Mathf.Clamp01(value);

        Debug.Log("Effects Volume: " + effectsVolume);
    }

    public void ToggleNotifications()
    {
        notificationsEnabled = !notificationsEnabled;

        Debug.Log(
            "Notifications: " +
            notificationsEnabled
        );
    }

    public void ToggleMultiplayer()
    {
        multiplayerEnabled = !multiplayerEnabled;

        Debug.Log(
            "Multiplayer: " +
            multiplayerEnabled
        );
    }
}
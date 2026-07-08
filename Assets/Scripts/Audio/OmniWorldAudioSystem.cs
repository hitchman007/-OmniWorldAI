using UnityEngine;

public class OmniWorldAudioSystem : MonoBehaviour
{
    public float masterVolume = 1f;
    public bool musicEnabled = true;
    public bool effectsEnabled = true;

    void Start()
    {
        InitializeAudio();
    }

    void InitializeAudio()
    {
        Debug.Log("Audio System Activated");
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);

        Debug.Log(
            "Master Volume: " + masterVolume
        );
    }

    public void ToggleMusic()
    {
        musicEnabled = !musicEnabled;

        Debug.Log(
            "Music Enabled: " + musicEnabled
        );
    }

    public void ToggleEffects()
    {
        effectsEnabled = !effectsEnabled;

        Debug.Log(
            "Effects Enabled: " + effectsEnabled
        );
    }

    public bool IsAudioActive()
    {
        return musicEnabled || effectsEnabled;
    }
}
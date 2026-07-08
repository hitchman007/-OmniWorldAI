using UnityEngine;

public class OmniWorldVoiceSystem : MonoBehaviour
{
    public bool voiceEnabled = true;
    public float voiceVolume = 1f;

    public string currentSpeaker = "Omni AI";

    void Start()
    {
        InitializeVoice();
    }

    void InitializeVoice()
    {
        Debug.Log("Voice System Activated");
    }

    public void Speak(string message)
    {
        if (voiceEnabled)
        {
            Debug.Log(
                currentSpeaker + ": " + message
            );
        }
    }

    public void SetSpeaker(string speakerName)
    {
        currentSpeaker = speakerName;

        Debug.Log(
            "Speaker Changed: " + currentSpeaker
        );
    }

    public void ToggleVoice()
    {
        voiceEnabled = !voiceEnabled;

        Debug.Log(
            "Voice Enabled: " + voiceEnabled
        );
    }

    public void SetVoiceVolume(float volume)
    {
        voiceVolume = Mathf.Clamp01(volume);

        Debug.Log(
            "Voice Volume: " + voiceVolume
        );
    }
}
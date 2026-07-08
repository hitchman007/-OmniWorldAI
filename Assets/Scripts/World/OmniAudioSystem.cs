using UnityEngine;

public class OmniAudioSystem : MonoBehaviour
{
    public static OmniAudioSystem Instance;

    private float volume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string soundName)
    {
        Debug.Log(
            "Playing sound: " + soundName
        );
    }

    public void SetVolume(float value)
    {
        volume = value;

        Debug.Log(
            "Audio volume: " + volume
        );
    }

    public float GetVolume()
    {
        return volume;
    }
}
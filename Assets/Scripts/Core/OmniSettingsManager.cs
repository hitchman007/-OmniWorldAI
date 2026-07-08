using UnityEngine;

public class OmniSettingsManager : MonoBehaviour
{
    public static OmniSettingsManager Instance;

    private float volume = 1f;
    private int qualityLevel = 2;

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

    public void SetVolume(float value)
    {
        volume = value;

        Debug.Log(
            "Volume set: " + volume
        );
    }

    public void SetQuality(int level)
    {
        qualityLevel = level;

        Debug.Log(
            "Quality level: " + qualityLevel
        );
    }

    public float GetVolume()
    {
        return volume;
    }

    public int GetQuality()
    {
        return qualityLevel;
    }
}
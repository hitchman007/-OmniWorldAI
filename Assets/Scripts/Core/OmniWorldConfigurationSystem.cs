using UnityEngine;

public class OmniWorldConfigurationSystem : MonoBehaviour
{
    public string language = "English";

    public int graphicsQuality = 3;

    public bool performanceMode = false;

    void Start()
    {
        LoadConfiguration();
    }

    void LoadConfiguration()
    {
        Debug.Log(
            "Configuration System Activated"
        );

        Debug.Log(
            "Language: " + language
        );

        Debug.Log(
            "Graphics Quality: " +
            graphicsQuality
        );
    }

    public void SetLanguage(string newLanguage)
    {
        language = newLanguage;

        Debug.Log(
            "Language Changed: " +
            language
        );
    }

    public void SetGraphicsQuality(int quality)
    {
        graphicsQuality = quality;

        Debug.Log(
            "Graphics Quality: " +
            graphicsQuality
        );
    }

    public void TogglePerformanceMode()
    {
        performanceMode = !performanceMode;

        Debug.Log(
            "Performance Mode: " +
            performanceMode
        );
    }

    public bool IsPerformanceMode()
    {
        return performanceMode;
    }
}
using UnityEngine;

public class OmniPerformanceManager : MonoBehaviour
{
    public static OmniPerformanceManager Instance;

    private int targetFPS = 60;

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

    private void Start()
    {
        ApplyPerformanceSettings();
    }

    public void ApplyPerformanceSettings()
    {
        Application.targetFrameRate = targetFPS;

        Debug.Log(
            "Performance settings applied"
        );
    }

    public void SetFPS(int fps)
    {
        targetFPS = fps;
        Application.targetFrameRate = targetFPS;

        Debug.Log(
            "FPS target: " + targetFPS
        );
    }
}
using UnityEngine;

public class OmniPerformanceManager : MonoBehaviour
{
    public int targetFPS = 60;

    void Start()
    {
        Application.targetFrameRate = targetFPS;

        Debug.Log(
        "Rendimiento configurado a "
        + targetFPS + " FPS"
        );
    }
}
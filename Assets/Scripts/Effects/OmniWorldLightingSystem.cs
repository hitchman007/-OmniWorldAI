using UnityEngine;

public class OmniWorldLightingSystem : MonoBehaviour
{
    public float lightIntensity = 1f;
    public Color worldLightColor = Color.white;

    public bool dynamicLighting = true;

    void Start()
    {
        InitializeLighting();
    }

    void InitializeLighting()
    {
        Debug.Log("Lighting System Activated");
    }

    public void SetLightIntensity(float intensity)
    {
        lightIntensity = intensity;

        Debug.Log(
            "Light Intensity: " +
            lightIntensity
        );
    }

    public void SetLightColor(Color color)
    {
        worldLightColor = color;

        Debug.Log(
            "Light Color Changed"
        );
    }

    public void ToggleDynamicLighting()
    {
        dynamicLighting = !dynamicLighting;

        Debug.Log(
            "Dynamic Lighting: " +
            dynamicLighting
        );
    }

    public bool IsDynamicLightingActive()
    {
        return dynamicLighting;
    }
}
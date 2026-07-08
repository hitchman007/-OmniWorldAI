using UnityEngine;

public class OmniWorldParticleSystem : MonoBehaviour
{
    public bool particlesEnabled = true;
    public int particleAmount = 1000;

    public float effectIntensity = 1f;

    void Start()
    {
        InitializeParticles();
    }

    void InitializeParticles()
    {
        Debug.Log("Particle System Activated");
    }

    public void SetParticleAmount(int amount)
    {
        particleAmount = amount;

        Debug.Log(
            "Particle Amount: " +
            particleAmount
        );
    }

    public void SetIntensity(float intensity)
    {
        effectIntensity = intensity;

        Debug.Log(
            "Effect Intensity: " +
            effectIntensity
        );
    }

    public void ToggleParticles()
    {
        particlesEnabled = !particlesEnabled;

        Debug.Log(
            "Particles Enabled: " +
            particlesEnabled
        );
    }

    public bool AreParticlesActive()
    {
        return particlesEnabled;
    }
}
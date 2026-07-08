using UnityEngine;

public class OmniWorldEnvironmentSystem : MonoBehaviour
{
    public float temperature = 20f;
    public float humidity = 50f;

    public string environmentState = "Balanced";

    void Start()
    {
        InitializeEnvironment();
    }

    void InitializeEnvironment()
    {
        Debug.Log("Environment System Activated");
    }

    public void SetTemperature(float value)
    {
        temperature = value;

        UpdateEnvironment();
    }

    public void SetHumidity(float value)
    {
        humidity = value;

        UpdateEnvironment();
    }

    void UpdateEnvironment()
    {
        if (temperature > 35f)
        {
            environmentState = "Hot";
        }
        else if (temperature < 5f)
        {
            environmentState = "Cold";
        }
        else
        {
            environmentState = "Balanced";
        }

        Debug.Log(
            "Environment: " +
            environmentState
        );
    }

    public string GetEnvironmentState()
    {
        return environmentState;
    }
}
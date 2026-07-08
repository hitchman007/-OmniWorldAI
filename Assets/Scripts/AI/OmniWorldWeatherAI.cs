using UnityEngine;

public class OmniWorldWeatherAI : MonoBehaviour
{
    public string predictedWeather = "Sunny";
    public float predictionAccuracy = 95f;

    void Start()
    {
        InitializeWeatherAI();
    }

    void InitializeWeatherAI()
    {
        Debug.Log("Weather AI System Activated");
    }

    public void PredictWeather(float temperature, float humidity)
    {
        if (humidity > 80f)
        {
            predictedWeather = "Rain";
        }
        else if (temperature > 35f)
        {
            predictedWeather = "Heat Wave";
        }
        else if (temperature < 0f)
        {
            predictedWeather = "Snow";
        }
        else
        {
            predictedWeather = "Sunny";
        }

        Debug.Log(
            "AI Weather Prediction: " +
            predictedWeather
        );
    }

    public string GetPrediction()
    {
        return predictedWeather;
    }

    public float GetAccuracy()
    {
        return predictionAccuracy;
    }
}
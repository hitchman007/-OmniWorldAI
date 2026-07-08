using UnityEngine;

public class OmniWorldWeatherSystem : MonoBehaviour
{
    public enum WeatherType
    {
        Sunny,
        Rain,
        Storm,
        Snow,
        Fog
    }

    public WeatherType currentWeather = WeatherType.Sunny;

    public float weatherIntensity = 1f;

    void Start()
    {
        UpdateWeather();
    }

    public void ChangeWeather(WeatherType newWeather)
    {
        currentWeather = newWeather;

        UpdateWeather();
    }

    void UpdateWeather()
    {
        Debug.Log(
            "Current Weather: " + currentWeather +
            " Intensity: " + weatherIntensity
        );
    }

    public string GetWeather()
    {
        return currentWeather.ToString();
    }
}
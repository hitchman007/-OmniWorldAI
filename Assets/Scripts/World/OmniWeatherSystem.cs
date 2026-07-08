using UnityEngine;

public class OmniWeatherSystem : MonoBehaviour
{
    public static OmniWeatherSystem Instance;

    private string currentWeather;

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

    public void ChangeWeather(string weather)
    {
        currentWeather = weather;

        Debug.Log(
            "Weather changed: " + weather
        );
    }

    public string GetWeather()
    {
        return currentWeather;
    }
}
using UnityEngine;

public class OmniEnvironmentSystem : MonoBehaviour
{
    public string weather;

    public void SetWeather(string newWeather)
    {
        weather = newWeather;

        Debug.Log(
        "Clima cambiado: " + weather
        );
    }

    public void SetTime(string time)
    {
        Debug.Log(
        "Hora del mundo: " + time
        );
    }
}
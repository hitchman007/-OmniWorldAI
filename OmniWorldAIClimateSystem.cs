using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIClimateSystem : MonoBehaviour
    {
        public static OmniWorldAIClimateSystem Instance;

        public float Temperature { get; private set; }

        public float Humidity { get; private set; }

        public string CurrentWeather { get; private set; }


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


        public void InitializeClimate()
        {
            Temperature = 22f;

            Humidity = 50f;

            CurrentWeather = "Clear";

            Debug.Log(
                "AI Climate System Initialized"
            );
        }


        public void ChangeWeather(
            string weather)
        {
            CurrentWeather = weather;

            Debug.Log(
                "Weather changed: " + weather
            );
        }


        public void UpdateClimate(
            float temperature,
            float humidity)
        {
            Temperature = temperature;

            Humidity = humidity;
        }


        public string GetWeather()
        {
            return CurrentWeather;
        }


        public void ResetClimate()
        {
            Temperature = 22f;

            Humidity = 50f;

            CurrentWeather = "Clear";
        }
    }
}
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerLatencyMonitor : MonoBehaviour
    {
        public static OmniMultiplayerLatencyMonitor Instance;

        private float currentLatency;

        private float averageLatency;


        private int samples;


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


        public void UpdateLatency(
            float latency)
        {
            currentLatency = latency;

            samples++;

            averageLatency =
                ((averageLatency * (samples - 1)) +
                latency) / samples;
        }


        public float GetCurrentLatency()
        {
            return currentLatency;
        }


        public float GetAverageLatency()
        {
            return averageLatency;
        }


        public string GetConnectionQuality()
        {
            if (currentLatency < 50)
            {
                return "Excellent";
            }

            if (currentLatency < 100)
            {
                return "Good";
            }

            if (currentLatency < 200)
            {
                return "Medium";
            }

            return "Poor";
        }


        public void ResetMonitor()
        {
            currentLatency = 0;
            averageLatency = 0;
            samples = 0;
        }
    }
}
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIEnvironmentSystem : MonoBehaviour
    {
        public static OmniWorldAIEnvironmentSystem Instance;

        public float WorldTemperature { get; private set; }

        public float WorldEnergy { get; private set; }


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


        public void InitializeEnvironment()
        {
            WorldTemperature = 25f;

            WorldEnergy = 100f;

            Debug.Log(
                "AI Environment Initialized"
            );
        }


        public void UpdateEnvironment(
            float temperatureChange,
            float energyChange)
        {
            WorldTemperature += temperatureChange;

            WorldEnergy += energyChange;
        }


        public float GetTemperature()
        {
            return WorldTemperature;
        }


        public float GetEnergy()
        {
            return WorldEnergy;
        }


        public void ResetEnvironment()
        {
            WorldTemperature = 25f;

            WorldEnergy = 100f;
        }
    }
}
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIWorldSimulation : MonoBehaviour
    {
        public static OmniWorldAIWorldSimulation Instance;

        public float SimulationTime { get; private set; }

        public bool SimulationActive { get; private set; }


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


        public void StartSimulation()
        {
            SimulationActive = true;

            SimulationTime = 0f;

            Debug.Log(
                "AI World Simulation Started"
            );
        }


        private void Update()
        {
            if (SimulationActive)
            {
                SimulationTime += Time.deltaTime;
            }
        }


        public void StopSimulation()
        {
            SimulationActive = false;

            Debug.Log(
                "AI World Simulation Stopped"
            );
        }


        public float GetSimulationTime()
        {
            return SimulationTime;
        }


        public void ResetSimulation()
        {
            SimulationTime = 0f;
        }
    }
}
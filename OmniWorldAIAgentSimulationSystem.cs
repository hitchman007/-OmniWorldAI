using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentSimulationSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentSimulationSystem Instance;

        private Dictionary<string, float> agentSimulationTime =
            new Dictionary<string, float>();

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

            Debug.Log(
                "AI Agent Simulation Started"
            );
        }


        public void UpdateAgent(
            string agentID,
            float deltaTime)
        {
            if (!SimulationActive)
            {
                return;
            }


            if (agentSimulationTime.ContainsKey(agentID))
            {
                agentSimulationTime[agentID] += deltaTime;
            }
            else
            {
                agentSimulationTime.Add(
                    agentID,
                    deltaTime
                );
            }
        }


        public float GetAgentTime(
            string agentID)
        {
            if (agentSimulationTime.ContainsKey(agentID))
            {
                return agentSimulationTime[agentID];
            }

            return 0f;
        }


        public void StopSimulation()
        {
            SimulationActive = false;

            Debug.Log(
                "AI Agent Simulation Stopped"
            );
        }


        public void ResetSimulation()
        {
            agentSimulationTime.Clear();
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentGoalSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentGoalSystem Instance;

        private Dictionary<string, string> agentGoals =
            new Dictionary<string, string>();


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


        public void SetGoal(
            string agentID,
            string goal)
        {
            if (agentGoals.ContainsKey(agentID))
            {
                agentGoals[agentID] = goal;
            }
            else
            {
                agentGoals.Add(
                    agentID,
                    goal
                );
            }


            Debug.Log(
                "Agent goal assigned: " +
                agentID
            );
        }


        public string GetGoal(
            string agentID)
        {
            if (agentGoals.ContainsKey(agentID))
            {
                return agentGoals[agentID];
            }

            return "No Goal";
        }


        public bool HasGoal(
            string agentID)
        {
            return agentGoals.ContainsKey(agentID);
        }


        public void RemoveGoal(
            string agentID)
        {
            if (agentGoals.ContainsKey(agentID))
            {
                agentGoals.Remove(agentID);
            }
        }


        public void ClearGoals()
        {
            agentGoals.Clear();
        }
    }
}
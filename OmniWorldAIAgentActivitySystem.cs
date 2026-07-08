using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentActivitySystem : MonoBehaviour
    {
        public static OmniWorldAIAgentActivitySystem Instance;

        private Dictionary<string, string> activities =
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


        public void SetActivity(
            string agentID,
            string activity)
        {
            if (activities.ContainsKey(agentID))
            {
                activities[agentID] = activity;
            }
            else
            {
                activities.Add(
                    agentID,
                    activity
                );
            }


            Debug.Log(
                "Agent activity: " +
                agentID +
                " -> " +
                activity
            );
        }


        public string GetActivity(
            string agentID)
        {
            if (activities.ContainsKey(agentID))
            {
                return activities[agentID];
            }

            return "Idle";
        }


        public void RemoveActivity(
            string agentID)
        {
            if (activities.ContainsKey(agentID))
            {
                activities.Remove(agentID);
            }
        }


        public void ClearActivities()
        {
            activities.Clear();
        }
    }
}
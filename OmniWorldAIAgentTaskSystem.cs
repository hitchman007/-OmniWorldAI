using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentTaskSystem : MonoBehaviour
    {
        public static OmniWorldAIAgentTaskSystem Instance;

        private Dictionary<string, List<string>> tasks =
            new Dictionary<string, List<string>>();


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


        public void RegisterAgent(
            string agentID)
        {
            if (!tasks.ContainsKey(agentID))
            {
                tasks.Add(
                    agentID,
                    new List<string>()
                );
            }
        }


        public void AddTask(
            string agentID,
            string task)
        {
            if (!tasks.ContainsKey(agentID))
            {
                RegisterAgent(agentID);
            }

            tasks[agentID].Add(task);
        }


        public List<string> GetTasks(
            string agentID)
        {
            if (tasks.ContainsKey(agentID))
            {
                return tasks[agentID];
            }

            return new List<string>();
        }


        public void CompleteTask(
            string agentID,
            string task)
        {
            if (tasks.ContainsKey(agentID))
            {
                tasks[agentID].Remove(task);
            }
        }


        public void ClearTasks(
            string agentID)
        {
            if (tasks.ContainsKey(agentID))
            {
                tasks[agentID].Clear();
            }
        }


        public int GetTaskCount(
            string agentID)
        {
            if (tasks.ContainsKey(agentID))
            {
                return tasks[agentID].Count;
            }

            return 0;
        }
    }
}
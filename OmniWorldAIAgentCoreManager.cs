using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentCoreManager : MonoBehaviour
    {
        public static OmniWorldAIAgentCoreManager Instance;

        public bool AgentSystemActive { get; private set; }


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


        public void InitializeAgents()
        {
            AgentSystemActive = true;

            Debug.Log(
                "OmniWorld AI Agent System Initialized"
            );
        }


        public void ShutdownAgents()
        {
            AgentSystemActive = false;

            Debug.Log(
                "OmniWorld AI Agent System Shutdown"
            );
        }


        public bool IsAgentSystemActive()
        {
            return AgentSystemActive;
        }
    }
}
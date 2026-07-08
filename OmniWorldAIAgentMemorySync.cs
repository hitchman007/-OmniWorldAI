using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIAgentMemorySync : MonoBehaviour
    {
        public static OmniWorldAIAgentMemorySync Instance;

        private Dictionary<string, string> syncedMemory =
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


        public void SyncMemory(
            string agentID,
            string memory)
        {
            if (syncedMemory.ContainsKey(agentID))
            {
                syncedMemory[agentID] = memory;
            }
            else
            {
                syncedMemory.Add(
                    agentID,
                    memory
                );
            }


            Debug.Log(
                "Agent memory synced: " +
                agentID
            );
        }


        public string GetSyncedMemory(
            string agentID)
        {
            if (syncedMemory.ContainsKey(agentID))
            {
                return syncedMemory[agentID];
            }

            return "";
        }


        public bool HasSyncedMemory(
            string agentID)
        {
            return syncedMemory.ContainsKey(agentID);
        }


        public void RemoveSync(
            string agentID)
        {
            if (syncedMemory.ContainsKey(agentID))
            {
                syncedMemory.Remove(agentID);
            }
        }


        public void ClearSync()
        {
            syncedMemory.Clear();
        }
    }
}
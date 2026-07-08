using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAINPCSystem : MonoBehaviour
    {
        public static OmniWorldAINPCSystem Instance;

        private List<string> npcAgents =
            new List<string>();


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


        public void CreateNPC(string npcID)
        {
            if (!npcAgents.Contains(npcID))
            {
                npcAgents.Add(npcID);

                Debug.Log(
                    "AI NPC Created: " + npcID
                );
            }
        }


        public void RemoveNPC(string npcID)
        {
            if (npcAgents.Contains(npcID))
            {
                npcAgents.Remove(npcID);
            }
        }


        public bool HasNPC(string npcID)
        {
            return npcAgents.Contains(npcID);
        }


        public List<string> GetNPCs()
        {
            return npcAgents;
        }


        public int GetNPCCount()
        {
            return npcAgents.Count;
        }
    }
}
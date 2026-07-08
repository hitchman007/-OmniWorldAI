using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAINPCBehaviorSystem : MonoBehaviour
    {
        public static OmniWorldAINPCBehaviorSystem Instance;

        private Dictionary<string, string> npcBehaviors =
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


        public void SetBehavior(
            string npcID,
            string behavior)
        {
            if (npcBehaviors.ContainsKey(npcID))
            {
                npcBehaviors[npcID] = behavior;
            }
            else
            {
                npcBehaviors.Add(
                    npcID,
                    behavior
                );
            }


            Debug.Log(
                "NPC behavior set: " + npcID
            );
        }


        public string GetBehavior(
            string npcID)
        {
            if (npcBehaviors.ContainsKey(npcID))
            {
                return npcBehaviors[npcID];
            }

            return "Neutral";
        }


        public void RemoveNPC(
            string npcID)
        {
            if (npcBehaviors.ContainsKey(npcID))
            {
                npcBehaviors.Remove(npcID);
            }
        }


        public Dictionary<string, string> GetAllBehaviors()
        {
            return npcBehaviors;
        }
    }
}
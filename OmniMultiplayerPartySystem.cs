using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerPartySystem : MonoBehaviour
    {
        public static OmniMultiplayerPartySystem Instance;

        private Dictionary<string, List<string>> parties =
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


        public void CreateParty(string partyID)
        {
            if (!parties.ContainsKey(partyID))
            {
                parties.Add(
                    partyID,
                    new List<string>()
                );
            }
        }


        public void JoinParty(
            string partyID,
            string playerID)
        {
            if (parties.ContainsKey(partyID))
            {
                if (!parties[partyID].Contains(playerID))
                {
                    parties[partyID].Add(playerID);
                }
            }
        }


        public void LeaveParty(
            string partyID,
            string playerID)
        {
            if (parties.ContainsKey(partyID))
            {
                parties[partyID].Remove(playerID);
            }
        }


        public List<string> GetPartyMembers(
            string partyID)
        {
            if (parties.ContainsKey(partyID))
            {
                return parties[partyID];
            }

            return new List<string>();
        }


        public int GetPartySize(
            string partyID)
        {
            if (parties.ContainsKey(partyID))
            {
                return parties[partyID].Count;
            }

            return 0;
        }
    }
}
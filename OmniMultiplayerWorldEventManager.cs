using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerWorldEventManager : MonoBehaviour
    {
        public static OmniMultiplayerWorldEventManager Instance;

        private Dictionary<string, int> eventParticipants =
            new Dictionary<string, int>();


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


        public void RegisterEvent(string eventID)
        {
            if (!eventParticipants.ContainsKey(eventID))
            {
                eventParticipants.Add(eventID, 0);
            }
        }


        public void AddParticipant(string eventID)
        {
            if (eventParticipants.ContainsKey(eventID))
            {
                eventParticipants[eventID]++;
            }
        }


        public void RemoveParticipant(string eventID)
        {
            if (eventParticipants.ContainsKey(eventID) &&
                eventParticipants[eventID] > 0)
            {
                eventParticipants[eventID]--;
            }
        }


        public int GetParticipants(string eventID)
        {
            if (eventParticipants.ContainsKey(eventID))
            {
                return eventParticipants[eventID];
            }

            return 0;
        }


        public void DeleteEvent(string eventID)
        {
            if (eventParticipants.ContainsKey(eventID))
            {
                eventParticipants.Remove(eventID);
            }
        }
    }
}
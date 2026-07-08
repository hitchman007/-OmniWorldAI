using System;
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerWorldEventSystem : MonoBehaviour
    {
        public static OmniMultiplayerWorldEventSystem Instance;

        private List<string> activeEvents =
            new List<string>();

        public event Action<string> OnWorldEventStarted;
        public event Action<string> OnWorldEventEnded;


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


        public void StartWorldEvent(string eventID)
        {
            if (!activeEvents.Contains(eventID))
            {
                activeEvents.Add(eventID);

                OnWorldEventStarted?.Invoke(eventID);

                Debug.Log(
                    "World event started: " + eventID
                );
            }
        }


        public void EndWorldEvent(string eventID)
        {
            if (activeEvents.Contains(eventID))
            {
                activeEvents.Remove(eventID);

                OnWorldEventEnded?.Invoke(eventID);

                Debug.Log(
                    "World event ended: " + eventID
                );
            }
        }


        public bool IsEventActive(string eventID)
        {
            return activeEvents.Contains(eventID);
        }


        public List<string> GetActiveEvents()
        {
            return activeEvents;
        }


        public void ClearEvents()
        {
            activeEvents.Clear();
        }
    }
}
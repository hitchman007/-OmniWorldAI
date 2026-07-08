using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIEventGenerator : MonoBehaviour
    {
        public static OmniWorldAIEventGenerator Instance;

        private List<string> generatedEvents =
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


        public void GenerateEvent(
            string eventName)
        {
            if (!generatedEvents.Contains(eventName))
            {
                generatedEvents.Add(eventName);

                Debug.Log(
                    "AI Event Generated: " +
                    eventName
                );
            }
        }


        public void RemoveEvent(
            string eventName)
        {
            if (generatedEvents.Contains(eventName))
            {
                generatedEvents.Remove(eventName);
            }
        }


        public bool HasEvent(
            string eventName)
        {
            return generatedEvents.Contains(eventName);
        }


        public List<string> GetEvents()
        {
            return generatedEvents;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerServerBrowser : MonoBehaviour
    {
        public static OmniMultiplayerServerBrowser Instance;

        private List<string> availableServers =
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


        public void AddServer(string serverID)
        {
            if (!availableServers.Contains(serverID))
            {
                availableServers.Add(serverID);

                Debug.Log(
                    "Server added: " + serverID
                );
            }
        }


        public void RemoveServer(string serverID)
        {
            if (availableServers.Contains(serverID))
            {
                availableServers.Remove(serverID);
            }
        }


        public List<string> GetServers()
        {
            return availableServers;
        }


        public bool ServerExists(string serverID)
        {
            return availableServers.Contains(serverID);
        }


        public int GetServerCount()
        {
            return availableServers.Count;
        }
    }
}
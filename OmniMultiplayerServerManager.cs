using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerServerManager : MonoBehaviour
    {
        public static OmniMultiplayerServerManager Instance;

        private Dictionary<string, OmniMultiplayerServerData> servers =
            new Dictionary<string, OmniMultiplayerServerData>();


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


        public void CreateServer(
            string serverID,
            string serverName,
            int maxPlayers)
        {
            if (!servers.ContainsKey(serverID))
            {
                OmniMultiplayerServerData server =
                    new OmniMultiplayerServerData(
                        serverID,
                        serverName,
                        maxPlayers
                    );

                servers.Add(serverID, server);

                Debug.Log(
                    "Server created: " + serverID
                );
            }
        }


        public void AddPlayer(
            string serverID)
        {
            if (servers.ContainsKey(serverID))
            {
                servers[serverID].AddPlayer();
            }
        }


        public void RemovePlayer(
            string serverID)
        {
            if (servers.ContainsKey(serverID))
            {
                servers[serverID].RemovePlayer();
            }
        }


        public OmniMultiplayerServerData GetServer(
            string serverID)
        {
            if (servers.ContainsKey(serverID))
            {
                return servers[serverID];
            }

            return null;
        }


        public void RemoveServer(
            string serverID)
        {
            if (servers.ContainsKey(serverID))
            {
                servers.Remove(serverID);
            }
        }
    }
}
using System;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    [Serializable]
    public class OmniMultiplayerServerData
    {
        public string ServerID;

        public string ServerName;

        public int MaxPlayers;

        public int CurrentPlayers;

        public bool IsOnline;


        public OmniMultiplayerServerData(
            string serverID,
            string serverName,
            int maxPlayers)
        {
            ServerID = serverID;

            ServerName = serverName;

            MaxPlayers = maxPlayers;

            CurrentPlayers = 0;

            IsOnline = true;
        }


        public void AddPlayer()
        {
            if (CurrentPlayers < MaxPlayers)
            {
                CurrentPlayers++;
            }
        }


        public void RemovePlayer()
        {
            if (CurrentPlayers > 0)
            {
                CurrentPlayers--;
            }
        }


        public bool IsFull()
        {
            return CurrentPlayers >= MaxPlayers;
        }


        public void Shutdown()
        {
            IsOnline = false;
        }
    }
}
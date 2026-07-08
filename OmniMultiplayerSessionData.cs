using System;
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    [Serializable]
    public class OmniMultiplayerSessionData
    {
        public string SessionID;

        public string WorldID;

        public string HostPlayerID;

        public List<string> Players =
            new List<string>();

        public float CreationTime;


        public OmniMultiplayerSessionData(
            string sessionID,
            string worldID,
            string hostPlayerID)
        {
            SessionID = sessionID;

            WorldID = worldID;

            HostPlayerID = hostPlayerID;

            CreationTime = Time.time;
        }


        public void AddPlayer(string playerID)
        {
            if (!Players.Contains(playerID))
            {
                Players.Add(playerID);
            }
        }


        public void RemovePlayer(string playerID)
        {
            if (Players.Contains(playerID))
            {
                Players.Remove(playerID);
            }
        }


        public bool ContainsPlayer(string playerID)
        {
            return Players.Contains(playerID);
        }


        public int GetPlayerCount()
        {
            return Players.Count;
        }
    }
}
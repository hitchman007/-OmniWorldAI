using System;
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    [Serializable]
    public class OmniMultiplayerWorldState
    {
        public string WorldID;

        public string WorldName;

        public List<string> ActivePlayers =
            new List<string>();

        public float LastUpdateTime;


        public OmniMultiplayerWorldState(
            string worldID,
            string worldName)
        {
            WorldID = worldID;

            WorldName = worldName;

            LastUpdateTime = Time.time;
        }


        public void AddPlayer(string playerID)
        {
            if (!ActivePlayers.Contains(playerID))
            {
                ActivePlayers.Add(playerID);
                UpdateTime();
            }
        }


        public void RemovePlayer(string playerID)
        {
            if (ActivePlayers.Contains(playerID))
            {
                ActivePlayers.Remove(playerID);
                UpdateTime();
            }
        }


        public void UpdateTime()
        {
            LastUpdateTime = Time.time;
        }


        public int GetPlayerCount()
        {
            return ActivePlayers.Count;
        }
    }
}
using System;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    [Serializable]
    public class OmniMultiplayerPlayerData
    {
        public string PlayerID;

        public string PlayerName;

        public Vector3 Position;

        public Vector3 Rotation;

        public int Level;

        public float Experience;


        public OmniMultiplayerPlayerData(
            string playerID,
            string playerName)
        {
            PlayerID = playerID;

            PlayerName = playerName;

            Position = Vector3.zero;

            Rotation = Vector3.zero;

            Level = 1;

            Experience = 0;
        }


        public void UpdateTransform(
            Vector3 position,
            Vector3 rotation)
        {
            Position = position;

            Rotation = rotation;
        }


        public void AddExperience(float amount)
        {
            Experience += amount;

            if (Experience >= 100)
            {
                Level++;

                Experience = 0;
            }
        }


        public string GetPlayerInfo()
        {
            return PlayerName +
                " Level: " + Level;
        }
    }
}
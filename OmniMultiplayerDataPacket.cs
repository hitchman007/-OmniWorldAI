using System;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    [Serializable]
    public class OmniMultiplayerDataPacket
    {
        public string PlayerID;

        public Vector3 Position;

        public Vector3 Rotation;

        public string Action;

        public float Timestamp;


        public OmniMultiplayerDataPacket(
            string playerID,
            Vector3 position,
            Vector3 rotation,
            string action)
        {
            PlayerID = playerID;

            Position = position;

            Rotation = rotation;

            Action = action;

            Timestamp = Time.time;
        }


        public void UpdateData(
            Vector3 position,
            Vector3 rotation,
            string action)
        {
            Position = position;

            Rotation = rotation;

            Action = action;

            Timestamp = Time.time;
        }


        public string GetPacketInfo()
        {
            return
                "Player: " + PlayerID +
                " Action: " + Action +
                " Time: " + Timestamp;
        }
    }
}
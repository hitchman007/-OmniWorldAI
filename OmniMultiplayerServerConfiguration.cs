using System;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    [Serializable]
    public class OmniMultiplayerServerConfiguration
    {
        public string ServerName;

        public int MaxPlayers;

        public float TickRate;

        public bool EnableVoiceChat;

        public bool EnableWorldSync;


        public OmniMultiplayerServerConfiguration()
        {
            ServerName = "OmniWorld AI Server";

            MaxPlayers = 100;

            TickRate = 60f;

            EnableVoiceChat = true;

            EnableWorldSync = true;
        }


        public void SetPlayerLimit(
            int limit)
        {
            MaxPlayers = limit;
        }


        public void SetTickRate(
            float rate)
        {
            TickRate = rate;
        }


        public void EnableFeatures(
            bool voice,
            bool sync)
        {
            EnableVoiceChat = voice;

            EnableWorldSync = sync;
        }
    }
}
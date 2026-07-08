using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniPlayerNetworkIdentity : MonoBehaviour
    {
        public string PlayerID { get; private set; }

        public string PlayerName { get; private set; }

        public bool IsConnected { get; private set; }


        private void Awake()
        {
            GeneratePlayerIdentity();
        }


        private void GeneratePlayerIdentity()
        {
            PlayerID = System.Guid.NewGuid().ToString();

            PlayerName = "OmniPlayer_" + PlayerID.Substring(0, 6);

            IsConnected = false;
        }


        public void ConnectPlayer()
        {
            IsConnected = true;

            Debug.Log("Player connected: " + PlayerName);
        }


        public void DisconnectPlayer()
        {
            IsConnected = false;

            Debug.Log("Player disconnected: " + PlayerName);
        }


        public string GetPlayerID()
        {
            return PlayerID;
        }


        public string GetPlayerName()
        {
            return PlayerName;
        }
    }
}
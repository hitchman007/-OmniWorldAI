using UnityEngine;
using System.Collections.Generic;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerNetworkManager : MonoBehaviour
    {
        public static OmniMultiplayerNetworkManager Instance;

        private List<OmniPlayerNetworkIdentity> players =
            new List<OmniPlayerNetworkIdentity>();

        public bool NetworkRunning { get; private set; }


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


        public void StartNetwork()
        {
            NetworkRunning = true;

            Debug.Log("OmniWorld AI Network Started");
        }


        public void RegisterPlayer(OmniPlayerNetworkIdentity player)
        {
            if (!players.Contains(player))
            {
                players.Add(player);

                Debug.Log("Player registered: " + player.GetPlayerName());
            }
        }


        public void UnregisterPlayer(OmniPlayerNetworkIdentity player)
        {
            if (players.Contains(player))
            {
                players.Remove(player);

                Debug.Log("Player removed: " + player.GetPlayerName());
            }
        }


        public List<OmniPlayerNetworkIdentity> GetConnectedPlayers()
        {
            return players;
        }


        public void StopNetwork()
        {
            players.Clear();

            NetworkRunning = false;

            Debug.Log("OmniWorld AI Network Stopped");
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerMatchmaking : MonoBehaviour
    {
        public static OmniMultiplayerMatchmaking Instance;

        private List<string> waitingPlayers =
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


        public void AddPlayerToQueue(string playerID)
        {
            if (!waitingPlayers.Contains(playerID))
            {
                waitingPlayers.Add(playerID);

                Debug.Log("Player added to matchmaking: " + playerID);
            }
        }


        public void RemovePlayerFromQueue(string playerID)
        {
            if (waitingPlayers.Contains(playerID))
            {
                waitingPlayers.Remove(playerID);

                Debug.Log("Player removed from matchmaking: " + playerID);
            }
        }


        public string FindMatch()
        {
            if (waitingPlayers.Count >= 2)
            {
                string playerOne = waitingPlayers[0];
                string playerTwo = waitingPlayers[1];

                waitingPlayers.RemoveAt(0);
                waitingPlayers.RemoveAt(0);

                string matchID =
                    playerOne + "_VS_" + playerTwo;

                Debug.Log("Match found: " + matchID);

                return matchID;
            }

            return null;
        }


        public int GetWaitingPlayers()
        {
            return waitingPlayers.Count;
        }
    }
}
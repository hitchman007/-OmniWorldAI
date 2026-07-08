using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerLeaderboard : MonoBehaviour
    {
        public static OmniMultiplayerLeaderboard Instance;

        private Dictionary<string, int> playerScores =
            new Dictionary<string, int>();


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


        public void RegisterPlayer(string playerID)
        {
            if (!playerScores.ContainsKey(playerID))
            {
                playerScores.Add(playerID, 0);

                Debug.Log("Leaderboard player added: " + playerID);
            }
        }


        public void AddScore(
            string playerID,
            int amount)
        {
            if (playerScores.ContainsKey(playerID))
            {
                playerScores[playerID] += amount;
            }
        }


        public int GetScore(string playerID)
        {
            if (playerScores.ContainsKey(playerID))
            {
                return playerScores[playerID];
            }

            return 0;
        }


        public Dictionary<string, int> GetLeaderboard()
        {
            return playerScores;
        }


        public void RemovePlayer(string playerID)
        {
            if (playerScores.ContainsKey(playerID))
            {
                playerScores.Remove(playerID);
            }
        }


        public void ClearLeaderboard()
        {
            playerScores.Clear();
        }
    }
}
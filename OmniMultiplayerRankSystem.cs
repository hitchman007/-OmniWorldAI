using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerRankSystem : MonoBehaviour
    {
        public static OmniMultiplayerRankSystem Instance;

        private Dictionary<string, int> playerRanks =
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
            if (!playerRanks.ContainsKey(playerID))
            {
                playerRanks.Add(playerID, 1);
            }
        }


        public void IncreaseRank(string playerID)
        {
            if (!playerRanks.ContainsKey(playerID))
            {
                RegisterPlayer(playerID);
            }

            playerRanks[playerID]++;

            Debug.Log(
                "Player rank increased: " + playerID
            );
        }


        public int GetRank(string playerID)
        {
            if (playerRanks.ContainsKey(playerID))
            {
                return playerRanks[playerID];
            }

            return 1;
        }


        public void SetRank(
            string playerID,
            int rank)
        {
            playerRanks[playerID] = rank;
        }


        public void RemovePlayer(string playerID)
        {
            if (playerRanks.ContainsKey(playerID))
            {
                playerRanks.Remove(playerID);
            }
        }
    }
}
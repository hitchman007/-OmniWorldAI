using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerRewardSystem : MonoBehaviour
    {
        public static OmniMultiplayerRewardSystem Instance;

        private Dictionary<string, int> playerRewards =
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
            if (!playerRewards.ContainsKey(playerID))
            {
                playerRewards.Add(playerID, 0);
            }
        }


        public void AddReward(
            string playerID,
            int amount)
        {
            if (!playerRewards.ContainsKey(playerID))
            {
                RegisterPlayer(playerID);
            }

            playerRewards[playerID] += amount;

            Debug.Log(
                "Reward added to " + playerID +
                ": " + amount
            );
        }


        public int GetRewards(string playerID)
        {
            if (playerRewards.ContainsKey(playerID))
            {
                return playerRewards[playerID];
            }

            return 0;
        }


        public void RemoveRewards(string playerID)
        {
            if (playerRewards.ContainsKey(playerID))
            {
                playerRewards[playerID] = 0;
            }
        }


        public void RemovePlayer(string playerID)
        {
            if (playerRewards.ContainsKey(playerID))
            {
                playerRewards.Remove(playerID);
            }
        }
    }
}
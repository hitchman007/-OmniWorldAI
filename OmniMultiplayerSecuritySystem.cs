using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerSecuritySystem : MonoBehaviour
    {
        public static OmniMultiplayerSecuritySystem Instance;

        private Dictionary<string, string> playerTokens =
            new Dictionary<string, string>();


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


        public string GenerateToken(
            string playerID)
        {
            string token =
                System.Guid.NewGuid().ToString();


            if (playerTokens.ContainsKey(playerID))
            {
                playerTokens[playerID] = token;
            }
            else
            {
                playerTokens.Add(playerID, token);
            }


            return token;
        }


        public bool VerifyToken(
            string playerID,
            string token)
        {
            if (playerTokens.ContainsKey(playerID))
            {
                return playerTokens[playerID] == token;
            }

            return false;
        }


        public void RemovePlayer(
            string playerID)
        {
            if (playerTokens.ContainsKey(playerID))
            {
                playerTokens.Remove(playerID);
            }
        }


        public int GetConnectedTokens()
        {
            return playerTokens.Count;
        }
    }
}
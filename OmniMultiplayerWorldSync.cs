using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerWorldSync : MonoBehaviour
    {
        public static OmniMultiplayerWorldSync Instance;

        private Dictionary<string, Vector3> playerPositions = new Dictionary<string, Vector3>();

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


        public void UpdatePlayerPosition(string playerID, Vector3 position)
        {
            if (playerPositions.ContainsKey(playerID))
            {
                playerPositions[playerID] = position;
            }
            else
            {
                playerPositions.Add(playerID, position);
            }
        }


        public Vector3 GetPlayerPosition(string playerID)
        {
            if (playerPositions.ContainsKey(playerID))
            {
                return playerPositions[playerID];
            }

            return Vector3.zero;
        }


        public Dictionary<string, Vector3> GetAllPlayerPositions()
        {
            return playerPositions;
        }


        public void RemovePlayer(string playerID)
        {
            if (playerPositions.ContainsKey(playerID))
            {
                playerPositions.Remove(playerID);
            }
        }


        public void ClearWorldSync()
        {
            playerPositions.Clear();
        }
    }
}
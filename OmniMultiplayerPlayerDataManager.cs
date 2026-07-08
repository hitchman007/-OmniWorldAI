using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerPlayerDataManager : MonoBehaviour
    {
        public static OmniMultiplayerPlayerDataManager Instance;

        private Dictionary<string, OmniMultiplayerPlayerData> playerData =
            new Dictionary<string, OmniMultiplayerPlayerData>();


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


        public void CreatePlayerData(
            string playerID,
            string playerName)
        {
            if (!playerData.ContainsKey(playerID))
            {
                OmniMultiplayerPlayerData data =
                    new OmniMultiplayerPlayerData(
                        playerID,
                        playerName
                    );

                playerData.Add(playerID, data);

                Debug.Log("Player data created: " + playerID);
            }
        }


        public OmniMultiplayerPlayerData GetPlayerData(
            string playerID)
        {
            if (playerData.ContainsKey(playerID))
            {
                return playerData[playerID];
            }

            return null;
        }


        public void RemovePlayerData(
            string playerID)
        {
            if (playerData.ContainsKey(playerID))
            {
                playerData.Remove(playerID);

                Debug.Log("Player data removed: " + playerID);
            }
        }


        public List<OmniMultiplayerPlayerData> GetAllPlayerData()
        {
            return new List<OmniMultiplayerPlayerData>(
                playerData.Values
            );
        }


        public int GetTotalPlayers()
        {
            return playerData.Count;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerPlayerSaveSystem : MonoBehaviour
    {
        public static OmniMultiplayerPlayerSaveSystem Instance;

        private Dictionary<string, OmniMultiplayerPlayerData> savedPlayers =
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


        public void SavePlayer(
            OmniMultiplayerPlayerData player)
        {
            if (player == null)
                return;


            if (savedPlayers.ContainsKey(player.PlayerID))
            {
                savedPlayers[player.PlayerID] = player;
            }
            else
            {
                savedPlayers.Add(player.PlayerID, player);
            }


            Debug.Log("Player saved: " + player.PlayerID);
        }


        public OmniMultiplayerPlayerData LoadPlayer(
            string playerID)
        {
            if (savedPlayers.ContainsKey(playerID))
            {
                return savedPlayers[playerID];
            }

            return null;
        }


        public bool HasPlayerSave(
            string playerID)
        {
            return savedPlayers.ContainsKey(playerID);
        }


        public void DeletePlayerSave(
            string playerID)
        {
            if (savedPlayers.ContainsKey(playerID))
            {
                savedPlayers.Remove(playerID);

                Debug.Log("Player save deleted: " + playerID);
            }
        }


        public void ClearAllSaves()
        {
            savedPlayers.Clear();

            Debug.Log("All player saves cleared.");
        }
    }
}
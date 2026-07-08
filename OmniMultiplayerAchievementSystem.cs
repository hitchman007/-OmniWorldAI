using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerAchievementSystem : MonoBehaviour
    {
        public static OmniMultiplayerAchievementSystem Instance;

        private Dictionary<string, List<string>> playerAchievements =
            new Dictionary<string, List<string>>();


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
            if (!playerAchievements.ContainsKey(playerID))
            {
                playerAchievements.Add(
                    playerID,
                    new List<string>()
                );
            }
        }


        public void UnlockAchievement(
            string playerID,
            string achievement)
        {
            if (!playerAchievements.ContainsKey(playerID))
            {
                RegisterPlayer(playerID);
            }


            if (!playerAchievements[playerID].Contains(achievement))
            {
                playerAchievements[playerID].Add(achievement);

                Debug.Log(
                    "Achievement unlocked: " + achievement
                );
            }
        }


        public List<string> GetAchievements(
            string playerID)
        {
            if (playerAchievements.ContainsKey(playerID))
            {
                return playerAchievements[playerID];
            }

            return new List<string>();
        }


        public bool HasAchievement(
            string playerID,
            string achievement)
        {
            if (playerAchievements.ContainsKey(playerID))
            {
                return playerAchievements[playerID]
                    .Contains(achievement);
            }

            return false;
        }


        public void RemovePlayer(
            string playerID)
        {
            if (playerAchievements.ContainsKey(playerID))
            {
                playerAchievements.Remove(playerID);
            }
        }
    }
}
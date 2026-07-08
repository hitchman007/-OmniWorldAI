using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerQuestSystem : MonoBehaviour
    {
        public static OmniMultiplayerQuestSystem Instance;

        private Dictionary<string, List<string>> playerQuests =
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
            if (!playerQuests.ContainsKey(playerID))
            {
                playerQuests.Add(
                    playerID,
                    new List<string>()
                );
            }
        }


        public void AddQuest(
            string playerID,
            string questID)
        {
            if (!playerQuests.ContainsKey(playerID))
            {
                RegisterPlayer(playerID);
            }

            if (!playerQuests[playerID].Contains(questID))
            {
                playerQuests[playerID].Add(questID);
            }
        }


        public void CompleteQuest(
            string playerID,
            string questID)
        {
            if (playerQuests.ContainsKey(playerID))
            {
                playerQuests[playerID].Remove(questID);

                Debug.Log(
                    "Quest completed: " + questID
                );
            }
        }


        public List<string> GetActiveQuests(
            string playerID)
        {
            if (playerQuests.ContainsKey(playerID))
            {
                return playerQuests[playerID];
            }

            return new List<string>();
        }


        public void RemovePlayer(
            string playerID)
        {
            if (playerQuests.ContainsKey(playerID))
            {
                playerQuests.Remove(playerID);
            }
        }
    }
}
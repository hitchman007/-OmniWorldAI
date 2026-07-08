using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerModerationSystem : MonoBehaviour
    {
        public static OmniMultiplayerModerationSystem Instance;

        private HashSet<string> blockedPlayers =
            new HashSet<string>();


        private List<string> moderationLogs =
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


        public void BlockPlayer(
            string playerID,
            string reason)
        {
            if (!blockedPlayers.Contains(playerID))
            {
                blockedPlayers.Add(playerID);

                string log =
                    "Blocked: " +
                    playerID +
                    " Reason: " +
                    reason;

                moderationLogs.Add(log);

                Debug.Log(log);
            }
        }


        public void UnblockPlayer(
            string playerID)
        {
            if (blockedPlayers.Contains(playerID))
            {
                blockedPlayers.Remove(playerID);

                Debug.Log(
                    "Player unblocked: " + playerID
                );
            }
        }


        public bool IsPlayerBlocked(
            string playerID)
        {
            return blockedPlayers.Contains(playerID);
        }


        public List<string> GetModerationLogs()
        {
            return moderationLogs;
        }


        public void ClearLogs()
        {
            moderationLogs.Clear();
        }
    }
}
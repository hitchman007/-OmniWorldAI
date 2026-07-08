using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerNotificationSystem : MonoBehaviour
    {
        public static OmniMultiplayerNotificationSystem Instance;

        private Dictionary<string, List<string>> notifications =
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
            if (!notifications.ContainsKey(playerID))
            {
                notifications.Add(
                    playerID,
                    new List<string>()
                );
            }
        }


        public void SendNotification(
            string playerID,
            string message)
        {
            if (!notifications.ContainsKey(playerID))
            {
                RegisterPlayer(playerID);
            }

            notifications[playerID].Add(message);

            Debug.Log(
                "Notification sent: " + message
            );
        }


        public List<string> GetNotifications(
            string playerID)
        {
            if (notifications.ContainsKey(playerID))
            {
                return notifications[playerID];
            }

            return new List<string>();
        }


        public void ClearNotifications(
            string playerID)
        {
            if (notifications.ContainsKey(playerID))
            {
                notifications[playerID].Clear();
            }
        }


        public void RemovePlayer(
            string playerID)
        {
            if (notifications.ContainsKey(playerID))
            {
                notifications.Remove(playerID);
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerFriendSystem : MonoBehaviour
    {
        public static OmniMultiplayerFriendSystem Instance;

        private Dictionary<string, List<string>> friends =
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
            if (!friends.ContainsKey(playerID))
            {
                friends.Add(
                    playerID,
                    new List<string>()
                );
            }
        }


        public void AddFriend(
            string playerID,
            string friendID)
        {
            if (!friends.ContainsKey(playerID))
            {
                RegisterPlayer(playerID);
            }


            if (!friends[playerID].Contains(friendID))
            {
                friends[playerID].Add(friendID);
            }
        }


        public void RemoveFriend(
            string playerID,
            string friendID)
        {
            if (friends.ContainsKey(playerID))
            {
                friends[playerID].Remove(friendID);
            }
        }


        public List<string> GetFriends(
            string playerID)
        {
            if (friends.ContainsKey(playerID))
            {
                return friends[playerID];
            }

            return new List<string>();
        }


        public bool IsFriend(
            string playerID,
            string friendID)
        {
            if (friends.ContainsKey(playerID))
            {
                return friends[playerID].Contains(friendID);
            }

            return false;
        }
    }
}
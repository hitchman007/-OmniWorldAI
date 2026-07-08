using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerGuildSystem : MonoBehaviour
    {
        public static OmniMultiplayerGuildSystem Instance;

        private Dictionary<string, List<string>> guilds =
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


        public void CreateGuild(string guildName)
        {
            if (!guilds.ContainsKey(guildName))
            {
                guilds.Add(
                    guildName,
                    new List<string>()
                );

                Debug.Log(
                    "Guild created: " + guildName
                );
            }
        }


        public void AddPlayerToGuild(
            string guildName,
            string playerID)
        {
            if (guilds.ContainsKey(guildName))
            {
                if (!guilds[guildName].Contains(playerID))
                {
                    guilds[guildName].Add(playerID);
                }
            }
        }


        public void RemovePlayerFromGuild(
            string guildName,
            string playerID)
        {
            if (guilds.ContainsKey(guildName))
            {
                guilds[guildName].Remove(playerID);
            }
        }


        public List<string> GetGuildMembers(
            string guildName)
        {
            if (guilds.ContainsKey(guildName))
            {
                return guilds[guildName];
            }

            return new List<string>();
        }


        public void DeleteGuild(
            string guildName)
        {
            if (guilds.ContainsKey(guildName))
            {
                guilds.Remove(guildName);

                Debug.Log(
                    "Guild deleted: " + guildName
                );
            }
        }
    }
}
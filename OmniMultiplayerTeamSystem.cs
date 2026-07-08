using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerTeamSystem : MonoBehaviour
    {
        public static OmniMultiplayerTeamSystem Instance;

        private Dictionary<string, string> playerTeams =
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


        public void AssignTeam(
            string playerID,
            string teamName)
        {
            if (playerTeams.ContainsKey(playerID))
            {
                playerTeams[playerID] = teamName;
            }
            else
            {
                playerTeams.Add(playerID, teamName);
            }

            Debug.Log(
                playerID + " assigned to team " + teamName
            );
        }


        public string GetTeam(
            string playerID)
        {
            if (playerTeams.ContainsKey(playerID))
            {
                return playerTeams[playerID];
            }

            return "No Team";
        }


        public void RemovePlayer(
            string playerID)
        {
            if (playerTeams.ContainsKey(playerID))
            {
                playerTeams.Remove(playerID);
            }
        }


        public Dictionary<string, string> GetAllTeams()
        {
            return playerTeams;
        }
    }
}
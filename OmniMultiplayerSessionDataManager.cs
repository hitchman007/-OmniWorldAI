using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerSessionDataManager : MonoBehaviour
    {
        public static OmniMultiplayerSessionDataManager Instance;

        private Dictionary<string, OmniMultiplayerSessionData> sessions =
            new Dictionary<string, OmniMultiplayerSessionData>();


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


        public void CreateSession(
            string sessionID,
            string worldID,
            string hostPlayerID)
        {
            if (!sessions.ContainsKey(sessionID))
            {
                OmniMultiplayerSessionData session =
                    new OmniMultiplayerSessionData(
                        sessionID,
                        worldID,
                        hostPlayerID
                    );

                sessions.Add(sessionID, session);

                Debug.Log("Session created: " + sessionID);
            }
        }


        public void AddPlayerToSession(
            string sessionID,
            string playerID)
        {
            if (sessions.ContainsKey(sessionID))
            {
                sessions[sessionID].AddPlayer(playerID);
            }
        }


        public void RemovePlayerFromSession(
            string sessionID,
            string playerID)
        {
            if (sessions.ContainsKey(sessionID))
            {
                sessions[sessionID].RemovePlayer(playerID);
            }
        }


        public OmniMultiplayerSessionData GetSession(
            string sessionID)
        {
            if (sessions.ContainsKey(sessionID))
            {
                return sessions[sessionID];
            }

            return null;
        }


        public void DeleteSession(
            string sessionID)
        {
            if (sessions.ContainsKey(sessionID))
            {
                sessions.Remove(sessionID);

                Debug.Log("Session deleted: " + sessionID);
            }
        }
    }
}
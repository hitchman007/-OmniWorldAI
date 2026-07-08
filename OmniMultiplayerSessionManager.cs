using System;
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerSessionManager : MonoBehaviour
    {
        public static OmniMultiplayerSessionManager Instance;

        public string SessionID { get; private set; }
        public bool IsSessionActive { get; private set; }

        private List<string> connectedPlayers = new List<string>();

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

        public void CreateSession()
        {
            SessionID = Guid.NewGuid().ToString();

            IsSessionActive = true;

            Debug.Log("OmniWorld AI Multiplayer Session Created: " + SessionID);
        }

        public void JoinSession(string playerID)
        {
            if (!IsSessionActive)
            {
                Debug.Log("No active session found.");
                return;
            }

            if (!connectedPlayers.Contains(playerID))
            {
                connectedPlayers.Add(playerID);
                Debug.Log("Player joined: " + playerID);
            }
        }

        public void LeaveSession(string playerID)
        {
            if (connectedPlayers.Contains(playerID))
            {
                connectedPlayers.Remove(playerID);
                Debug.Log("Player left: " + playerID);
            }
        }

        public List<string> GetPlayers()
        {
            return connectedPlayers;
        }

        public void EndSession()
        {
            connectedPlayers.Clear();

            SessionID = null;
            IsSessionActive = false;

            Debug.Log("Multiplayer session ended.");
        }
    }
}
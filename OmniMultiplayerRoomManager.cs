using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerRoomManager : MonoBehaviour
    {
        public static OmniMultiplayerRoomManager Instance;

        private Dictionary<string, List<string>> rooms =
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


        public void CreateRoom(string roomID)
        {
            if (!rooms.ContainsKey(roomID))
            {
                rooms.Add(roomID, new List<string>());

                Debug.Log("Room created: " + roomID);
            }
        }


        public void JoinRoom(string roomID, string playerID)
        {
            if (rooms.ContainsKey(roomID))
            {
                if (!rooms[roomID].Contains(playerID))
                {
                    rooms[roomID].Add(playerID);

                    Debug.Log(playerID + " joined room " + roomID);
                }
            }
        }


        public void LeaveRoom(string roomID, string playerID)
        {
            if (rooms.ContainsKey(roomID))
            {
                rooms[roomID].Remove(playerID);

                Debug.Log(playerID + " left room " + roomID);
            }
        }


        public List<string> GetRoomPlayers(string roomID)
        {
            if (rooms.ContainsKey(roomID))
            {
                return rooms[roomID];
            }

            return new List<string>();
        }


        public void DeleteRoom(string roomID)
        {
            if (rooms.ContainsKey(roomID))
            {
                rooms.Remove(roomID);

                Debug.Log("Room deleted: " + roomID);
            }
        }
    }
}
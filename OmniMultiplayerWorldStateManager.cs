using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerWorldStateManager : MonoBehaviour
    {
        public static OmniMultiplayerWorldStateManager Instance;

        private Dictionary<string, OmniMultiplayerWorldState> worlds =
            new Dictionary<string, OmniMultiplayerWorldState>();


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


        public void CreateWorldState(
            string worldID,
            string worldName)
        {
            if (!worlds.ContainsKey(worldID))
            {
                OmniMultiplayerWorldState state =
                    new OmniMultiplayerWorldState(
                        worldID,
                        worldName
                    );

                worlds.Add(worldID, state);

                Debug.Log("World state created: " + worldID);
            }
        }


        public void AddPlayerToWorld(
            string worldID,
            string playerID)
        {
            if (worlds.ContainsKey(worldID))
            {
                worlds[worldID].AddPlayer(playerID);
            }
        }


        public void RemovePlayerFromWorld(
            string worldID,
            string playerID)
        {
            if (worlds.ContainsKey(worldID))
            {
                worlds[worldID].RemovePlayer(playerID);
            }
        }


        public OmniMultiplayerWorldState GetWorldState(
            string worldID)
        {
            if (worlds.ContainsKey(worldID))
            {
                return worlds[worldID];
            }

            return null;
        }


        public void DeleteWorldState(string worldID)
        {
            if (worlds.ContainsKey(worldID))
            {
                worlds.Remove(worldID);

                Debug.Log("World state deleted: " + worldID);
            }
        }
    }
}
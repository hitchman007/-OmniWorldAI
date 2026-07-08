using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerPlayerRegistry : MonoBehaviour
    {
        public static OmniMultiplayerPlayerRegistry Instance;

        private Dictionary<string, OmniPlayerNetworkIdentity> players =
            new Dictionary<string, OmniPlayerNetworkIdentity>();


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


        public void RegisterPlayer(OmniPlayerNetworkIdentity player)
        {
            if (player == null)
                return;

            string id = player.GetPlayerID();

            if (!players.ContainsKey(id))
            {
                players.Add(id, player);

                Debug.Log("Player registered: " + id);
            }
        }


        public void RemovePlayer(string playerID)
        {
            if (players.ContainsKey(playerID))
            {
                players.Remove(playerID);

                Debug.Log("Player removed: " + playerID);
            }
        }


        public OmniPlayerNetworkIdentity GetPlayer(string playerID)
        {
            if (players.ContainsKey(playerID))
            {
                return players[playerID];
            }

            return null;
        }


        public List<OmniPlayerNetworkIdentity> GetAllPlayers()
        {
            return new List<OmniPlayerNetworkIdentity>(players.Values);
        }


        public int GetPlayerCount()
        {
            return players.Count;
        }
    }
}
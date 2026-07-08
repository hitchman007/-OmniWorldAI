using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerTradeSystem : MonoBehaviour
    {
        public static OmniMultiplayerTradeSystem Instance;

        private Dictionary<string, int> playerCurrencies =
            new Dictionary<string, int>();


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
            if (!playerCurrencies.ContainsKey(playerID))
            {
                playerCurrencies.Add(playerID, 0);
            }
        }


        public void AddCurrency(
            string playerID,
            int amount)
        {
            if (!playerCurrencies.ContainsKey(playerID))
            {
                RegisterPlayer(playerID);
            }

            playerCurrencies[playerID] += amount;
        }


        public bool TradeCurrency(
            string fromPlayer,
            string toPlayer,
            int amount)
        {
            if (!playerCurrencies.ContainsKey(fromPlayer) ||
                !playerCurrencies.ContainsKey(toPlayer))
            {
                return false;
            }


            if (playerCurrencies[fromPlayer] < amount)
            {
                return false;
            }


            playerCurrencies[fromPlayer] -= amount;
            playerCurrencies[toPlayer] += amount;


            Debug.Log(
                "Trade completed: " +
                fromPlayer +
                " -> " +
                toPlayer
            );


            return true;
        }


        public int GetCurrency(
            string playerID)
        {
            if (playerCurrencies.ContainsKey(playerID))
            {
                return playerCurrencies[playerID];
            }

            return 0;
        }
    }
}
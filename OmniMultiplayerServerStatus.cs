using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerServerStatus : MonoBehaviour
    {
        public static OmniMultiplayerServerStatus Instance;

        public bool ServerOnline { get; private set; }

        public int ConnectedPlayers { get; private set; }


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


        public void StartServer()
        {
            ServerOnline = true;

            ConnectedPlayers = 0;

            Debug.Log(
                "OmniWorld AI Server Started"
            );
        }


        public void StopServer()
        {
            ServerOnline = false;

            ConnectedPlayers = 0;

            Debug.Log(
                "OmniWorld AI Server Stopped"
            );
        }


        public void PlayerConnected()
        {
            if (ServerOnline)
            {
                ConnectedPlayers++;
            }
        }


        public void PlayerDisconnected()
        {
            if (ConnectedPlayers > 0)
            {
                ConnectedPlayers--;
            }
        }


        public bool IsServerOnline()
        {
            return ServerOnline;
        }


        public int GetConnectedPlayers()
        {
            return ConnectedPlayers;
        }
    }
}
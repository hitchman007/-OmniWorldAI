using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniPlayerStateSync : MonoBehaviour
    {
        public string PlayerID { get; private set; }

        public Vector3 CurrentPosition { get; private set; }

        public Vector3 CurrentRotation { get; private set; }


        private void Start()
        {
            PlayerID = System.Guid.NewGuid().ToString();
        }


        private void Update()
        {
            SyncLocalState();
        }


        private void SyncLocalState()
        {
            CurrentPosition = transform.position;

            CurrentRotation = transform.eulerAngles;

            if (OmniMultiplayerWorldSync.Instance != null)
            {
                OmniMultiplayerWorldSync.Instance.UpdatePlayerPosition(
                    PlayerID,
                    CurrentPosition
                );
            }
        }


        public void ApplyRemotePosition(Vector3 position)
        {
            transform.position = position;
        }


        public void ApplyRemoteRotation(Vector3 rotation)
        {
            transform.eulerAngles = rotation;
        }


        public string GetPlayerID()
        {
            return PlayerID;
        }
    }
}
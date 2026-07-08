using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerNetworkStats : MonoBehaviour
    {
        public static OmniMultiplayerNetworkStats Instance;

        private int sentPackets;

        private int receivedPackets;

        private float dataSent;

        private float dataReceived;


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


        public void RegisterSentPacket(
            float size)
        {
            sentPackets++;

            dataSent += size;
        }


        public void RegisterReceivedPacket(
            float size)
        {
            receivedPackets++;

            dataReceived += size;
        }


        public int GetSentPackets()
        {
            return sentPackets;
        }


        public int GetReceivedPackets()
        {
            return receivedPackets;
        }


        public float GetDataSent()
        {
            return dataSent;
        }


        public float GetDataReceived()
        {
            return dataReceived;
        }


        public void ResetStats()
        {
            sentPackets = 0;

            receivedPackets = 0;

            dataSent = 0;

            dataReceived = 0;
        }
    }
}
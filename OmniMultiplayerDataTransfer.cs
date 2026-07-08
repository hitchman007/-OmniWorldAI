using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerDataTransfer : MonoBehaviour
    {
        public static OmniMultiplayerDataTransfer Instance;

        private Queue<OmniMultiplayerDataPacket> dataQueue =
            new Queue<OmniMultiplayerDataPacket>();


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


        public void SendData(OmniMultiplayerDataPacket packet)
        {
            if (packet == null)
                return;

            dataQueue.Enqueue(packet);

            Debug.Log("Data packet sent: " + packet.GetPacketInfo());
        }


        public OmniMultiplayerDataPacket ReceiveData()
        {
            if (dataQueue.Count > 0)
            {
                return dataQueue.Dequeue();
            }

            return null;
        }


        public int GetPendingPackets()
        {
            return dataQueue.Count;
        }


        public void ClearQueue()
        {
            dataQueue.Clear();
        }
    }
}
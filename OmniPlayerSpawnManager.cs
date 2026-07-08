using UnityEngine;
using System.Collections.Generic;

namespace OmniWorldAI.Multiplayer
{
    public class OmniPlayerSpawnManager : MonoBehaviour
    {
        public static OmniPlayerSpawnManager Instance;

        public Transform[] spawnPoints;

        private List<string> usedSpawnPoints = new List<string>();


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


        public Vector3 GetSpawnPosition(string playerID)
        {
            if (spawnPoints == null || spawnPoints.Length == 0)
            {
                return Vector3.zero;
            }

            int index = Mathf.Abs(playerID.GetHashCode()) % spawnPoints.Length;

            usedSpawnPoints.Add(playerID);

            return spawnPoints[index].position;
        }


        public void RemovePlayerSpawn(string playerID)
        {
            if (usedSpawnPoints.Contains(playerID))
            {
                usedSpawnPoints.Remove(playerID);
            }
        }


        public void ResetSpawnPoints()
        {
            usedSpawnPoints.Clear();
        }
    }
}
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerPlayerSpawner : MonoBehaviour
    {
        public static OmniMultiplayerPlayerSpawner Instance;

        public GameObject playerPrefab;

        public Transform defaultSpawnPoint;


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


        public GameObject SpawnPlayer(string playerID)
        {
            if (playerPrefab == null)
            {
                Debug.LogWarning("Player prefab missing.");
                return null;
            }


            Vector3 spawnPosition = Vector3.zero;

            if (defaultSpawnPoint != null)
            {
                spawnPosition = defaultSpawnPoint.position;
            }


            GameObject player =
                Instantiate(
                    playerPrefab,
                    spawnPosition,
                    Quaternion.identity
                );


            OmniPlayerNetworkIdentity identity =
                player.GetComponent<OmniPlayerNetworkIdentity>();


            if (identity != null)
            {
                identity.ConnectPlayer();
            }


            Debug.Log("Player spawned: " + playerID);

            return player;
        }


        public void RemovePlayer(GameObject player)
        {
            if (player != null)
            {
                Destroy(player);
            }
        }
    }
}
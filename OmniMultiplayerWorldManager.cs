using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerWorldManager : MonoBehaviour
    {
        public static OmniMultiplayerWorldManager Instance;

        public string CurrentWorldID { get; private set; }

        public bool WorldActive { get; private set; }


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


        public void LoadWorld(string worldID)
        {
            CurrentWorldID = worldID;

            WorldActive = true;

            Debug.Log("Multiplayer world loaded: " + worldID);
        }


        public void UnloadWorld()
        {
            CurrentWorldID = null;

            WorldActive = false;

            Debug.Log("Multiplayer world unloaded.");
        }


        public bool IsWorldActive()
        {
            return WorldActive;
        }


        public string GetCurrentWorld()
        {
            return CurrentWorldID;
        }
    }
}
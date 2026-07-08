using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Core
{
    public class OmniWorldAIPathfindingSystem : MonoBehaviour
    {
        public static OmniWorldAIPathfindingSystem Instance;

        private Dictionary<string, List<Vector3>> paths =
            new Dictionary<string, List<Vector3>>();


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


        public void CreatePath(
            string entityID,
            List<Vector3> points)
        {
            if (paths.ContainsKey(entityID))
            {
                paths[entityID] = points;
            }
            else
            {
                paths.Add(
                    entityID,
                    points
                );
            }
        }


        public List<Vector3> GetPath(
            string entityID)
        {
            if (paths.ContainsKey(entityID))
            {
                return paths[entityID];
            }

            return new List<Vector3>();
        }


        public void AddPoint(
            string entityID,
            Vector3 point)
        {
            if (paths.ContainsKey(entityID))
            {
                paths[entityID].Add(point);
            }
        }


        public void RemovePath(
            string entityID)
        {
            if (paths.ContainsKey(entityID))
            {
                paths.Remove(entityID);
            }
        }


        public int GetPathCount()
        {
            return paths.Count;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace OmniWorldAI.Multiplayer
{
    public class OmniMultiplayerReportSystem : MonoBehaviour
    {
        public static OmniMultiplayerReportSystem Instance;

        private List<string> reports =
            new List<string>();


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


        public void CreateReport(
            string reporterID,
            string targetID,
            string reason)
        {
            string report =
                reporterID +
                " reported " +
                targetID +
                " : " +
                reason;


            reports.Add(report);

            Debug.Log(
                "Report created: " + report
            );
        }


        public List<string> GetReports()
        {
            return reports;
        }


        public int GetReportCount()
        {
            return reports.Count;
        }


        public void RemoveReport(
            string report)
        {
            if (reports.Contains(report))
            {
                reports.Remove(report);
            }
        }


        public void ClearReports()
        {
            reports.Clear();
        }
    }
}
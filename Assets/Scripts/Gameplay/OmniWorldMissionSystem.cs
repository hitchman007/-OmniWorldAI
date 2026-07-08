using UnityEngine;
using System.Collections.Generic;

public class OmniWorldMissionSystem : MonoBehaviour
{
    public List<string> activeMissions = new List<string>();
    public int completedMissions = 0;

    void Start()
    {
        LoadDefaultMissions();
    }

    void LoadDefaultMissions()
    {
        activeMissions.Add("Explore Unknown Dimension");
        activeMissions.Add("Restore AI Core");
        activeMissions.Add("Create New Civilization");

        Debug.Log("Mission System Activated");
    }

    public void AddMission(string missionName)
    {
        activeMissions.Add(missionName);

        Debug.Log("Mission Added: " + missionName);
    }

    public void CompleteMission(string missionName)
    {
        if (activeMissions.Contains(missionName))
        {
            activeMissions.Remove(missionName);
            completedMissions++;

            Debug.Log("Mission Completed: " + missionName);
        }
    }

    public int GetActiveMissionCount()
    {
        return activeMissions.Count;
    }

    public int GetCompletedMissionCount()
    {
        return completedMissions;
    }
}
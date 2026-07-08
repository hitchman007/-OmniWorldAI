using UnityEngine;
using System.Collections.Generic;

public class OmniWorldPlayerProgressSystem : MonoBehaviour
{
    public int totalProgress = 0;

    public List<string> completedTasks =
        new List<string>();

    void Start()
    {
        InitializeProgress();
    }

    void InitializeProgress()
    {
        Debug.Log(
            "Player Progress System Activated"
        );
    }

    public void CompleteTask(string taskName, int points)
    {
        if (!completedTasks.Contains(taskName))
        {
            completedTasks.Add(taskName);

            totalProgress += points;

            Debug.Log(
                "Task Completed: " +
                taskName
            );
        }
    }

    public bool HasCompleted(string taskName)
    {
        return completedTasks.Contains(taskName);
    }

    public int GetProgress()
    {
        return totalProgress;
    }

    public int GetCompletedTaskCount()
    {
        return completedTasks.Count;
    }
}
using UnityEngine;
using System.Collections.Generic;

public class OmniWorldNotificationSystem : MonoBehaviour
{
    public List<string> notifications = new List<string>();

    public int maxNotifications = 50;

    void Start()
    {
        AddNotification("Welcome to OmniWorld AI");
    }

    public void AddNotification(string message)
    {
        notifications.Add(message);

        if (notifications.Count > maxNotifications)
        {
            notifications.RemoveAt(0);
        }

        Debug.Log("Notification: " + message);
    }

    public void ClearNotifications()
    {
        notifications.Clear();

        Debug.Log("Notifications Cleared");
    }

    public string GetLatestNotification()
    {
        if (notifications.Count > 0)
        {
            return notifications[notifications.Count - 1];
        }

        return "No Notifications";
    }

    public int GetNotificationCount()
    {
        return notifications.Count;
    }
}
using UnityEngine;
using System.Collections.Generic;

public class OmniWorldNotificationManager : MonoBehaviour
{
    public List<string> notifications = new List<string>();

    public int unreadCount = 0;

    void Start()
    {
        Debug.Log("Notification Manager Activated");
    }

    public void SendNotification(string message)
    {
        notifications.Add(message);
        unreadCount++;

        Debug.Log(
            "New Notification: " + message
        );
    }

    public void ReadNotifications()
    {
        unreadCount = 0;

        Debug.Log("Notifications Read");
    }

    public string GetLatestNotification()
    {
        if (notifications.Count > 0)
        {
            return notifications[notifications.Count - 1];
        }

        return "No Notifications";
    }

    public int GetUnreadCount()
    {
        return unreadCount;
    }
}
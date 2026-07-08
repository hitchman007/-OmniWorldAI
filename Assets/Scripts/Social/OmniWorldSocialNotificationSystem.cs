using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OmniWorldSocialNotification
{
    public string message;
    public string senderName;
    public string notificationType;
    public bool isRead;

    public OmniWorldSocialNotification(
        string newMessage,
        string sender,
        string type
    )
    {
        message = newMessage;
        senderName = sender;
        notificationType = type;
        isRead = false;
    }
}

public class OmniWorldSocialNotificationSystem : MonoBehaviour
{
    [Header("Social Notifications")]
    public List<OmniWorldSocialNotification> notifications =
        new List<OmniWorldSocialNotification>();

    public int maxNotifications = 50;

    private void Start()
    {
        Debug.Log("OmniWorld Social Notification System initialized.");
    }

    public void AddNotification(
        string message,
        string senderName,
        string notificationType
    )
    {
        if (string.IsNullOrEmpty(message))
        {
            return;
        }

        notifications.Add(
            new OmniWorldSocialNotification(
                message,
                senderName,
                notificationType
            )
        );

        LimitNotifications();

        Debug.Log("New social notification: " + message);
    }

    public int GetUnreadCount()
    {
        int unreadCount = 0;

        foreach (OmniWorldSocialNotification notification in notifications)
        {
            if (!notification.isRead)
            {
                unreadCount++;
            }
        }

        return unreadCount;
    }

    public void MarkAllAsRead()
    {
        foreach (OmniWorldSocialNotification notification in notifications)
        {
            notification.isRead = true;
        }

        Debug.Log("All social notifications marked as read.");
    }

    public void ClearNotifications()
    {
        notifications.Clear();
        Debug.Log("Social notifications cleared.");
    }

    private void LimitNotifications()
    {
        while (notifications.Count > maxNotifications)
        {
            notifications.RemoveAt(0);
        }
    }
}
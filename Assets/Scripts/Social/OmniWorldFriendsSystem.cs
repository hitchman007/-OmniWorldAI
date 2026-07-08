using System.Collections.Generic;
using UnityEngine;

public class OmniWorldFriendsSystem : MonoBehaviour
{
    [Header("Friends System")]
    public List<string> friendsList = new List<string>();
    public List<string> pendingFriendRequests = new List<string>();

    public int TotalFriends
    {
        get { return friendsList.Count; }
    }

    private void Start()
    {
        Debug.Log("OmniWorld Friends System initialized.");
    }

    public void SendFriendRequest(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Friend request failed: player name is empty.");
            return;
        }

        Debug.Log("Friend request sent to: " + playerName);
    }

    public void ReceiveFriendRequest(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            return;
        }

        if (!pendingFriendRequests.Contains(playerName))
        {
            pendingFriendRequests.Add(playerName);
            Debug.Log("Friend request received from: " + playerName);
        }
    }

    public void AcceptFriendRequest(string playerName)
    {
        if (pendingFriendRequests.Contains(playerName))
        {
            pendingFriendRequests.Remove(playerName);

            if (!friendsList.Contains(playerName))
            {
                friendsList.Add(playerName);
            }

            Debug.Log(playerName + " is now your friend.");
        }
    }

    public void RemoveFriend(string playerName)
    {
        if (friendsList.Contains(playerName))
        {
            friendsList.Remove(playerName);
            Debug.Log(playerName + " was removed from friends.");
        }
    }

    public bool IsFriend(string playerName)
    {
        return friendsList.Contains(playerName);
    }
}
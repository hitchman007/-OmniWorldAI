using UnityEngine;
using System.Collections.Generic;

public class OmniWorldFriendSystem : MonoBehaviour
{
    public List<string> friends = new List<string>();

    void Start()
    {
        InitializeFriends();
    }

    void InitializeFriends()
    {
        friends.Add("Explorer_AI");
        friends.Add("Builder_AI");

        Debug.Log("Friend System Activated");
    }

    public void AddFriend(string friendName)
    {
        if (!friends.Contains(friendName))
        {
            friends.Add(friendName);

            Debug.Log("Friend Added: " + friendName);
        }
    }

    public void RemoveFriend(string friendName)
    {
        if (friends.Contains(friendName))
        {
            friends.Remove(friendName);

            Debug.Log("Friend Removed: " + friendName);
        }
    }

    public bool IsFriend(string friendName)
    {
        return friends.Contains(friendName);
    }

    public int GetFriendCount()
    {
        return friends.Count;
    }
}
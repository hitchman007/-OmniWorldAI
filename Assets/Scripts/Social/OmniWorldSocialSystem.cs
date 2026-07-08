using UnityEngine;
using System.Collections.Generic;

public class OmniWorldSocialSystem : MonoBehaviour
{
    public List<string> followers =
        new List<string>();

    public List<string> following =
        new List<string>();

    void Start()
    {
        InitializeSocial();
    }

    void InitializeSocial()
    {
        Debug.Log(
            "Social System Activated"
        );
    }

    public void FollowPlayer(string playerName)
    {
        if (!following.Contains(playerName))
        {
            following.Add(playerName);

            Debug.Log(
                "Following: " +
                playerName
            );
        }
    }

    public void AddFollower(string playerName)
    {
        if (!followers.Contains(playerName))
        {
            followers.Add(playerName);

            Debug.Log(
                "New Follower: " +
                playerName
            );
        }
    }

    public bool IsFollowing(string playerName)
    {
        return following.Contains(playerName);
    }

    public int GetFollowerCount()
    {
        return followers.Count;
    }
}
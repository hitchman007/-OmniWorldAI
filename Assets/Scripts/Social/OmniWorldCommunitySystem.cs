using UnityEngine;
using System.Collections.Generic;

public class OmniWorldCommunitySystem : MonoBehaviour
{
    public List<string> communities =
        new List<string>();

    public int members = 0;

    void Start()
    {
        InitializeCommunity();
    }

    void InitializeCommunity()
    {
        communities.Add("OmniWorld Creators");

        Debug.Log(
            "Community System Activated"
        );
    }

    public void CreateCommunity(string name)
    {
        if (!communities.Contains(name))
        {
            communities.Add(name);

            Debug.Log(
                "Community Created: " +
                name
            );
        }
    }

    public void AddMember()
    {
        members++;

        Debug.Log(
            "Community Members: " +
            members
        );
    }

    public bool HasCommunity(string name)
    {
        return communities.Contains(name);
    }

    public int GetCommunityCount()
    {
        return communities.Count;
    }
}
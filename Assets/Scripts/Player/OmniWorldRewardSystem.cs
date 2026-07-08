using UnityEngine;
using System.Collections.Generic;

public class OmniWorldRewardSystem : MonoBehaviour
{
    public int totalRewards = 0;

    public List<string> rewards =
        new List<string>();

    void Start()
    {
        InitializeRewards();
    }

    void InitializeRewards()
    {
        rewards.Add("Welcome Reward");

        Debug.Log(
            "Reward System Activated"
        );
    }

    public void GiveReward(string rewardName, int points)
    {
        rewards.Add(rewardName);

        totalRewards += points;

        Debug.Log(
            "Reward Received: " +
            rewardName +
            " +" +
            points
        );
    }

    public bool HasReward(string rewardName)
    {
        return rewards.Contains(rewardName);
    }

    public int GetTotalRewards()
    {
        return totalRewards;
    }

    public int GetRewardCount()
    {
        return rewards.Count;
    }
}
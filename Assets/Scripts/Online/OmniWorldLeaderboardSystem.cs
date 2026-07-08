using UnityEngine;
using System.Collections.Generic;

public class OmniWorldLeaderboardSystem : MonoBehaviour
{
    public Dictionary<string, int> leaderboard =
        new Dictionary<string, int>();

    void Start()
    {
        InitializeLeaderboard();
    }

    void InitializeLeaderboard()
    {
        leaderboard.Add("Creator_001", 1000);
        leaderboard.Add("Explorer_001", 750);
        leaderboard.Add("Builder_001", 500);

        Debug.Log("Leaderboard System Activated");
    }

    public void AddPlayerScore(string playerName, int score)
    {
        if (leaderboard.ContainsKey(playerName))
        {
            leaderboard[playerName] += score;
        }
        else
        {
            leaderboard.Add(playerName, score);
        }

        Debug.Log("Score Updated: " + playerName);
    }

    public int GetPlayerScore(string playerName)
    {
        if (leaderboard.ContainsKey(playerName))
        {
            return leaderboard[playerName];
        }

        return 0;
    }

    public int GetPlayerCount()
    {
        return leaderboard.Count;
    }
}
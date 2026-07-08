using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OmniWorldLeaderboardEntry
{
    public string playerName;
    public int score;

    public OmniWorldLeaderboardEntry(string name, int playerScore)
    {
        playerName = name;
        score = playerScore;
    }
}

public class OmniWorldLeaderboardSystem : MonoBehaviour
{
    [Header("Leaderboard System")]
    public List<OmniWorldLeaderboardEntry> leaderboard =
        new List<OmniWorldLeaderboardEntry>();

    public int maxEntries = 100;

    private void Start()
    {
        Debug.Log("OmniWorld Leaderboard System initialized.");
    }

    public void SubmitScore(string playerName, int newScore)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Score submission failed: player name is empty.");
            return;
        }

        OmniWorldLeaderboardEntry existingEntry =
            leaderboard.Find(entry => entry.playerName == playerName);

        if (existingEntry != null)
        {
            if (newScore > existingEntry.score)
            {
                existingEntry.score = newScore;
            }
        }
        else
        {
            leaderboard.Add(
                new OmniWorldLeaderboardEntry(playerName, newScore)
            );
        }

        SortLeaderboard();
        LimitEntries();

        Debug.Log("Score submitted for: " + playerName);
    }

    public OmniWorldLeaderboardEntry GetTopPlayer()
    {
        if (leaderboard.Count == 0)
        {
            return null;
        }

        return leaderboard[0];
    }

    public void SortLeaderboard()
    {
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score));
    }

    public void LimitEntries()
    {
        if (leaderboard.Count > maxEntries)
        {
            leaderboard.RemoveRange(
                maxEntries,
                leaderboard.Count - maxEntries
            );
        }
    }

    public int GetPlayerRank(string playerName)
    {
        for (int i = 0; i < leaderboard.Count; i++)
        {
            if (leaderboard[i].playerName == playerName)
            {
                return i + 1;
            }
        }

        return -1;
    }
}
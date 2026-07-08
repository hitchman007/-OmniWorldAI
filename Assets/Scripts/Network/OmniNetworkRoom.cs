using System.Collections.Generic;
using UnityEngine;

public class OmniNetworkRoom : MonoBehaviour
{
    public string roomId;
    public string roomName = "OmniWorld Room";
    public int maxPlayers = 20;
    public bool isPrivateRoom;

    private readonly List<OmniNetworkPlayer> players = new();

    public int PlayerCount => players.Count;
    public bool IsFull => players.Count >= maxPlayers;

    public bool AddPlayer(OmniNetworkPlayer player)
    {
        if (player == null || IsFull || players.Contains(player))
        {
            return false;
        }

        players.Add(player);
        Debug.Log(player.playerName + " joined room: " + roomName);
        return true;
    }

    public bool RemovePlayer(OmniNetworkPlayer player)
    {
        if (player == null || !players.Remove(player))
        {
            return false;
        }

        Debug.Log(player.playerName + " left room: " + roomName);
        return true;
    }

    public bool CanJoinRoom()
    {
        return !IsFull;
    }

    public void CloseRoom()
    {
        players.Clear();
        Debug.Log("Room closed: " + roomName);
    }
}
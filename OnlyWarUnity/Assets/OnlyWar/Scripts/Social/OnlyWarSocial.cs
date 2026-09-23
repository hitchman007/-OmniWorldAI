using System;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  [Serializable] public sealed class OnlyWarFriend {
    public string playerId;
    public string displayName;
    public bool online;
  }

  [Serializable] public sealed class OnlyWarClan {
    public string clanId;
    public string name;
    public string tag;
    public int level;
    public int warPoints;
    public List<string> members = new();
  }

  public sealed class OnlyWarSocial : MonoBehaviour {
    public List<OnlyWarFriend> friends = new();
    public OnlyWarClan clan;
    public event Action<string> OnPartyInvite;

    public void Invite(string playerId) => OnPartyInvite?.Invoke(playerId);
    public bool IsFriend(string playerId) => friends.Exists(f => f.playerId == playerId);
  }
}

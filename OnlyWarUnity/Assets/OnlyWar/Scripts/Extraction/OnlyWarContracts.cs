using System;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public enum ContractType { Bounty, SecureIntel, CrackSafe, DestroySupplies, Rescue, MostWanted, HighValueTarget }

  [Serializable] public sealed class OnlyWarContract {
    public string id;
    public ContractType type;
    public string title;
    public int cashReward;
    public float timeLimit = 300f;
    public float progress;
    public bool active;
    public bool complete;
  }

  public sealed class OnlyWarContractSystem : MonoBehaviour {
    public List<OnlyWarContract> contracts = new();
    public OnlyWarContract active;
    public System.Action<OnlyWarContract> onAccepted, onCompleted;

    public bool Accept(string id) {
      if (active != null && active.active && !active.complete) return false;
      active = contracts.Find(x => x.id == id);
      if (active == null) return false;
      active.active=true; active.progress=0; active.complete=false; onAccepted?.Invoke(active); return true;
    }

    public void Progress(float amount) {
      if (active == null || !active.active || active.complete) return;
      active.progress = Mathf.Clamp01(active.progress + amount);
      if (active.progress >= 1f) { active.complete=true; active.active=false; onCompleted?.Invoke(active); }
    }
  }
}

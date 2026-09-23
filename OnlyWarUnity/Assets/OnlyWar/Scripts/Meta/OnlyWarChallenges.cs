using System;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public enum ChallengeMetric { Kills, Headshots, Wins, Captures, Extractions, VehicleKills, Revives }

  [Serializable] public sealed class OnlyWarChallenge {
    public string id;
    public string title;
    public ChallengeMetric metric;
    public int target;
    public int progress;
    public int xpReward;
    public int creditReward;
    public bool complete;
  }

  public sealed class OnlyWarChallengeSystem : MonoBehaviour {
    public List<OnlyWarChallenge> daily=new();
    public List<OnlyWarChallenge> seasonal=new();
    public OnlyWarProgression progression;
    public OnlyWarCosmeticInventory cosmetics;

    public void Add(ChallengeMetric metric,int amount=1){
      Apply(daily,metric,amount);Apply(seasonal,metric,amount);
    }
    void Apply(List<OnlyWarChallenge> list,ChallengeMetric metric,int amount){
      foreach(var c in list){
        if(c.complete||c.metric!=metric)continue;c.progress=Mathf.Min(c.target,c.progress+amount);
        if(c.progress>=c.target){c.complete=true;progression?.AddXP(c.xpReward);if(cosmetics)cosmetics.credits+=c.creditReward;}
      }
    }
  }
}

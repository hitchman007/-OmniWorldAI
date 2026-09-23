using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarFreeForAll : MonoBehaviour {
    public int scoreLimit=30;
    readonly Dictionary<OnlyWarDamageable,int> scores=new();
    public void RegisterKill(OnlyWarDamageable killer){
      if(!killer)return;
      if(!scores.ContainsKey(killer))scores[killer]=0;
      scores[killer]++;
      if(scores[killer]>=scoreLimit&&OnlyWarGame.I)OnlyWarGame.I.matchLive=false;
    }
    public int Score(OnlyWarDamageable p)=>p!=null&&scores.TryGetValue(p,out var v)?v:0;
  }
}

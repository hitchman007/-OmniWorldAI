using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarControlMode : MonoBehaviour {
    public OnlyWarObjectivePoint[] zones;
    public int teamATickets=30;
    public int teamBTickets=30;
    public int round;
    public int roundsToWin=3;
    public int roundsA,roundsB;

    public void OnDeath(int team){
      if(team==0)teamATickets=Mathf.Max(0,teamATickets-1);else teamBTickets=Mathf.Max(0,teamBTickets-1);
      CheckRound();
    }

    void Update(){
      var g=OnlyWarGame.I;if(!g||g.mode!=GameMode.Control)return;
      bool allA=true,allB=true;
      foreach(var z in zones){if(!z)continue;allA&=z.owner==0;allB&=z.owner==1;}
      if(allA)WinRound(0);else if(allB)WinRound(1);
      g.hud?.SetObjective($"CONTROL · TICKETS {teamATickets} — {teamBTickets}");
    }

    void CheckRound(){if(teamATickets<=0)WinRound(1);else if(teamBTickets<=0)WinRound(0);}
    void WinRound(int team){
      if(team==0)roundsA++;else roundsB++;
      if(roundsA>=roundsToWin||roundsB>=roundsToWin){OnlyWarGame.I.matchLive=false;enabled=false;return;}
      round++;teamATickets=teamBTickets=30;
      foreach(var z in zones){if(!z)continue;z.owner=-1;z.progress=0;}
    }
  }
}

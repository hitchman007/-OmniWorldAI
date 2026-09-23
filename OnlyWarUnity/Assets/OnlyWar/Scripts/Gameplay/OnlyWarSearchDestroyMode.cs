using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarSearchDestroyMode : MonoBehaviour {
    public int roundToWin=6;
    public float roundSeconds=120f;
    public float bombSeconds=40f;
    public Transform siteA,siteB;
    public int attackerTeam;
    public bool bombPlanted;
    public float timer;
    public int roundsA,roundsB;

    void OnEnable(){StartRound();}
    public void StartRound(){timer=roundSeconds;bombPlanted=false;}
    public void Plant(){if(!bombPlanted){bombPlanted=true;timer=bombSeconds;OnlyWarGame.I?.hud?.SetObjective("DEVICE PLANTED");}}
    public void Defuse(){if(bombPlanted){bombPlanted=false;Award(1-attackerTeam);}}
    void Update(){
      var g=OnlyWarGame.I;if(!g||g.mode!=GameMode.SearchDestroy)return;
      timer-=Time.deltaTime;
      if(timer<=0){Award(bombPlanted?attackerTeam:1-attackerTeam);}
    }
    void Award(int team){
      if(team==0)roundsA++;else roundsB++;
      if(OnlyWarGame.I){OnlyWarGame.I.teamAScore=roundsA;OnlyWarGame.I.teamBScore=roundsB;}
      if(roundsA>=roundToWin||roundsB>=roundToWin){if(OnlyWarGame.I)OnlyWarGame.I.matchLive=false;enabled=false;return;}
      attackerTeam=1-attackerTeam;StartRound();
    }
  }
}

using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarBattleRoyale : MonoBehaviour {
    public Transform zoneCenter;
    public float startRadius=500f;
    public float finalRadius=25f;
    public float phaseSeconds=120f;
    public int phases=6;
    public int alive;
    public List<OnlyWarDamageable> contestants=new();
    int phase;
    float timer;

    public float CurrentRadius { get; private set; }

    void Start(){timer=phaseSeconds;CurrentRadius=startRadius;alive=contestants.Count;}
    void Update(){
      if(OnlyWarGame.I==null||OnlyWarGame.I.mode!=GameMode.BattleRoyale)return;
      timer-=Time.deltaTime;
      float target=Mathf.Lerp(startRadius,finalRadius,(phase+1f)/Mathf.Max(1,phases));
      CurrentRadius=Mathf.MoveTowards(CurrentRadius,target,(startRadius-finalRadius)/(phases*phaseSeconds)*Time.deltaTime);
      if(timer<=0&&phase<phases-1){phase++;timer=phaseSeconds;}
      alive=0;
      foreach(var d in contestants){
        if(!d||!d.gameObject.activeInHierarchy)continue;
        alive++;
        Vector3 p=d.transform.position;if(zoneCenter)p.y=zoneCenter.position.y;
        Vector3 c=zoneCenter?zoneCenter.position:Vector3.zero;
        if(Vector3.Distance(p,c)>CurrentRadius)d.ApplyDamage(6f*Time.deltaTime);
      }
      OnlyWarGame.I.hud?.SetObjective("ALIVE "+alive+" · ZONE "+Mathf.CeilToInt(CurrentRadius)+"m");
    }
  }
}

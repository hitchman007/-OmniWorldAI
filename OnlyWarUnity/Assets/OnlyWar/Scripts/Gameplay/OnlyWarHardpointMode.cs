using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarHardpointMode : MonoBehaviour {
    public Transform[] hills;
    public int hillIndex;
    public float rotateSeconds=60f;
    public float radius=7f;
    float timer;

    void Start(){timer=rotateSeconds;}
    void Update(){
      var g=OnlyWarGame.I;if(!g||g.mode!=GameMode.Hardpoint||hills==null||hills.Length==0)return;
      timer-=Time.deltaTime;if(timer<=0){hillIndex=(hillIndex+1)%hills.Length;timer=rotateSeconds;}
      int a=0,b=0;var h=hills[hillIndex];
      foreach(var d in FindObjectsByType<OnlyWarDamageable>(FindObjectsSortMode.None)){
        if(!d.gameObject.activeInHierarchy||Vector3.Distance(d.transform.position,h.position)>radius)continue;
        if(d.team==0)a++;else if(d.team==1)b++;
      }
      if(a>0&&b==0)g.teamAScore+=Mathf.CeilToInt(Time.deltaTime);
      if(b>0&&a==0)g.teamBScore+=Mathf.CeilToInt(Time.deltaTime);
      g.hud?.SetObjective("HARDPOINT "+(hillIndex+1)+" · "+Mathf.CeilToInt(timer)+"s");
    }
  }
}

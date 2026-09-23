using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarDominationMode : MonoBehaviour {
    public OnlyWarObjectivePoint[] points;
    public float scoreTick=1f;
    float timer;

    void Update(){
      var g=OnlyWarGame.I;if(!g||g.mode!=GameMode.Frontline||!g.matchLive)return;
      timer-=Time.deltaTime;if(timer>0)return;timer=scoreTick;
      int a=0,b=0;foreach(var p in points){if(!p)continue;if(p.owner==0)a++;else if(p.owner==1)b++;}
      if(a>0)g.AddScore(0,a);if(b>0)g.AddScore(1,b);
    }
  }
}

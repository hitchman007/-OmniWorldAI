using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarObjectivePoint : MonoBehaviour {
    public string objectiveId="A";
    public float radius=6f;
    public float captureSeconds=8f;
    public int owner=-1;
    public float progress;
    public event System.Action<OnlyWarObjectivePoint> OnCaptured;

    void Update(){
      int a=0,b=0;
      foreach(var d in FindObjectsByType<OnlyWarDamageable>(FindObjectsSortMode.None)){
        if(!d.gameObject.activeInHierarchy)continue;
        if(Vector3.Distance(transform.position,d.transform.position)>radius)continue;
        if(d.team==0)a++;else if(d.team==1)b++;
      }
      if(a>0&&b==0)CaptureToward(0,a*Time.deltaTime/captureSeconds);
      else if(b>0&&a==0)CaptureToward(1,b*Time.deltaTime/captureSeconds);
    }

    void CaptureToward(int team,float amount){
      if(owner==team){progress=Mathf.Min(1,progress+amount*.25f);return;}
      progress+=amount;
      if(progress>=1f){owner=team;progress=0;OnCaptured?.Invoke(this);OnlyWarGame.I?.hud?.SetObjective("OBJECTIVE "+objectiveId+" CAPTURED");}
    }
  }
}

using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarKillcam : MonoBehaviour {
    struct Frame { public Vector3 p; public Quaternion r; public float t; }
    public Camera killcamCamera;
    public float recordSeconds=5f;
    public float sampleRate=20f;
    readonly Dictionary<Transform,List<Frame>> history=new();
    float clock;

    void Update(){
      clock+=Time.deltaTime;if(clock<1f/sampleRate)return;clock=0f;
      foreach(var d in FindObjectsByType<OnlyWarDamageable>(FindObjectsSortMode.None)){
        var t=d.transform;if(!history.TryGetValue(t,out var frames)){frames=new List<Frame>();history[t]=frames;}
        frames.Add(new Frame{p=t.position,r=t.rotation,t=Time.time});
        float min=Time.time-recordSeconds;frames.RemoveAll(f=>f.t<min);
      }
    }

    public void Play(Transform killer){
      if(!killcamCamera||!killer||!history.TryGetValue(killer,out var frames)||frames.Count<2)return;
      var last=frames[^1];killcamCamera.transform.SetPositionAndRotation(last.p-killer.forward*3f+Vector3.up*1.7f,Quaternion.LookRotation(killer.position+Vector3.up-killcamCamera.transform.position));
      killcamCamera.enabled=true;CancelInvoke(nameof(Stop));Invoke(nameof(Stop),2.5f);
    }
    void Stop(){if(killcamCamera)killcamCamera.enabled=false;}
  }
}

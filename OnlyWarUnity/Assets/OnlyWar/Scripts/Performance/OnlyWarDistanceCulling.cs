using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarDistanceCulling : MonoBehaviour {
    public Transform viewer;
    public float updateInterval=.25f;
    public float propDistance=90f;
    public float buildingDistance=220f;
    public float characterDistance=130f;
    float timer;

    void Update(){
      timer-=Time.deltaTime;if(timer>0)return;timer=updateInterval;
      if(!viewer&&Camera.main)viewer=Camera.main.transform;if(!viewer)return;
      foreach(var r in FindObjectsByType<Renderer>(FindObjectsSortMode.None)){
        if(!r||r.transform.IsChildOf(viewer))continue;
        string n=r.gameObject.name;
        float max=n.Contains("B_")||n.Contains("Wall")||n.Contains("Roof")?buildingDistance:n.Contains("HOSTILE")||n.Contains("Operator")?characterDistance:propDistance;
        bool vis=(r.bounds.center-viewer.position).sqrMagnitude<=max*max;
        if(r.enabled!=vis)r.enabled=vis;
      }
    }
  }
}

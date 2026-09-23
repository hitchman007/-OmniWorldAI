using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarPool : MonoBehaviour {
    [System.Serializable] public sealed class Entry { public string id; public GameObject prefab; public int prewarm=16; }
    public Entry[] entries;
    readonly Dictionary<string,Queue<GameObject>> pools=new();
    readonly Dictionary<GameObject,string> ids=new();

    void Awake(){
      foreach(var e in entries){
        if(e==null||!e.prefab||string.IsNullOrEmpty(e.id))continue;
        var q=new Queue<GameObject>();pools[e.id]=q;
        for(int i=0;i<e.prewarm;i++){var g=Instantiate(e.prefab,transform);g.SetActive(false);q.Enqueue(g);ids[g]=e.id;}
      }
    }

    public GameObject Spawn(string id,Vector3 p,Quaternion r){
      if(!pools.TryGetValue(id,out var q)||q.Count==0)return null;
      var g=q.Dequeue();g.transform.SetPositionAndRotation(p,r);g.SetActive(true);return g;
    }

    public void Despawn(GameObject g){
      if(!g||!ids.TryGetValue(g,out var id)||!pools.TryGetValue(id,out var q)){if(g)Destroy(g);return;}
      g.SetActive(false);g.transform.SetParent(transform);q.Enqueue(g);
    }
  }
}

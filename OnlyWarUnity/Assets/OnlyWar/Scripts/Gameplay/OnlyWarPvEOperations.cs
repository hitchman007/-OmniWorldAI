using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace OnlyWar {
  public sealed class OnlyWarPvEOperations : MonoBehaviour {
    public OnlyWarOperatorFactory factory;
    public Transform[] spawns;
    public int wave=0;
    public int baseCount=6;
    public float intermission=12f;
    public int alive;
    readonly List<GameObject> hostiles=new();
    bool spawning;

    void Update(){
      var g=OnlyWarGame.I;if(!g||g.mode!=GameMode.PvEOperations)return;
      hostiles.RemoveAll(x=>!x||!x.activeInHierarchy);
      alive=hostiles.Count;
      if(alive==0&&!spawning)StartCoroutine(NextWave());
      g.hud?.SetObjective($"OPERATION · WAVE {wave} · HOSTILES {alive}");
    }

    IEnumerator NextWave(){
      spawning=true;yield return new WaitForSeconds(wave==0?2f:intermission);wave++;
      int count=baseCount+wave*2;
      if(!factory)factory=FindFirstObjectByType<OnlyWarOperatorFactory>();
      for(int i=0;i<count;i++){
        Transform s=spawns!=null&&spawns.Length>0?spawns[i%spawns.Length]:null;
        Vector3 p=s?s.position:new Vector3(Random.Range(-35,35),0,Random.Range(-35,35));
        var g=factory.Build("PVE_"+wave+"_"+i,p,1);
        var agent=g.AddComponent<NavMeshAgent>();agent.speed=Mathf.Min(5.2f,3.1f+wave*.08f);
        var bot=g.AddComponent<OnlyWarBot>();bot.team=1;bot.damage=7f+wave*.65f;bot.eye=g.transform.Find("Head");
        if(wave%5==0){var d=g.GetComponent<OnlyWarDamageable>();d.maxHealth*=2.8f;g.transform.localScale*=1.18f;}
        hostiles.Add(g);
      }
      spawning=false;
    }
  }
}

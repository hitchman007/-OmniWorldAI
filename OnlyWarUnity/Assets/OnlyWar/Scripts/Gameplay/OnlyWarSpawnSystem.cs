using System.Collections;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarSpawnSystem : MonoBehaviour {
    public Transform[] teamA;
    public Transform[] teamB;
    public float respawnDelay=4f;

    public Transform Choose(int team){
      var arr=team==0?teamA:teamB;if(arr==null||arr.Length==0)return null;
      Transform best=arr[Random.Range(0,arr.Length)];float bestScore=float.MinValue;
      foreach(var s in arr){
        if(!s)continue;float nearest=999f;
        foreach(var d in FindObjectsByType<OnlyWarDamageable>(FindObjectsSortMode.None)){
          if(!d.gameObject.activeInHierarchy||d.team==team)continue;
          nearest=Mathf.Min(nearest,Vector3.Distance(s.position,d.transform.position));
        }
        if(nearest>bestScore){bestScore=nearest;best=s;}
      }
      return best;
    }

    public void Respawn(OnlyWarDamageable d)=>StartCoroutine(Routine(d));
    IEnumerator Routine(OnlyWarDamageable d){
      yield return new WaitForSeconds(respawnDelay);
      var s=Choose(d.team);if(s)d.transform.SetPositionAndRotation(s.position,s.rotation);
      d.gameObject.SetActive(true);
    }
  }
}

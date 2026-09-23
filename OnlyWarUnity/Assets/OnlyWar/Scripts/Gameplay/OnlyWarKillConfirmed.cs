using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarDogTag : MonoBehaviour {
    public int victimTeam;
    public float lifeSeconds=25f;
    void Update(){lifeSeconds-=Time.deltaTime;if(lifeSeconds<=0)Destroy(gameObject);}
    void OnTriggerEnter(Collider other){
      var d=other.GetComponentInParent<OnlyWarDamageable>();if(!d)return;
      if(OnlyWarGame.I){
        if(d.team!=victimTeam)OnlyWarGame.I.AddScore(d.team,1);
        OnlyWarGame.I.hud?.SetObjective(d.team!=victimTeam?"KILL CONFIRMED":"TAG DENIED");
      }
      Destroy(gameObject);
    }
  }

  public sealed class OnlyWarKillConfirmedMode : MonoBehaviour {
    public GameObject tagPrefab;
    public void OnKilled(OnlyWarDamageable victim){
      if(!tagPrefab||!victim)return;
      var g=Instantiate(tagPrefab,victim.transform.position+Vector3.up*.4f,Quaternion.identity);
      var tag=g.GetComponent<OnlyWarDogTag>();if(tag)tag.victimTeam=victim.team;
    }
  }
}

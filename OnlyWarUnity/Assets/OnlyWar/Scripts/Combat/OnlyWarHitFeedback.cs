using UnityEngine;
using UnityEngine.UI;

namespace OnlyWar {
  public sealed class OnlyWarHitFeedback : MonoBehaviour {
    public Image hitMarker;
    public Image damageVignette;
    public float markerSeconds=.09f;
    public float damageFade=6f;
    float marker;
    float damage;

    public void ShowHit(bool headshot){
      marker=markerSeconds;
      if(hitMarker){
        hitMarker.enabled=true;
        hitMarker.color=headshot?new Color(1f,.72f,.2f,1f):Color.white;
      }
    }

    public void ShowDamage(float strength){
      damage=Mathf.Clamp01(damage+strength);
      if(damageVignette)damageVignette.enabled=true;
    }

    void Update(){
      if(marker>0){marker-=Time.deltaTime;if(marker<=0&&hitMarker)hitMarker.enabled=false;}
      if(damage>0){damage=Mathf.MoveTowards(damage,0,damageFade*Time.deltaTime);if(damageVignette){var c=damageVignette.color;c.a=damage*.75f;damageVignette.color=c;if(damage<=0)damageVignette.enabled=false;}}
    }
  }
}

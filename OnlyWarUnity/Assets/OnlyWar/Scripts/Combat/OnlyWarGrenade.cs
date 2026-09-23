using UnityEngine;

namespace OnlyWar {
  [RequireComponent(typeof(Rigidbody))]
  public sealed class OnlyWarGrenade : MonoBehaviour {
    public float fuse=3f;
    public float radius=6.5f;
    public float damage=120f;
    public float force=650f;
    public OnlyWarVFXFactory vfx;
    public OnlyWarProceduralAudio audioFx;
    float timer;

    void Start(){timer=fuse;if(!vfx)vfx=FindFirstObjectByType<OnlyWarVFXFactory>();if(!audioFx)audioFx=FindFirstObjectByType<OnlyWarProceduralAudio>();}
    void Update(){timer-=Time.deltaTime;if(timer<=0)Explode();}
    void Explode(){
      foreach(var c in Physics.OverlapSphere(transform.position,radius)){
        var d=c.GetComponentInParent<OnlyWarDamageable>();
        if(d){float dist=Vector3.Distance(transform.position,d.transform.position);d.ApplyDamage(damage*Mathf.Clamp01(1f-dist/radius));}
        if(c.attachedRigidbody)c.attachedRigidbody.AddExplosionForce(force,transform.position,radius,1f,ForceMode.Impulse);
      }
      vfx?.CreateExplosion(transform.position);audioFx?.PlayExplosion(transform.position);Destroy(gameObject);
    }
  }
}

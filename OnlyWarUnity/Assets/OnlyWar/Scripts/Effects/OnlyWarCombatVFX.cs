using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarCombatVFX : MonoBehaviour {
    public static ParticleSystem CreateMuzzleFlash(Transform parent){
      var go=new GameObject("MuzzleFlash");
      go.transform.SetParent(parent,false);
      var ps=go.AddComponent<ParticleSystem>();
      var main=ps.main; main.duration=.06f; main.loop=false; main.startLifetime=.04f; main.startSpeed=2.5f; main.startSize=.18f; main.maxParticles=8;
      main.startColor=new Color(1f,.55f,.18f,1f);
      var emission=ps.emission; emission.rateOverTime=0; emission.SetBursts(new[]{new ParticleSystem.Burst(0f,6)});
      var shape=ps.shape; shape.shapeType=ParticleSystemShapeType.Cone; shape.angle=8f; shape.radius=.01f;
      ps.Play();
      Destroy(go,.5f);
      return ps;
    }

    public static void Impact(Vector3 point,Vector3 normal,Material decalMaterial=null){
      var go=new GameObject("ImpactFX");
      go.transform.position=point+normal*.01f;
      go.transform.rotation=Quaternion.LookRotation(normal);
      var ps=go.AddComponent<ParticleSystem>();
      var main=ps.main; main.duration=.12f; main.loop=false; main.startLifetime=.25f; main.startSpeed=2f; main.startSize=.035f; main.maxParticles=18;
      main.startColor=new Color(.65f,.58f,.48f,1f);
      var emission=ps.emission; emission.rateOverTime=0; emission.SetBursts(new[]{new ParticleSystem.Burst(0f,12)});
      var shape=ps.shape; shape.shapeType=ParticleSystemShapeType.Hemisphere; shape.radius=.03f;
      ps.Play(); Destroy(go,1f);
    }
  }
}

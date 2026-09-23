using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarVFXFactory : MonoBehaviour {
    public ParticleSystem CreateMuzzleFlash(Transform parent) {
      var go=new GameObject("OW_MuzzleFlash");go.transform.SetParent(parent,false);
      var ps=go.AddComponent<ParticleSystem>();var main=ps.main;main.loop=false;main.playOnAwake=false;main.duration=.08f;main.startLifetime=.055f;main.startSpeed=4.5f;main.startSize=.13f;main.maxParticles=12;
      main.startColor=new ParticleSystem.MinMaxGradient(new Color(1f,.72f,.28f,1f),new Color(1f,.25f,.03f,.7f));
      var emission=ps.emission;emission.enabled=true;emission.SetBursts(new[]{new ParticleSystem.Burst(0f,7)});
      var shape=ps.shape;shape.shapeType=ParticleSystemShapeType.Cone;shape.angle=8f;shape.radius=.018f;
      return ps;
    }

    public ParticleSystem CreateImpact(Vector3 position, Vector3 normal) {
      var go=new GameObject("OW_Impact");go.transform.position=position;go.transform.rotation=Quaternion.LookRotation(normal);
      var ps=go.AddComponent<ParticleSystem>();var main=ps.main;main.loop=false;main.duration=.25f;main.startLifetime=.22f;main.startSpeed=3.5f;main.startSize=.035f;main.maxParticles=18;main.stopAction=ParticleSystemStopAction.Destroy;
      main.startColor=new ParticleSystem.MinMaxGradient(new Color(.95f,.68f,.24f),new Color(.32f,.30f,.27f));
      var emission=ps.emission;emission.SetBursts(new[]{new ParticleSystem.Burst(0f,12)});
      var shape=ps.shape;shape.shapeType=ParticleSystemShapeType.Hemisphere;shape.radius=.025f;
      ps.Play();return ps;
    }

    public ParticleSystem CreateExplosion(Vector3 position) {
      var go=new GameObject("OW_Explosion");go.transform.position=position;
      var ps=go.AddComponent<ParticleSystem>();var main=ps.main;main.loop=false;main.duration=.8f;main.startLifetime=new ParticleSystem.MinMaxCurve(.35f,1.15f);main.startSpeed=new ParticleSystem.MinMaxCurve(4f,10f);main.startSize=new ParticleSystem.MinMaxCurve(.3f,1.2f);main.maxParticles=90;main.stopAction=ParticleSystemStopAction.Destroy;
      main.startColor=new ParticleSystem.MinMaxGradient(new Color(1f,.45f,.08f,1),new Color(.12f,.11f,.10f,.7f));
      var emission=ps.emission;emission.SetBursts(new[]{new ParticleSystem.Burst(0f,55)});
      var shape=ps.shape;shape.shapeType=ParticleSystemShapeType.Sphere;shape.radius=.25f;
      ps.Play();return ps;
    }
  }
}

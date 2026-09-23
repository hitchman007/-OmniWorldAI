using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarSpatialAudio : MonoBehaviour {
    public AudioClip distantGunfire;
    public AudioClip urbanAmbience;
    public AudioClip wind;
    public AudioClip vehicleLoop;

    AudioSource ambience;

    void Start(){
      ambience=gameObject.AddComponent<AudioSource>();
      ambience.spatialBlend=0f;
      ambience.loop=true;
      ambience.volume=.28f;
      ambience.clip=urbanAmbience?urbanAmbience:wind;
      if(ambience.clip)ambience.Play();
    }

    public AudioSource Spawn3D(AudioClip clip,Vector3 position,float min=3f,float max=80f,float volume=1f){
      if(!clip)return null;
      var go=new GameObject("3D Audio "+clip.name);
      go.transform.position=position;
      var a=go.AddComponent<AudioSource>();
      a.clip=clip;a.spatialBlend=1f;a.rolloffMode=AudioRolloffMode.Logarithmic;a.minDistance=min;a.maxDistance=max;a.volume=volume;
      a.Play();Destroy(go,clip.length+1f);return a;
    }
  }
}

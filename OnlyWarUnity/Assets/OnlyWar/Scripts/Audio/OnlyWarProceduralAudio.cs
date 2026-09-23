using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarProceduralAudio : MonoBehaviour {
    public AudioClip arx41, vpr9, hmx7, explosion, hitmarker, uiClick, reload;
    const int Rate=44100;

    void Awake() {
      arx41=MakeGun("ARX-41",.42f,80f,2400f,17f);
      vpr9=MakeGun("VPR-9",.32f,105f,2850f,21f);
      hmx7=MakeGun("HMX-7",.62f,64f,1900f,13f);
      explosion=MakeExplosion();
      hitmarker=MakeTone("HitMarker",.12f,1450f,38f,.34f);
      uiClick=MakeTone("UI_Click",.08f,620f,48f,.22f);
      reload=MakeReload();
    }

    AudioClip MakeGun(string name,float seconds,float low,float crack,float decay) {
      int n=Mathf.CeilToInt(seconds*Rate);float[] s=new float[n];var rnd=new System.Random(name.GetHashCode());
      for(int i=0;i<n;i++){float t=i/(float)Rate;float noise=((float)rnd.NextDouble()*2f-1f);float boom=Mathf.Sin(2*Mathf.PI*low*t);float snap=Mathf.Sin(2*Mathf.PI*crack*t);s[i]=(noise*.55f+boom*.42f)*Mathf.Exp(-t*decay)+snap*.16f*Mathf.Exp(-t*65f);}
      Normalize(s,.86f);var c=AudioClip.Create(name,n,1,Rate,false);c.SetData(s,0);return c;
    }
    AudioClip MakeExplosion(){int n=Rate*2;float[] s=new float[n];var rnd=new System.Random(771);for(int i=0;i<n;i++){float t=i/(float)Rate;float noise=((float)rnd.NextDouble()*2f-1f);float low=Mathf.Sin(2*Mathf.PI*48f*t);s[i]=(noise*.7f+low*.75f)*Mathf.Exp(-t*2.5f);}Normalize(s,.9f);var c=AudioClip.Create("Explosion",n,1,Rate,false);c.SetData(s,0);return c;}
    AudioClip MakeTone(string name,float sec,float hz,float decay,float amp){int n=Mathf.CeilToInt(sec*Rate);float[] s=new float[n];for(int i=0;i<n;i++){float t=i/(float)Rate;s[i]=Mathf.Sin(2*Mathf.PI*hz*t)*Mathf.Exp(-t*decay)*amp;}var c=AudioClip.Create(name,n,1,Rate,false);c.SetData(s,0);return c;}
    AudioClip MakeReload(){int n=Mathf.CeilToInt(.72f*Rate);float[] s=new float[n];var rnd=new System.Random(552);float[] hits={.06f,.22f,.47f,.62f};foreach(float h in hits){int st=(int)(h*Rate);for(int i=0;i<Mathf.Min(1500,n-st);i++){float t=i/(float)Rate;s[st+i]+=(((float)rnd.NextDouble()*2f-1f)*.5f+Mathf.Sin(2*Mathf.PI*1700f*t)*.25f)*Mathf.Exp(-t*85f);}}Normalize(s,.5f);var c=AudioClip.Create("Reload",n,1,Rate,false);c.SetData(s,0);return c;}
    static void Normalize(float[] s,float peak){float m=.0001f;for(int i=0;i<s.Length;i++)m=Mathf.Max(m,Mathf.Abs(s[i]));float k=peak/m;for(int i=0;i<s.Length;i++)s[i]*=k;}

    public void PlayGun(string id,Vector3 pos){AudioClip c=id.Contains("VPR")?vpr9:id.Contains("HMX")?hmx7:arx41;if(c)AudioSource.PlayClipAtPoint(c,pos,.82f);}
    public void PlayExplosion(Vector3 pos){if(explosion)AudioSource.PlayClipAtPoint(explosion,pos,1f);}
    public void PlayHit(Vector3 pos){if(hitmarker)AudioSource.PlayClipAtPoint(hitmarker,pos,.65f);}
    public void PlayReload(Vector3 pos){if(reload)AudioSource.PlayClipAtPoint(reload,pos,.7f);}
  }
}

using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarWeaponAnimator : MonoBehaviour {
    public OnlyWarInput input;
    public Transform weaponRoot;
    public Vector3 hipPos=new(.22f,-.22f,.34f);
    public Vector3 adsPos=new(0f,-.105f,.27f);
    public float sway=.004f;
    public float bob=.012f;
    public float adsSpeed=14f;
    Vector3 recoil;
    float step;

    void Update(){
      if(!input||!weaponRoot)return;
      step+=Time.deltaTime*(input.SprintHeld?12f:input.Move.sqrMagnitude>.05f?8f:2f);
      Vector3 target=input.AdsHeld?adsPos:hipPos;
      target+=new Vector3(Mathf.Sin(step)*bob,Mathf.Abs(Mathf.Cos(step))*bob*.65f,0f)*Mathf.Clamp01(input.Move.magnitude);
      target+=new Vector3(-input.Look.x,input.Look.y,0f)*sway;
      weaponRoot.localPosition=Vector3.Lerp(weaponRoot.localPosition,target+recoil,adsSpeed*Time.deltaTime);
      recoil=Vector3.Lerp(recoil,Vector3.zero,16f*Time.deltaTime);
      weaponRoot.localRotation=Quaternion.Slerp(weaponRoot.localRotation,Quaternion.Euler(input.Look.y*sway*55f,-input.Look.x*sway*60f,0),12f*Time.deltaTime);
    }
    public void Kick(float strength=1f){recoil+=new Vector3(0,-.015f,.055f)*strength;}
  }
}

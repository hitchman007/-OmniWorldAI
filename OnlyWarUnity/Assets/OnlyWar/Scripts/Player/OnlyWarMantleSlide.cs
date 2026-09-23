using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarMantleSlide : MonoBehaviour {
    public CharacterController controller;
    public OnlyWarInput input;
    public float mantleDistance=1.15f;
    public float mantleHeight=1.35f;
    public float mantleSeconds=.22f;
    public float slideSeconds=.65f;
    public float slideSpeed=9f;
    float mantleT,slideT;
    Vector3 mantleStart,mantleEnd;

    void Awake(){if(!controller)controller=GetComponent<CharacterController>();if(!input)input=FindFirstObjectByType<OnlyWarInput>();}

    void Update(){
      if(!controller||!input)return;
      if(mantleT>0){mantleT-=Time.deltaTime;float t=1f-Mathf.Clamp01(mantleT/mantleSeconds);transform.position=Vector3.Lerp(mantleStart,mantleEnd,t);return;}
      if(slideT>0){slideT-=Time.deltaTime;controller.Move(transform.forward*slideSpeed*Time.deltaTime);}
    }

    public bool TryMantle(){
      Vector3 chest=transform.position+Vector3.up*1.1f;
      if(!Physics.Raycast(chest,transform.forward,out var wall,mantleDistance))return false;
      Vector3 top=wall.point+Vector3.up*mantleHeight+transform.forward*.5f;
      if(Physics.CheckCapsule(top+Vector3.up*.25f,top+Vector3.up*1.5f,.28f))return false;
      mantleStart=transform.position;mantleEnd=top;mantleT=mantleSeconds;return true;
    }

    public void BeginSlide(){if(controller.isGrounded&&input.SprintHeld)slideT=slideSeconds;}
  }
}

using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarAimAssist : MonoBehaviour {
    public Camera aimCamera;
    public OnlyWarInput input;
    public OnlyWarPlayerSettings settings;
    public float maxDistance=55f;
    public float coneDegrees=5.5f;
    public float rotationStrength=5.5f;
    public LayerMask targetMask=~0;

    void Awake(){
      if(!aimCamera)aimCamera=Camera.main;
      if(!input)input=FindFirstObjectByType<OnlyWarInput>();
      if(!settings)settings=FindFirstObjectByType<OnlyWarPlayerSettings>();
    }

    void LateUpdate(){
      if(!aimCamera||!input||settings&& !settings.data.aimAssist)return;
      if(!input.AdsHeld)return;
      var own=GetComponentInParent<OnlyWarDamageable>();
      OnlyWarDamageable best=null;Vector3 bestPoint=Vector3.zero;float bestAngle=coneDegrees;
      foreach(var d in FindObjectsByType<OnlyWarDamageable>(FindObjectsSortMode.None)){
        if(!d||d==own||!d.gameObject.activeInHierarchy||own&&d.team==own.team)continue;
        Vector3 point=d.head?d.head.position:d.transform.position+Vector3.up*1.3f;
        Vector3 dir=point-aimCamera.transform.position;float dist=dir.magnitude;if(dist>maxDistance)continue;
        float angle=Vector3.Angle(aimCamera.transform.forward,dir);if(angle>=bestAngle)continue;
        if(Physics.Raycast(aimCamera.transform.position,dir.normalized,out var hit,dist,targetMask,QueryTriggerInteraction.Ignore)&&hit.collider.GetComponentInParent<OnlyWarDamageable>()==d){
          best=d;bestPoint=point;bestAngle=angle;
        }
      }
      if(!best)return;
      Quaternion target=Quaternion.LookRotation((bestPoint-aimCamera.transform.position).normalized,Vector3.up);
      aimCamera.transform.rotation=Quaternion.Slerp(aimCamera.transform.rotation,target,rotationStrength*Time.deltaTime*Mathf.InverseLerp(coneDegrees,0,bestAngle));
    }
  }
}

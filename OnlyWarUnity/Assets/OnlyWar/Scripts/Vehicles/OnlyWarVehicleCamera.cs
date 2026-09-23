using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarVehicleCamera : MonoBehaviour {
    public Transform target;
    public Vector3 offset=new(0,3.2f,-6.8f);
    public float positionSharpness=8f;
    public float rotationSharpness=10f;
    public LayerMask collisionMask=~0;

    void LateUpdate(){
      if(!target)return;
      Vector3 desired=target.TransformPoint(offset);
      Vector3 origin=target.position+Vector3.up*1.5f;
      Vector3 dir=desired-origin;float dist=dir.magnitude;
      if(Physics.SphereCast(origin,.22f,dir.normalized,out var hit,dist,collisionMask,QueryTriggerInteraction.Ignore))desired=hit.point-hit.normal*.25f;
      transform.position=Vector3.Lerp(transform.position,desired,1-Mathf.Exp(-positionSharpness*Time.deltaTime));
      var look=Quaternion.LookRotation((target.position+Vector3.up*1.2f-transform.position).normalized,Vector3.up);
      transform.rotation=Quaternion.Slerp(transform.rotation,look,1-Mathf.Exp(-rotationSharpness*Time.deltaTime));
    }
  }
}

using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarEquipmentController : MonoBehaviour {
    public OnlyWarInput input;
    public Transform throwOrigin;
    public GameObject fragPrefab;
    public float throwForce=18f;
    public GameObject coverPrefab;
    public int fragCount=2;
    public int coverCount=3;

    void Awake(){if(!input)input=FindFirstObjectByType<OnlyWarInput>();}
    void Update(){
      if(!input)return;
      if(input.GrenadePressed)ThrowFrag();
      if(input.InteractPressed)Interact();
    }

    public void ThrowFrag(){
      if(fragCount<=0||!fragPrefab||!throwOrigin)return;
      var g=Instantiate(fragPrefab,throwOrigin.position,throwOrigin.rotation);
      if(g.TryGetComponent<Rigidbody>(out var rb))rb.linearVelocity=throwOrigin.forward*throwForce+Vector3.up*3f;
      fragCount--;
    }

    public void DeployCover(){
      if(coverCount<=0||!coverPrefab)return;
      Vector3 p=transform.position+transform.forward*2.5f;
      Instantiate(coverPrefab,p,Quaternion.LookRotation(transform.forward));
      coverCount--;
    }

    void Interact(){
      var ray=new Ray(transform.position+Vector3.up*1.4f,transform.forward);
      if(Physics.Raycast(ray,out var hit,3.5f)){
        var vehicle=hit.collider.GetComponentInParent<OnlyWarVehicleController>();
        if(vehicle)vehicle.Enter(input);
      }
    }
  }
}

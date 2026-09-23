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
      if(fragCount<=0||!throwOrigin)return;
      GameObject g;
      if(fragPrefab) g=Instantiate(fragPrefab,throwOrigin.position,throwOrigin.rotation);
      else {
        g=GameObject.CreatePrimitive(PrimitiveType.Sphere);g.name="OW_Frag";g.transform.position=throwOrigin.position;g.transform.localScale=Vector3.one*.18f;
        g.AddComponent<Rigidbody>();g.AddComponent<OnlyWarGrenade>();
      }
      if(g.TryGetComponent<Rigidbody>(out var rb))rb.linearVelocity=throwOrigin.forward*throwForce+Vector3.up*3f;
      fragCount--;
    }

    public void DeployCover(){
      if(coverCount<=0)return;
      Vector3 p=transform.position+transform.forward*2.5f;
      if(coverPrefab) Instantiate(coverPrefab,p,Quaternion.LookRotation(transform.forward));
      else {
        var c=GameObject.CreatePrimitive(PrimitiveType.Cube);c.name="OW_DeployableCover";c.transform.SetPositionAndRotation(p+Vector3.up*.85f,Quaternion.LookRotation(transform.forward));c.transform.localScale=new Vector3(2.6f,1.7f,.32f);
        var r=c.GetComponent<Renderer>();var lib=FindFirstObjectByType<OnlyWarMaterialLibrary>();if(r&&lib)r.sharedMaterial=lib.Get("deployable_cover",new Color(.15f,.18f,.19f),.35f,.28f);
      }
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

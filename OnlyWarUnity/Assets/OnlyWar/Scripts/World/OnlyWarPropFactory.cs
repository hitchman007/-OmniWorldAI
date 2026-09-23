using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarPropFactory : MonoBehaviour {
    public OnlyWarMaterialLibrary mats;

    void Ensure(){if(!mats)mats=FindFirstObjectByType<OnlyWarMaterialLibrary>();if(!mats)mats=gameObject.AddComponent<OnlyWarMaterialLibrary>();}
    public GameObject Crate(Vector3 p){Ensure();var r=Box("SupplyCrate",p,new Vector3(1.35f,.85f,1.0f),mats.Get("crate",new Color(.24f,.23f,.18f),.1f,.22f));Box("CrateBandA",p+Vector3.up*.1f,new Vector3(1.42f,.12f,1.05f),mats.Get("crateBand",new Color(.08f,.09f,.09f),.5f,.35f),r.transform);return r;}
    public GameObject Barrier(Vector3 p,Quaternion rot){Ensure();var r=Box("JerseyBarrier",p+Vector3.up*.55f,new Vector3(2.6f,1.1f,.65f),mats.Get("barrierConcrete",new Color(.52f,.51f,.47f),0f,.25f));r.transform.rotation=rot;return r;}
    public GameObject Lamp(Vector3 p){Ensure();var root=new GameObject("StreetLamp");root.transform.position=p;var metal=mats.Get("lampMetal",new Color(.06f,.07f,.075f),.65f,.42f);Box("Pole",Vector3.up*2.5f,new Vector3(.12f,5f,.12f),metal,root.transform);Box("Arm",new Vector3(.55f,4.85f,0),new Vector3(1.2f,.1f,.1f),metal,root.transform);var bulb=GameObject.CreatePrimitive(PrimitiveType.Sphere);bulb.name="Lamp";bulb.transform.SetParent(root.transform);bulb.transform.localPosition=new Vector3(1.08f,4.75f,0);bulb.transform.localScale=Vector3.one*.22f;Destroy(bulb.GetComponent<Collider>());var l=bulb.AddComponent<Light>();l.type=LightType.Point;l.range=11f;l.intensity=1.8f;l.color=new Color(1f,.78f,.54f);return root;}
    public GameObject Sandbag(Vector3 p,Quaternion r){Ensure();var g=GameObject.CreatePrimitive(PrimitiveType.Capsule);g.name="Sandbag";g.transform.position=p;g.transform.rotation=r*Quaternion.Euler(0,0,90);g.transform.localScale=new Vector3(.42f,.72f,.35f);g.GetComponent<Renderer>().sharedMaterial=mats.Get("sandbag",new Color(.35f,.31f,.22f),0f,.1f);return g;}
    GameObject Box(string n,Vector3 p,Vector3 s,Material m,Transform parent=null){var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name=n;if(parent){g.transform.SetParent(parent);g.transform.localPosition=p;}else g.transform.position=p;g.transform.localScale=s;g.GetComponent<Renderer>().sharedMaterial=m;return g;}
  }
}

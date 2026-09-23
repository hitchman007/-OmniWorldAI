using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarProceduralWeaponFactory : MonoBehaviour {
    public OnlyWarMaterialLibrary materials;

    public GameObject Build(string id) {
      if(!materials)materials=FindFirstObjectByType<OnlyWarMaterialLibrary>();
      if(!materials)materials=gameObject.AddComponent<OnlyWarMaterialLibrary>();
      var root=new GameObject(id+"_ViewModel");
      var metal=materials.Get(id+"_metal",new Color(.08f,.095f,.105f),.72f,.48f);
      var polymer=materials.Get(id+"_poly",new Color(.12f,.14f,.15f),.05f,.3f);
      var accent=materials.Get(id+"_accent",new Color(.30f,.33f,.34f),.5f,.5f);

      float bodyL=id.Contains("HMX")?1.0f:id.Contains("VPR")?.62f:.82f;
      AddBox(root.transform,"Receiver",new Vector3(.16f,-.14f,.45f),new Vector3(.12f,.12f,bodyL),metal);
      AddBox(root.transform,"Handguard",new Vector3(.16f,-.12f,-.02f),new Vector3(.10f,.095f,.42f),polymer);
      AddCylinder(root.transform,"Barrel",new Vector3(.16f,-.10f,-.42f),new Vector3(.025f,.26f,.025f),metal,Quaternion.Euler(90,0,0));
      AddBox(root.transform,"Stock",new Vector3(.16f,-.11f,.93f),new Vector3(.11f,.16f,.34f),polymer);
      AddBox(root.transform,"Grip",new Vector3(.16f,-.28f,.48f),new Vector3(.09f,.28f,.10f),polymer,Quaternion.Euler(12,0,0));
      AddBox(root.transform,"Mag",new Vector3(.16f,-.30f,.22f),new Vector3(.11f,.34f,.13f),accent,Quaternion.Euler(10,0,0));
      AddBox(root.transform,"Rail",new Vector3(.16f,-.04f,.28f),new Vector3(.08f,.035f,.48f),metal);
      AddBox(root.transform,"Sight",new Vector3(.16f,.01f,.12f),new Vector3(.09f,.07f,.10f),accent);
      return root;
    }

    GameObject AddBox(Transform p,string n,Vector3 pos,Vector3 scale,Material mat,Quaternion? rot=null){
      var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name=n;g.transform.SetParent(p);g.transform.localPosition=pos;g.transform.localScale=scale;g.transform.localRotation=rot??Quaternion.identity;g.GetComponent<Renderer>().sharedMaterial=mat;Destroy(g.GetComponent<Collider>());return g;
    }
    GameObject AddCylinder(Transform p,string n,Vector3 pos,Vector3 scale,Material mat,Quaternion rot){
      var g=GameObject.CreatePrimitive(PrimitiveType.Cylinder);g.name=n;g.transform.SetParent(p);g.transform.localPosition=pos;g.transform.localScale=scale;g.transform.localRotation=rot;g.GetComponent<Renderer>().sharedMaterial=mat;Destroy(g.GetComponent<Collider>());return g;
    }
  }
}

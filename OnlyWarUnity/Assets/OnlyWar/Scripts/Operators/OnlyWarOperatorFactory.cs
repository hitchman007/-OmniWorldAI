using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarOperatorFactory : MonoBehaviour {
    public OnlyWarMaterialLibrary materials;

    public GameObject Build(string id, Vector3 position, int team=1) {
      if(!materials)materials=FindFirstObjectByType<OnlyWarMaterialLibrary>();
      if(!materials)materials=gameObject.AddComponent<OnlyWarMaterialLibrary>();
      var root=new GameObject(id);root.transform.position=position;
      var skin=materials.Get(id+"_skin",new Color(.42f,.33f,.27f),0f,.35f);
      var cloth=materials.Get(id+"_cloth",team==0?new Color(.11f,.19f,.21f):new Color(.22f,.15f,.13f),0f,.2f);
      var armor=materials.Get(id+"_armor",new Color(.08f,.095f,.10f),.25f,.28f);

      Part(root.transform,"Torso",PrimitiveType.Capsule,new Vector3(0,1.25f,0),new Vector3(.55f,.62f,.36f),cloth);
      Part(root.transform,"Head",PrimitiveType.Sphere,new Vector3(0,2.02f,0),new Vector3(.28f,.30f,.28f),skin);
      Part(root.transform,"Vest",PrimitiveType.Cube,new Vector3(0,1.38f,.03f),new Vector3(.66f,.7f,.38f),armor);
      foreach(float x in new[]{-.25f,.25f}) {
        Part(root.transform,"Arm",PrimitiveType.Capsule,new Vector3(x,1.33f,0),new Vector3(.16f,.52f,.16f),cloth);
        Part(root.transform,"Leg",PrimitiveType.Capsule,new Vector3(x*.58f,.55f,0),new Vector3(.18f,.62f,.18f),cloth);
      }
      var dmg=root.AddComponent<OnlyWarDamageable>();dmg.team=team;dmg.head=root.transform.Find("Head");
      return root;
    }

    GameObject Part(Transform p,string n,PrimitiveType type,Vector3 pos,Vector3 scale,Material mat){
      var g=GameObject.CreatePrimitive(type);g.name=n;g.transform.SetParent(p);g.transform.localPosition=pos;g.transform.localScale=scale;g.GetComponent<Renderer>().sharedMaterial=mat;return g;
    }
  }
}

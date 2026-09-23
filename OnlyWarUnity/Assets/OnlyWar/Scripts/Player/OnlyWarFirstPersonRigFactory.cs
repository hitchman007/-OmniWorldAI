using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarFirstPersonRigFactory : MonoBehaviour {
    public OnlyWarMaterialLibrary materials;

    public GameObject BuildHands(Transform cameraRoot){
      if(!materials)materials=FindFirstObjectByType<OnlyWarMaterialLibrary>();
      if(!materials)materials=gameObject.AddComponent<OnlyWarMaterialLibrary>();
      var root=new GameObject("FirstPersonHands");root.transform.SetParent(cameraRoot,false);
      var skin=materials.Get("fp_skin",new Color(.44f,.32f,.25f),0f,.42f);
      var glove=materials.Get("fp_glove",new Color(.055f,.065f,.07f),.1f,.22f);
      var cloth=materials.Get("fp_sleeve",new Color(.09f,.12f,.13f),0f,.2f);
      Arm(root.transform,"LeftArm",new Vector3(-.23f,-.31f,.35f),new Vector3(-18,8,20),skin,glove,cloth);
      Arm(root.transform,"RightArm",new Vector3(.25f,-.31f,.30f),new Vector3(-14,-7,-22),skin,glove,cloth);
      return root;
    }

    public GameObject Build(Transform cameraRoot,string weaponId="ARX-41"){
      var root=BuildHands(cameraRoot);
      var wf=FindFirstObjectByType<OnlyWarProceduralWeaponFactory>();
      if(!wf){var go=new GameObject("WeaponFactory");wf=go.AddComponent<OnlyWarProceduralWeaponFactory>();wf.materials=materials;}
      var weapon=wf.Build(weaponId);weapon.transform.SetParent(root.transform,false);
      weapon.transform.localPosition=new Vector3(.06f,-.07f,-.18f);
      weapon.transform.localRotation=Quaternion.Euler(0,180,0);
      return root;
    }

    void Arm(Transform parent,string name,Vector3 pos,Vector3 euler,Material skin,Material glove,Material cloth){
      var root=new GameObject(name);root.transform.SetParent(parent,false);root.transform.localPosition=pos;root.transform.localRotation=Quaternion.Euler(euler);
      Part(root.transform,"Sleeve",PrimitiveType.Capsule,new Vector3(0,-.05f,.18f),new Vector3(.11f,.30f,.11f),cloth);
      Part(root.transform,"Forearm",PrimitiveType.Capsule,new Vector3(0,-.03f,-.18f),new Vector3(.095f,.27f,.095f),skin);
      Part(root.transform,"Glove",PrimitiveType.Capsule,new Vector3(0,-.02f,-.44f),new Vector3(.105f,.16f,.105f),glove);
    }

    GameObject Part(Transform p,string n,PrimitiveType type,Vector3 pos,Vector3 scale,Material mat){
      var g=GameObject.CreatePrimitive(type);g.name=n;g.transform.SetParent(p,false);g.transform.localPosition=pos;g.transform.localScale=scale;g.GetComponent<Renderer>().sharedMaterial=mat;Destroy(g.GetComponent<Collider>());return g;
    }
  }
}

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace OnlyWar.Editor {
  public static class OnlyWarPlayableRigBuilder {
    [MenuItem("OnlyWar/Generate Playable Placeholder Rigs")]
    public static void Build(){
      Directory.CreateDirectory("Assets/OnlyWar/GeneratedPrefabs");
      MakeOperator();
      MakeRifle();
      MakeVehicle();
      AssetDatabase.SaveAssets();AssetDatabase.Refresh();
    }

    static Material M(string n,Color c,float metal=0f){
      var sh=Shader.Find("Universal Render Pipeline/Lit")??Shader.Find("Standard");
      var m=new Material(sh){name=n,color=c};
      if(m.HasProperty("_Metallic"))m.SetFloat("_Metallic",metal);
      return m;
    }

    static void MakeOperator(){
      var root=new GameObject("OW_Operator_Raven3");
      var skin=M("Skin",new Color(.45f,.31f,.24f));
      var cloth=M("TacticalCloth",new Color(.07f,.09f,.085f));
      var armor=M("Armor",new Color(.13f,.16f,.15f),.15f);
      Part(PrimitiveType.Capsule,"Torso",root.transform,new Vector3(0,1.25f,0),new Vector3(.62f,.58f,.36f),cloth);
      Part(PrimitiveType.Sphere,"Head",root.transform,new Vector3(0,1.93f,0),Vector3.one*.27f,skin);
      Part(PrimitiveType.Cube,"PlateCarrier",root.transform,new Vector3(0,1.35f,.19f),new Vector3(.68f,.55f,.18f),armor);
      Limb("ArmL",root.transform,new Vector3(-.46f,1.38f,0),new Vector3(.18f,.7f,.18f),cloth);
      Limb("ArmR",root.transform,new Vector3(.46f,1.38f,0),new Vector3(.18f,.7f,.18f),cloth);
      Limb("LegL",root.transform,new Vector3(-.2f,.55f,0),new Vector3(.24f,1.0f,.26f),cloth);
      Limb("LegR",root.transform,new Vector3(.2f,.55f,0),new Vector3(.24f,1.0f,.26f),cloth);
      var dmg=root.AddComponent<OnlyWarDamageable>();dmg.team=1;dmg.head=root.transform.Find("Head");
      PrefabUtility.SaveAsPrefabAsset(root,"Assets/OnlyWar/GeneratedPrefabs/OW_Operator_Raven3.prefab");Object.DestroyImmediate(root);
    }

    static void MakeRifle(){
      var root=new GameObject("OW_ARX41");
      var gun=M("GunMetal",new Color(.08f,.09f,.1f),.75f);
      Part(PrimitiveType.Cube,"Receiver",root.transform,new Vector3(0,0,0),new Vector3(.12f,.13f,.5f),gun);
      Part(PrimitiveType.Cylinder,"Barrel",root.transform,new Vector3(0,.02f,.39f),new Vector3(.035f,.28f,.035f),gun).transform.rotation=Quaternion.Euler(90,0,0);
      Part(PrimitiveType.Cube,"Stock",root.transform,new Vector3(0,-.02f,-.36f),new Vector3(.11f,.14f,.26f),gun);
      Part(PrimitiveType.Cube,"Magazine",root.transform,new Vector3(0,-.17f,.02f),new Vector3(.08f,.24f,.12f),gun);
      PrefabUtility.SaveAsPrefabAsset(root,"Assets/OnlyWar/GeneratedPrefabs/OW_ARX41.prefab");Object.DestroyImmediate(root);
    }

    static void MakeVehicle(){
      var root=new GameObject("OW_WraithMRV");
      var metal=M("VehicleArmor",new Color(.12f,.15f,.15f),.65f);
      Part(PrimitiveType.Cube,"Body",root.transform,new Vector3(0,1.0f,0),new Vector3(2.2f,.8f,4.1f),metal);
      Part(PrimitiveType.Cube,"Cab",root.transform,new Vector3(0,1.75f,-.2f),new Vector3(1.9f,.8f,1.9f),metal);
      for(int sx=-1;sx<=1;sx+=2)for(int sz=-1;sz<=1;sz+=2){
        var w=Part(PrimitiveType.Cylinder,"Wheel",root.transform,new Vector3(sx*1.15f,.65f,sz*1.35f),new Vector3(.55f,.28f,.55f),M("Tire",Color.black));
        w.transform.rotation=Quaternion.Euler(0,0,90);
      }
      var rb=root.AddComponent<Rigidbody>();rb.mass=2100f;
      root.AddComponent<OnlyWarVehicleController>();
      PrefabUtility.SaveAsPrefabAsset(root,"Assets/OnlyWar/GeneratedPrefabs/OW_WraithMRV.prefab");Object.DestroyImmediate(root);
    }

    static GameObject Limb(string n,Transform p,Vector3 pos,Vector3 scale,Material m)=>Part(PrimitiveType.Capsule,n,p,pos,scale,m);
    static GameObject Part(PrimitiveType type,string n,Transform p,Vector3 pos,Vector3 scale,Material m){
      var g=GameObject.CreatePrimitive(type);g.name=n;g.transform.SetParent(p,false);g.transform.localPosition=pos;g.transform.localScale=scale;
      if(m)g.GetComponent<Renderer>().sharedMaterial=m;return g;
    }
  }
}

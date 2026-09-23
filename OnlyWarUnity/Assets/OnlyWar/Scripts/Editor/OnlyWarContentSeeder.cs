#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace OnlyWar.Editor {
  public static class OnlyWarContentSeeder {
    const string Root="Assets/OnlyWar/Data";

    struct WeaponSeed {
      public string id; public int mag,res; public float dmg,rpm,reload,range,hip,ads,recoil;
      public WeaponSeed(string i,int m,int r,float d,float rate,float rl,float rg,float h,float a,float rec){id=i;mag=m;res=r;dmg=d;rpm=rate;reload=rl;range=rg;hip=h;ads=a;recoil=rec;}
    }

    [MenuItem("OnlyWar/Seed Production Catalogs")]
    public static void Seed(){
      Directory.CreateDirectory(Root+"/Weapons");
      var seeds=new[]{
        new WeaponSeed("ARX-41",30,150,32,700,1.55f,180,1.2f,.22f,1.05f),
        new WeaponSeed("VPR-9",36,180,24,880,1.35f,115,1.5f,.35f,.78f),
        new WeaponSeed("HMX-7",18,90,52,360,1.72f,240,.95f,.14f,1.35f),
        new WeaponSeed("KTR-56",30,150,35,620,1.65f,190,1.1f,.20f,1.18f),
        new WeaponSeed("RAV-12",8,48,28,90,2.2f,42,2.4f,.85f,2.1f),
        new WeaponSeed("LNX-50",5,35,94,52,2.65f,310,2.2f,.05f,2.6f),
        new WeaponSeed("MKR-4",25,125,37,560,1.62f,205,1.0f,.18f,1.15f),
        new WeaponSeed("SPAR-21",45,180,27,760,2.05f,175,1.35f,.28f,.92f),
        new WeaponSeed("BRM-88",75,225,30,650,3.1f,195,1.45f,.32f,1.45f),
        new WeaponSeed("FEN-11",48,192,21,980,1.52f,95,1.7f,.38f,.72f),
        new WeaponSeed("CRX-9",30,150,29,790,1.45f,135,1.4f,.27f,.84f),
        new WeaponSeed("VOLT-6",24,120,34,640,1.48f,150,1.2f,.23f,.96f),
        new WeaponSeed("SBR-14",20,100,48,420,1.8f,230,1.05f,.16f,1.32f),
        new WeaponSeed("MANTA-5",60,240,26,720,2.75f,175,1.5f,.31f,1.22f),
        new WeaponSeed("PX-9",15,60,31,480,1.15f,80,1.2f,.32f,.65f),
        new WeaponSeed("M12",10,50,43,340,1.35f,90,1.3f,.28f,.85f),
        new WeaponSeed("VKR-3",6,42,112,42,2.9f,340,2.3f,.04f,2.9f),
        new WeaponSeed("SGX-8",12,60,21,150,2.35f,55,2.1f,.72f,1.85f)
      };
      var cat=ScriptableObject.CreateInstance<OnlyWarWeaponCatalog>();
      cat.weapons=new OnlyWarWeaponDefinition[seeds.Length];
      for(int i=0;i<seeds.Length;i++){
        var s=seeds[i];string path=Root+"/Weapons/"+s.id+".asset";
        var w=AssetDatabase.LoadAssetAtPath<OnlyWarWeaponDefinition>(path);
        if(!w){w=ScriptableObject.CreateInstance<OnlyWarWeaponDefinition>();AssetDatabase.CreateAsset(w,path);}
        w.weaponId=s.id;w.magazine=s.mag;w.reserve=s.res;w.damage=s.dmg;w.rpm=s.rpm;w.reloadSeconds=s.reload;w.range=s.range;w.hipSpread=s.hip;w.adsSpread=s.ads;w.recoilPitch=s.recoil;w.recoilYaw=s.recoil*.28f;
        EditorUtility.SetDirty(w);cat.weapons[i]=w;
      }
      SaveOrReplace(cat,Root+"/WeaponCatalog.asset");

      var ops=ScriptableObject.CreateInstance<OnlyWarOperatorCatalog>();
      ops.operators=new[]{
        Op("RAVEN-3","Raven-3","Assault","Urban breach and combined-arms operator","URBAN NIGHT","ASH GRID","WINTER REACH"),
        Op("VANTA-6","Vanta-6","Recon","Long-range reconnaissance and electronic warfare","RECON BLACK","DESERT VEIL","ALPINE GREY"),
        Op("KILO-2","Kilo-2","Heavy","Armor, demolition and objective defense","SIEGE","FOREST GRID","IRON DUST"),
        Op("ECHO-7","Echo-7","Support","Combat medic and squad sustainment","FIELD MEDIC","WHITEOUT","NIGHT AID"),
        Op("NOMAD-1","Nomad-1","Scout","Fast movement and flanking specialist","DUST RUNNER","GREENLINE","CARBON")
      };
      SaveOrReplace(ops,Root+"/OperatorCatalog.asset");

      var veh=ScriptableObject.CreateInstance<OnlyWarVehicleCatalog>();
      veh.vehicles=new[]{
        V("WRAITH_MRV","Wraith MRV","Ground",26,4,"ASH ARMOR","DESERT GRID","NIGHT STEEL"),
        V("MAMMOTH_APC","Mammoth APC","Ground",18,8,"IRON DUST","URBAN BLOCK","FOREST MESH"),
        V("SPECTER_BIKE","Specter Bike","Ground",34,2,"CARBON","SANDLINE","NEON NIGHT"),
        V("SKYHAWK","Skyhawk","Air",58,4,"GREY WING","DESERT AIR","NIGHT OPS"),
        V("RAVEN_VTOL","Raven VTOL","Air",49,8,"BLACKLINE","ARCTIC","NAVAL")
      };
      SaveOrReplace(veh,Root+"/VehicleCatalog.asset");

      AssetDatabase.SaveAssets();AssetDatabase.Refresh();
      Debug.Log("OnlyWar production catalogs seeded.");
    }

    static OnlyWarOperatorData Op(string id,string name,string role,string bio,params string[] skins)=>new(){id=id,displayName=name,role=role,biography=bio,skins=skins};
    static OnlyWarVehicleData V(string id,string name,string cat,float speed,int seats,params string[] skins)=>new(){id=id,displayName=name,category=cat,topSpeed=speed,seats=seats,skins=skins};
    static void SaveOrReplace(Object obj,string path){var old=AssetDatabase.LoadAssetAtPath<Object>(path);if(old)AssetDatabase.DeleteAsset(path);AssetDatabase.CreateAsset(obj,path);}
  }
}

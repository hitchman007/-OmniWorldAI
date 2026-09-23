using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarVehicleFactory : MonoBehaviour {
    public OnlyWarMaterialLibrary materials;

    public GameObject BuildMRV(Vector3 position) {
      Ensure();
      var root=new GameObject("WRAITH_MRV");root.transform.position=position;
      var rb=root.AddComponent<Rigidbody>();rb.mass=1850f;rb.centerOfMass=new Vector3(0,.65f,0);
      var ctrl=root.AddComponent<OnlyWarVehicleController>();
      var armor=materials.Get("mrv_armor",new Color(.12f,.15f,.15f),.55f,.35f);
      var glass=materials.Get("mrv_glass",new Color(.07f,.14f,.17f),.1f,.75f);
      var tire=materials.Get("mrv_tire",new Color(.018f,.02f,.021f),0f,.18f);

      Box(root.transform,"Chassis",new Vector3(0,1.0f,0),new Vector3(2.2f,.7f,4.4f),armor,true);
      Box(root.transform,"Cabin",new Vector3(0,1.75f,-.25f),new Vector3(1.9f,.95f,2.15f),armor,true);
      Box(root.transform,"Windshield",new Vector3(0,1.85f,-1.38f),new Vector3(1.55f,.58f,.06f),glass,false);
      Box(root.transform,"BumperF",new Vector3(0,.78f,-2.35f),new Vector3(2.35f,.32f,.28f),armor,true);
      Box(root.transform,"BumperR",new Vector3(0,.78f,2.35f),new Vector3(2.35f,.32f,.28f),armor,true);
      Box(root.transform,"TurretBase",new Vector3(0,2.35f,.55f),new Vector3(.82f,.22f,.82f),armor,true);
      Cylinder(root.transform,"TurretBarrel",new Vector3(0,2.48f,-.15f),new Vector3(.09f,.75f,.09f),armor,Quaternion.Euler(90,0,0),false);

      foreach(float x in new[]{-1.15f,1.15f}) foreach(float z in new[]{-1.55f,1.55f})
        Cylinder(root.transform,"Wheel",new Vector3(x,.62f,z),new Vector3(.52f,.23f,.52f),tire,Quaternion.Euler(0,0,90),true);

      ctrl.driverSeat=new GameObject("DriverSeat").transform;ctrl.driverSeat.SetParent(root.transform);ctrl.driverSeat.localPosition=new Vector3(-.45f,1.4f,-.4f);
      return root;
    }

    public GameObject BuildAPC(Vector3 position) {
      Ensure();var root=new GameObject("MAMMOTH_APC");root.transform.position=position;
      var rb=root.AddComponent<Rigidbody>();rb.mass=5200f;rb.centerOfMass=new Vector3(0,.75f,0);
      root.AddComponent<OnlyWarVehicleController>().motorForce=26000f;
      var armor=materials.Get("apc_armor",new Color(.16f,.18f,.17f),.6f,.3f);
      Box(root.transform,"Hull",new Vector3(0,1.05f,0),new Vector3(2.7f,1.1f,5.6f),armor,true);
      Box(root.transform,"Upper",new Vector3(0,1.9f,.2f),new Vector3(2.2f,.85f,3.2f),armor,true);
      Box(root.transform,"Turret",new Vector3(0,2.55f,-.25f),new Vector3(1.0f,.38f,1.2f),armor,true);
      Cylinder(root.transform,"Cannon",new Vector3(0,2.55f,-1.35f),new Vector3(.11f,1.15f,.11f),armor,Quaternion.Euler(90,0,0),false);
      return root;
    }

    void Ensure(){if(!materials)materials=FindFirstObjectByType<OnlyWarMaterialLibrary>();if(!materials)materials=gameObject.AddComponent<OnlyWarMaterialLibrary>();}
    GameObject Box(Transform p,string n,Vector3 pos,Vector3 scale,Material mat,bool collider){var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name=n;g.transform.SetParent(p);g.transform.localPosition=pos;g.transform.localScale=scale;g.GetComponent<Renderer>().sharedMaterial=mat;if(!collider)Destroy(g.GetComponent<Collider>());return g;}
    GameObject Cylinder(Transform p,string n,Vector3 pos,Vector3 scale,Material mat,Quaternion rot,bool collider){var g=GameObject.CreatePrimitive(PrimitiveType.Cylinder);g.name=n;g.transform.SetParent(p);g.transform.localPosition=pos;g.transform.localScale=scale;g.transform.localRotation=rot;g.GetComponent<Renderer>().sharedMaterial=mat;if(!collider)Destroy(g.GetComponent<Collider>());return g;}
  }
}

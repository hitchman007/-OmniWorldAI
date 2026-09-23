using UnityEngine;

namespace OnlyWar {
  public enum OnlyWarMapId { Reach07, DustlineQuarry, BreakwaterPort, OrionBase, AlpineRelay }

  public sealed class OnlyWarMapDirector : MonoBehaviour {
    public OnlyWarMapId map = OnlyWarMapId.Reach07;
    public OnlyWarProceduralWorld world;
    public OnlyWarMaterialLibrary materials;
    public OnlyWarPropFactory props;
    public OnlyWarVehicleFactory vehicles;

    void Awake(){
      if(!world)world=FindFirstObjectByType<OnlyWarProceduralWorld>();
      if(!materials)materials=FindFirstObjectByType<OnlyWarMaterialLibrary>();
      if(!props)props=FindFirstObjectByType<OnlyWarPropFactory>();
      if(!vehicles)vehicles=FindFirstObjectByType<OnlyWarVehicleFactory>();
    }

    public void Build(OnlyWarMapId id){
      map=id;
      if(!world)return;
      switch(id){
        case OnlyWarMapId.Reach07: Configure(707,5,5,42,12); break;
        case OnlyWarMapId.DustlineQuarry: Configure(1317,4,4,54,15); break;
        case OnlyWarMapId.BreakwaterPort: Configure(2409,5,3,48,14); break;
        case OnlyWarMapId.OrionBase: Configure(4051,4,5,46,13); break;
        case OnlyWarMapId.AlpineRelay: Configure(9911,3,5,58,15); break;
      }
      world.Build();
      Decorate(id);
    }

    void Configure(int seed,int x,int z,float block,float road){
      world.seed=seed;world.blocksX=x;world.blocksZ=z;world.blockSize=block;world.roadWidth=road;
    }

    void Decorate(OnlyWarMapId id){
      if(!props)return;
      var rng=new System.Random((int)id*1009+71);
      int count=id==OnlyWarMapId.Reach07?28:36;
      for(int i=0;i<count;i++){
        Vector3 p=new Vector3((float)(rng.NextDouble()-.5)*180f,.2f,(float)(rng.NextDouble()-.5)*180f);
        if(i%4==0)props.Crate(p);
        else if(i%4==1)props.Barrier(p,Quaternion.Euler(0,rng.Next(0,180),0));
        else if(i%4==2)props.Sandbag(p+Vector3.up*.25f,Quaternion.Euler(0,rng.Next(0,180),0));
        else props.Lamp(p);
      }
      if(vehicles){
        vehicles.BuildMRV(new Vector3(16,0,24));
        if(id!=OnlyWarMapId.AlpineRelay)vehicles.BuildAPC(new Vector3(-24,0,-18));
      }
    }
  }
}

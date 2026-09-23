using UnityEngine;

namespace OnlyWar {
  [CreateAssetMenu(menuName="OnlyWar/Map Definition")]
  public sealed class OnlyWarMapDefinition : ScriptableObject {
    public string mapId="RIFT_HARBOR";
    public string displayName="Rift Harbor";
    public Vector2 size=new(420,420);
    public string biome="Coastal Industrial";
    public int targetPlayers=10;
    public bool supportsBattleRoyale;
    public bool supportsExtraction;
    public Vector3[] teamASpawns;
    public Vector3[] teamBSpawns;
    public Vector3[] objectivePoints;
  }
}

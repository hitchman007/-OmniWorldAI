using UnityEngine;

namespace OnlyWar {
  [CreateAssetMenu(menuName="OnlyWar/Match Rules")]
  public sealed class OnlyWarMatchRules : ScriptableObject {
    public string id = "TEAM_STRIKE";
    public GameMode mode = GameMode.TeamStrike;
    public int maxPlayers = 12;
    public int teamSize = 6;
    public int scoreLimit = 50;
    public float timeLimitSeconds = 480f;
    public bool respawn = true;
    public float respawnDelay = 4f;
    public bool friendlyFire;
    public bool rankedEligible = true;
    public OnlyWarMapId[] mapRotation;
  }
}

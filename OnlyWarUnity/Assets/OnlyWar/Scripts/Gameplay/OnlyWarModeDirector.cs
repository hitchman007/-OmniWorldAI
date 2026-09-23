using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarModeDirector : MonoBehaviour {
    public Transform[] teamASpawns;
    public Transform[] teamBSpawns;
    public Transform[] objectives;
    public float battleRoyaleStartRadius = 450f;
    public float battleRoyaleEndRadius = 35f;
    public float battleRoyaleShrinkSeconds = 720f;
    public Transform zoneCenter;
    float zoneT;

    public void StartMode(GameMode mode) {
      zoneT = 0f;
      var g = OnlyWarGame.I;
      if (!g) return;
      g.mode = mode;
      g.matchSeconds = mode == GameMode.BattleRoyale ? 900f : mode == GameMode.Extraction ? 1200f : 480f;
    }

    void Update() {
      var g = OnlyWarGame.I;
      if (!g || !g.matchLive || g.mode != GameMode.BattleRoyale || !zoneCenter || !g.player) return;
      zoneT = Mathf.Clamp01(zoneT + Time.deltaTime / Mathf.Max(1f, battleRoyaleShrinkSeconds));
      float radius = Mathf.Lerp(battleRoyaleStartRadius, battleRoyaleEndRadius, zoneT);
      Vector3 p = g.player.transform.position; p.y = zoneCenter.position.y;
      if (Vector3.Distance(p, zoneCenter.position) > radius) {
        var d = g.player.GetComponent<OnlyWarDamageable>();
        d?.ApplyDamage(8f * Time.deltaTime);
      }
      g.hud?.SetObjective("ZONE " + Mathf.CeilToInt(radius) + "m");
    }
  }
}

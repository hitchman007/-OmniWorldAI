using UnityEngine;

namespace OnlyWar {
  public enum ScorestreakType { UAV, CounterUAV, Sentry, ReconDrone, AttackDrone, PrecisionStrike, VTOL }

  public sealed class OnlyWarScorestreaks : MonoBehaviour {
    public int score;
    public int uavCost = 400, droneCost = 700, strikeCost = 1000;
    public System.Action<ScorestreakType> onReady;
    public System.Action<ScorestreakType> onActivated;
    bool uavReady, droneReady, strikeReady;

    public void AddScore(int value) {
      score += Mathf.Max(0,value);
      if (!uavReady && score >= uavCost) { uavReady=true; onReady?.Invoke(ScorestreakType.UAV); }
      if (!droneReady && score >= droneCost) { droneReady=true; onReady?.Invoke(ScorestreakType.AttackDrone); }
      if (!strikeReady && score >= strikeCost) { strikeReady=true; onReady?.Invoke(ScorestreakType.PrecisionStrike); }
    }

    public bool Activate(ScorestreakType type) {
      bool ready = type switch {
        ScorestreakType.UAV => uavReady,
        ScorestreakType.AttackDrone => droneReady,
        ScorestreakType.PrecisionStrike => strikeReady,
        _ => false
      };
      if (!ready) return false;
      if (type==ScorestreakType.UAV) uavReady=false;
      if (type==ScorestreakType.AttackDrone) droneReady=false;
      if (type==ScorestreakType.PrecisionStrike) strikeReady=false;
      onActivated?.Invoke(type);
      return true;
    }
  }
}

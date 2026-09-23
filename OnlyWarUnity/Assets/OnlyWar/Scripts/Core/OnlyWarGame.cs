using UnityEngine;

namespace OnlyWar {
  public enum GameMode { TeamStrike, Frontline, SearchDestroy, KillConfirmed, Hardpoint, BattleRoyale, Extraction }
  public enum QualityTier { Low, Medium, High, Ultra }

  public sealed class OnlyWarGame : MonoBehaviour {
    public static OnlyWarGame I { get; private set; }

    [Header("Match")]
    public GameMode mode = GameMode.TeamStrike;
    public int teamAScore;
    public int teamBScore;
    public float matchSeconds = 480f;
    public bool matchLive;

    [Header("Services")]
    public OnlyWarPlayerMotor player;
    public OnlyWarWeaponController weapons;
    public OnlyWarHUD hud;
    public OnlyWarQuality quality;
    public OnlyWarModeDirector modes;

    void Awake() {
      if (I != null && I != this) { Destroy(gameObject); return; }
      I = this;
      DontDestroyOnLoad(gameObject);
      Application.targetFrameRate = 60;
      QualitySettings.vSyncCount = 0;
    }

    void Start() {
      quality?.Apply(QualityTier.High);
      modes?.StartMode(mode);
      matchLive = true;
      hud?.Bind(this);
    }

    void Update() {
      if (!matchLive) return;
      matchSeconds = Mathf.Max(0f, matchSeconds - Time.deltaTime);
      hud?.RefreshMatch(teamAScore, teamBScore, matchSeconds, mode);
      if (matchSeconds <= 0f) matchLive = false;
    }

    public void AddScore(int team, int amount = 1) {
      if (team == 0) teamAScore += amount; else teamBScore += amount;
    }
  }
}

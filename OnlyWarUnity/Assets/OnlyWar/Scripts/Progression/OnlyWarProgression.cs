using System;
using UnityEngine;

namespace OnlyWar {
  public enum RankedDivision { Rookie, Veteran, Elite, Pro, Master, Grandmaster, Legendary }

  [Serializable] public sealed class OnlyWarProfileData {
    public string playerId = "LOCAL";
    public int level = 1;
    public int xp;
    public int credits = 2400;
    public int premiumCurrency;
    public RankedDivision ranked = RankedDivision.Rookie;
    public int rankedPoints;
    public int battlePassTier;
    public int battlePassXp;
  }

  public sealed class OnlyWarProgression : MonoBehaviour {
    public OnlyWarProfileData data = new();

    public void AddXP(int value) {
      data.xp += Mathf.Max(0,value);
      while (data.xp >= XpForNextLevel(data.level)) {
        data.xp -= XpForNextLevel(data.level);
        data.level++;
      }
    }

    public void AddRankedPoints(int delta) {
      data.rankedPoints = Mathf.Max(0,data.rankedPoints+delta);
      data.ranked = DivisionFor(data.rankedPoints);
    }

    public void AddBattlePassXp(int value) {
      data.battlePassXp += Mathf.Max(0,value);
      while (data.battlePassXp >= 1000) { data.battlePassXp -= 1000; data.battlePassTier++; }
    }

    static int XpForNextLevel(int level) => 850 + level * 150;
    static RankedDivision DivisionFor(int p) =>
      p >= 8000 ? RankedDivision.Legendary :
      p >= 6500 ? RankedDivision.Grandmaster :
      p >= 5000 ? RankedDivision.Master :
      p >= 3500 ? RankedDivision.Pro :
      p >= 2200 ? RankedDivision.Elite :
      p >= 1000 ? RankedDivision.Veteran : RankedDivision.Rookie;
  }
}

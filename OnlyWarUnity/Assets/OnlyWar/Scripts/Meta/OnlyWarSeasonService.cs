using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarSeasonService : MonoBehaviour {
    public string seasonId="REACH-S1";
    public string seasonName="First Contact";
    public long startsUtc;
    public long endsUtc;
    public OnlyWarChallengeSystem challenges;
    public OnlyWarProgression progression;

    public bool Active{
      get{
        long now=System.DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        return (startsUtc<=0||now>=startsUtc)&&(endsUtc<=0||now<=endsUtc);
      }
    }

    public void AwardMatch(int xp,int battlePassXp){
      if(!Active||!progression)return;
      progression.AddXP(xp);progression.AddBattlePassXp(battlePassXp);
    }
  }
}

using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarOnlineBootstrap : MonoBehaviour {
    public OnlyWarHttpMatchClient client;
    public string mode = "TEAM_STRIKE";
    public bool autoQueue;

    void Start() {
      if(!client)client=FindFirstObjectByType<OnlyWarHttpMatchClient>();
      if(autoQueue&&client)client.Queue(mode);
    }

    public void QueueTeamStrike(){if(client)client.Queue("TEAM_STRIKE");}
    public void QueueFrontline(){if(client)client.Queue("FRONTLINE");}
    public void QueueBattleRoyale(){if(client)client.Queue("BATTLE_ROYALE");}
    public void QueueExtraction(){if(client)client.Queue("BLACK_SITE");}
  }
}

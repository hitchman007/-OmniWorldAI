using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public enum LobbyPage { Play, Loadout, Operator, Garage, Store, Ranked, Clan, BattlePass }

  public sealed class OnlyWarLobbyController : MonoBehaviour {
    public LobbyPage page = LobbyPage.Play;
    public GameMode selectedMode = GameMode.TeamStrike;
    public OnlyWarLoadoutService loadouts;
    public OnlyWarProgression progression;
    public OnlyWarOnlineBootstrap online;

    readonly Dictionary<LobbyPage, GameObject> pages = new();

    public void Register(LobbyPage id, GameObject root) {
      pages[id] = root;
      root.SetActive(id == page);
    }

    public void Open(int pageIndex) {
      page = (LobbyPage)pageIndex;
      foreach (var kv in pages) if (kv.Value) kv.Value.SetActive(kv.Key == page);
    }

    public void SelectMode(int mode) => selectedMode = (GameMode)mode;

    public void DeployOnline() {
      if(!online)return;
      switch(selectedMode) {
        case GameMode.BattleRoyale: online.QueueBattleRoyale(); break;
        case GameMode.Extraction: online.QueueExtraction(); break;
        case GameMode.Frontline: online.QueueFrontline(); break;
        default: online.QueueTeamStrike(); break;
      }
    }

    public void EquipLoadout(int index)=>loadouts?.Select(index);
  }
}

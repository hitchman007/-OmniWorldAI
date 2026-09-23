using UnityEngine;
using UnityEngine.UI;

namespace OnlyWar {
  public sealed class OnlyWarHUD : MonoBehaviour {
    public Text modeText, scoreText, timerText, objectiveText, ammoText, weaponText, stanceText;
    public Image healthFill, armorFill;
    OnlyWarGame game;

    public void Bind(OnlyWarGame g) => game = g;

    public void RefreshMatch(int a, int b, float seconds, GameMode mode) {
      if (modeText) modeText.text = mode.ToString().ToUpperInvariant();
      if (scoreText) scoreText.text = a + " — " + b;
      if (timerText) timerText.text = Mathf.FloorToInt(seconds / 60f).ToString("00") + ":" + Mathf.FloorToInt(seconds % 60f).ToString("00");
      if (game && game.player) {
        var d = game.player.GetComponent<OnlyWarDamageable>();
        if (d && healthFill) healthFill.fillAmount = d.Health01;
        if (armorFill && d) armorFill.fillAmount = Mathf.Clamp01(d.armor / 100f);
        if (stanceText) stanceText.text = game.player.IsCrouched ? "CROUCHED" : "STANDING";
      }
    }

    public void RefreshWeapon(string name, int mag, int reserve, bool reloading) {
      if (weaponText) weaponText.text = name;
      if (ammoText) ammoText.text = reloading ? "RELOADING" : mag + " / " + reserve;
    }

    public void SetObjective(string value) { if (objectiveText) objectiveText.text = value; }
  }
}

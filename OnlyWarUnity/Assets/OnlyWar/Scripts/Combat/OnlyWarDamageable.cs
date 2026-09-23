using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarDamageable : MonoBehaviour {
    public int team = 1;
    public float maxHealth = 100f;
    public float armor = 100f;
    public Transform head;
    public System.Action<OnlyWarDamageable> onKilled;
    float health;

    void Awake() => health = maxHealth;

    public void ApplyDamage(float amount, bool headshot = false) {
      if (health <= 0f) return;
      float absorbed = Mathf.Min(armor, amount * .6f);
      armor -= absorbed;
      health -= amount - absorbed;
      if (health <= 0f) {
        health = 0f;
        onKilled?.Invoke(this);
        gameObject.SetActive(false);
      }
    }

    public void Revive(float healthPercent=1f,float armorValue=100f){
      health=maxHealth*Mathf.Clamp01(healthPercent);
      armor=Mathf.Max(0,armorValue);
      gameObject.SetActive(true);
    }

    void OnEnable(){if(health<=0)Revive();}

    public float Health01 => maxHealth <= 0 ? 0 : health / maxHealth;
  }
}

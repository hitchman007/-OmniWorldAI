using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarExtractionZone : MonoBehaviour {
    public float activationSeconds = 8f;
    public float extractSeconds = 12f;
    public bool requiresDualSwitch;
    public System.Action onExtractionCalled, onExtracted;
    bool active;
    float timer;

    public void Activate() {
      if (active) return;
      active=true; timer=extractSeconds; onExtractionCalled?.Invoke();
    }

    void Update() {
      if (!active) return;
      timer -= Time.deltaTime;
      if (timer <= 0f) { active=false; onExtracted?.Invoke(); }
    }
  }
}

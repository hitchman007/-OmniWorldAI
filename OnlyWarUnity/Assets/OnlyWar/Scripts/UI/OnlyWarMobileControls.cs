using UnityEngine;
using UnityEngine.EventSystems;

namespace OnlyWar {
  public sealed class OnlyWarMobileStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
    public OnlyWarInput input;
    public RectTransform knob;
    public float radius = 70f;
    Vector2 origin;
    public void OnPointerDown(PointerEventData e) { origin = e.position; OnDrag(e); }
    public void OnDrag(PointerEventData e) {
      Vector2 d = Vector2.ClampMagnitude(e.position - origin, radius);
      if (knob) knob.anchoredPosition = d;
      input?.SetMobileMove(d / radius);
    }
    public void OnPointerUp(PointerEventData e) { if (knob) knob.anchoredPosition = Vector2.zero; input?.SetMobileMove(Vector2.zero); }
  }

  public sealed class OnlyWarLookPad : MonoBehaviour, IDragHandler {
    public OnlyWarInput input;
    public float sensitivity = .12f;
    public void OnDrag(PointerEventData e) => input?.AddMobileLook(e.delta * sensitivity);
  }

  public sealed class OnlyWarHoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public enum HoldAction { Fire, Ads, Sprint }
    public OnlyWarInput input;
    public HoldAction action;
    public void OnPointerDown(PointerEventData e) => Set(true);
    public void OnPointerUp(PointerEventData e) => Set(false);
    void Set(bool v) {
      if (!input) return;
      if (action == HoldAction.Fire) input.SetFire(v);
      if (action == HoldAction.Ads) input.SetAds(v);
      if (action == HoldAction.Sprint) input.SetSprint(v);
    }
  }

  public sealed class OnlyWarTapButton : MonoBehaviour, IPointerClickHandler {
    public enum TapAction { Jump, Crouch, Reload, Interact, Grenade, Swap }
    public OnlyWarInput input;
    public TapAction action;
    public void OnPointerClick(PointerEventData e) {
      if (!input) return;
      switch (action) {
        case TapAction.Jump: input.PressJump(); break;
        case TapAction.Crouch: input.PressCrouch(); break;
        case TapAction.Reload: input.PressReload(); break;
        case TapAction.Interact: input.PressInteract(); break;
        case TapAction.Grenade: input.PressGrenade(); break;
        case TapAction.Swap: input.PressSwap(); break;
      }
    }
  }
}

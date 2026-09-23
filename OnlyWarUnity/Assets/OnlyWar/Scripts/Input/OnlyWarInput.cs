using UnityEngine;
using UnityEngine.InputSystem;

namespace OnlyWar {
  public sealed class OnlyWarInput : MonoBehaviour {
    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }
    public bool FireHeld { get; private set; }
    public bool AdsHeld { get; private set; }
    public bool SprintHeld { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool CrouchPressed { get; private set; }
    public bool ReloadPressed { get; private set; }
    public bool InteractPressed { get; private set; }
    public bool GrenadePressed { get; private set; }
    public bool SwapPressed { get; private set; }

    Vector2 mobileMove, mobileLook;
    bool mobileFire, mobileAds, mobileSprint;
    bool jumpLatch, crouchLatch, reloadLatch, interactLatch, grenadeLatch, swapLatch;

    void Update() {
      var kb = Keyboard.current;
      var mouse = Mouse.current;
      var pad = Gamepad.current;

      Vector2 desktopMove = Vector2.zero;
      if (kb != null) {
        desktopMove.x = (kb.dKey.isPressed ? 1 : 0) - (kb.aKey.isPressed ? 1 : 0);
        desktopMove.y = (kb.wKey.isPressed ? 1 : 0) - (kb.sKey.isPressed ? 1 : 0);
      }
      if (pad != null) desktopMove = pad.leftStick.ReadValue();

      Vector2 desktopLook = mouse != null ? mouse.delta.ReadValue() * 0.045f : Vector2.zero;
      if (pad != null) desktopLook += pad.rightStick.ReadValue() * 3f;

      Move = Vector2.ClampMagnitude(desktopMove + mobileMove, 1f);
      Look = desktopLook + mobileLook;

      FireHeld = mobileFire || (mouse != null && mouse.leftButton.isPressed) || (pad != null && pad.rightTrigger.ReadValue() > .3f);
      AdsHeld = mobileAds || (mouse != null && mouse.rightButton.isPressed) || (pad != null && pad.leftTrigger.ReadValue() > .3f);
      SprintHeld = mobileSprint || (kb != null && kb.leftShiftKey.isPressed) || (pad != null && pad.leftStickButton.isPressed);

      JumpPressed = Consume(ref jumpLatch) || (kb != null && kb.spaceKey.wasPressedThisFrame) || (pad != null && pad.buttonSouth.wasPressedThisFrame);
      CrouchPressed = Consume(ref crouchLatch) || (kb != null && kb.cKey.wasPressedThisFrame) || (pad != null && pad.buttonEast.wasPressedThisFrame);
      ReloadPressed = Consume(ref reloadLatch) || (kb != null && kb.rKey.wasPressedThisFrame) || (pad != null && pad.buttonWest.wasPressedThisFrame);
      InteractPressed = Consume(ref interactLatch) || (kb != null && kb.eKey.wasPressedThisFrame);
      GrenadePressed = Consume(ref grenadeLatch) || (kb != null && kb.gKey.wasPressedThisFrame);
      SwapPressed = Consume(ref swapLatch) || (kb != null && kb.qKey.wasPressedThisFrame);
    }

    static bool Consume(ref bool v) { if (!v) return false; v = false; return true; }

    public void SetMobileMove(Vector2 v) => mobileMove = Vector2.ClampMagnitude(v, 1f);
    public void AddMobileLook(Vector2 v) { mobileLook = v; CancelInvoke(nameof(ClearLook)); Invoke(nameof(ClearLook), .02f); }
    void ClearLook() => mobileLook = Vector2.zero;
    public void SetFire(bool v) => mobileFire = v;
    public void SetAds(bool v) => mobileAds = v;
    public void SetSprint(bool v) => mobileSprint = v;
    public void PressJump() => jumpLatch = true;
    public void PressCrouch() => crouchLatch = true;
    public void PressReload() => reloadLatch = true;
    public void PressInteract() => interactLatch = true;
    public void PressGrenade() => grenadeLatch = true;
    public void PressSwap() => swapLatch = true;
  }
}

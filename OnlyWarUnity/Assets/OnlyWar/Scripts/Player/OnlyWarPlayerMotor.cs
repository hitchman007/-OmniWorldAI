using UnityEngine;

namespace OnlyWar {
  [RequireComponent(typeof(CharacterController))]
  public sealed class OnlyWarPlayerMotor : MonoBehaviour {
    public OnlyWarInput input;
    public Camera viewCamera;
    public Transform cameraPivot;
    public float walkSpeed = 4.8f;
    public float sprintSpeed = 7.6f;
    public float crouchSpeed = 2.7f;
    public float gravity = -22f;
    public float jumpHeight = 1.25f;
    public float lookSensitivity = .11f;
    public float adsSensitivityMultiplier = .58f;
    public float standHeight = 1.82f;
    public float crouchHeight = 1.18f;

    CharacterController cc;
    float pitch;
    float verticalVelocity;
    bool crouched;

    void Awake() {
      cc = GetComponent<CharacterController>();
      if (!input) input = FindFirstObjectByType<OnlyWarInput>();
      if (!viewCamera) viewCamera = Camera.main;
      if (!cameraPivot && viewCamera) cameraPivot = viewCamera.transform.parent ? viewCamera.transform.parent : viewCamera.transform;
    }

    void Update() {
      if (!input || !viewCamera) return;

      if (input.CrouchPressed) crouched = !crouched;
      cc.height = Mathf.Lerp(cc.height, crouched ? crouchHeight : standHeight, 14f * Time.deltaTime);
      cc.center = Vector3.up * cc.height * .5f;

      float sensitivity = lookSensitivity * (input.AdsHeld ? adsSensitivityMultiplier : 1f);
      transform.Rotate(0f, input.Look.x * sensitivity, 0f);
      pitch = Mathf.Clamp(pitch - input.Look.y * sensitivity, -84f, 84f);
      cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);

      Vector3 wish = transform.forward * input.Move.y + transform.right * input.Move.x;
      wish = Vector3.ClampMagnitude(wish, 1f);
      float speed = crouched ? crouchSpeed : input.SprintHeld ? sprintSpeed : walkSpeed;

      if (cc.isGrounded) {
        if (verticalVelocity < 0f) verticalVelocity = -2f;
        if (input.JumpPressed && !crouched) verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
      }
      verticalVelocity += gravity * Time.deltaTime;
      cc.Move((wish * speed + Vector3.up * verticalVelocity) * Time.deltaTime);

      float targetFov = input.AdsHeld ? 54f : input.SprintHeld ? 78f : 72f;
      viewCamera.fieldOfView = Mathf.Lerp(viewCamera.fieldOfView, targetFov, 12f * Time.deltaTime);
    }

    public bool IsCrouched => crouched;
  }
}

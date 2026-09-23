using UnityEngine;

namespace OnlyWar {
  [RequireComponent(typeof(Rigidbody))]
  public sealed class OnlyWarVehicleController : MonoBehaviour {
    public float motorForce = 16000f;
    public float steerTorque = 3500f;
    public float maxSpeed = 26f;
    public Transform driverSeat;
    public OnlyWarInput input;
    Rigidbody rb;
    bool occupied;

    void Awake() { rb = GetComponent<Rigidbody>(); }

    void FixedUpdate() {
      if (!occupied || !input) return;
      float forward = Vector3.Dot(rb.linearVelocity, transform.forward);
      if (Mathf.Abs(forward) < maxSpeed) rb.AddForce(transform.forward * input.Move.y * motorForce, ForceMode.Force);
      rb.AddTorque(Vector3.up * input.Move.x * steerTorque, ForceMode.Force);
    }

    public void Enter(OnlyWarInput source) { input = source; occupied = true; }
    public void Exit() { occupied = false; input = null; }
  }
}

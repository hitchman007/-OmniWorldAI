using UnityEngine;
using UnityEngine.AI;

namespace OnlyWar {
  [RequireComponent(typeof(NavMeshAgent))]
  public sealed class OnlyWarBot : MonoBehaviour {
    public int team = 1;
    public Transform eye;
    public float sight = 55f;
    public float fireRange = 32f;
    public float damage = 9f;
    public float fireInterval = .45f;
    NavMeshAgent agent;
    OnlyWarDamageable target;
    float nextFire;

    void Awake() => agent = GetComponent<NavMeshAgent>();

    void Update() {
      if (!target || !target.gameObject.activeInHierarchy) Acquire();
      if (!target) return;
      float d = Vector3.Distance(transform.position, target.transform.position);
      if (d > sight) { target = null; return; }
      agent.isStopped = d < fireRange * .75f;
      if (!agent.isStopped) agent.SetDestination(target.transform.position);
      Vector3 dir = (target.transform.position + Vector3.up - (eye ? eye.position : transform.position)).normalized;
      if (Physics.Raycast(eye ? eye.position : transform.position + Vector3.up, dir, out var hit, fireRange) &&
          hit.collider.GetComponentInParent<OnlyWarDamageable>() == target && Time.time >= nextFire) {
        nextFire = Time.time + fireInterval;
        target.ApplyDamage(damage);
      }
    }

    void Acquire() {
      float best = float.MaxValue; OnlyWarDamageable chosen = null;
      foreach (var d in FindObjectsByType<OnlyWarDamageable>(FindObjectsSortMode.None)) {
        if (!d.gameObject.activeInHierarchy || d.team == team) continue;
        float dist = Vector3.SqrMagnitude(d.transform.position - transform.position);
        if (dist < best) { best = dist; chosen = d; }
      }
      target = chosen;
    }
  }
}

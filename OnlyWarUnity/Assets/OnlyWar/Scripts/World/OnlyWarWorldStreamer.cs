using System.Collections.Generic;
using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarWorldStreamer : MonoBehaviour {
    [System.Serializable] public class Cell {
      public Vector2Int coord;
      public GameObject root;
      public float loadDistance = 180f;
    }
    public Transform viewer;
    public List<Cell> cells = new();

    void Update() {
      if (!viewer) return;
      Vector3 p = viewer.position;
      foreach (var c in cells) {
        if (!c.root) continue;
        Vector3 center = c.root.transform.position;
        bool active = (new Vector2(p.x-center.x,p.z-center.z)).sqrMagnitude <= c.loadDistance*c.loadDistance;
        if (c.root.activeSelf != active) c.root.SetActive(active);
      }
    }
  }
}

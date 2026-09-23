using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnlyWar {
  public sealed class OnlyWarMiniMap : MonoBehaviour {
    public RectTransform root;
    public RectTransform playerIcon;
    public GameObject friendlyIconPrefab;
    public GameObject enemyIconPrefab;
    public Transform player;
    public float worldRadius=55f;
    public bool uavActive;
    readonly Dictionary<OnlyWarDamageable,RectTransform> icons=new();

    void LateUpdate(){
      if(!root||!player)return;
      foreach(var d in FindObjectsByType<OnlyWarDamageable>(FindObjectsSortMode.None)){
        if(!d||d.transform==player)continue;
        bool friendly=d.team==(player.GetComponent<OnlyWarDamageable>()?.team??0);
        if(!friendly&&!uavActive){if(icons.TryGetValue(d,out var hidden))hidden.gameObject.SetActive(false);continue;}
        if(!icons.TryGetValue(d,out var icon)){
          var prefab=friendly?friendlyIconPrefab:enemyIconPrefab;if(!prefab)continue;
          icon=Instantiate(prefab,root).GetComponent<RectTransform>();icons[d]=icon;
        }
        icon.gameObject.SetActive(d.gameObject.activeInHierarchy);
        Vector3 delta=d.transform.position-player.position;
        Vector2 p=new(delta.x,delta.z);p=Vector2.ClampMagnitude(p,worldRadius)/worldRadius*(root.rect.width*.45f);
        float angle=-player.eulerAngles.y*Mathf.Deg2Rad;
        icon.anchoredPosition=new Vector2(p.x*Mathf.Cos(angle)-p.y*Mathf.Sin(angle),p.x*Mathf.Sin(angle)+p.y*Mathf.Cos(angle));
      }
      if(playerIcon)playerIcon.localRotation=Quaternion.Euler(0,0,-player.eulerAngles.y);
    }
  }
}

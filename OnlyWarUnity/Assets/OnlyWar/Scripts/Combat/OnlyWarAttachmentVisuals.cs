using UnityEngine;

namespace OnlyWar {
  public sealed class OnlyWarAttachmentVisuals : MonoBehaviour {
    public Transform opticSocket, muzzleSocket, underbarrelSocket, magazineSocket, stockSocket;
    GameObject optic,muzzle,underbarrel,magazine,stock;

    public void EquipOptic(GameObject prefab)=>Replace(ref optic,prefab,opticSocket);
    public void EquipMuzzle(GameObject prefab)=>Replace(ref muzzle,prefab,muzzleSocket);
    public void EquipUnderbarrel(GameObject prefab)=>Replace(ref underbarrel,prefab,underbarrelSocket);
    public void EquipMagazine(GameObject prefab)=>Replace(ref magazine,prefab,magazineSocket);
    public void EquipStock(GameObject prefab)=>Replace(ref stock,prefab,stockSocket);

    static void Replace(ref GameObject current,GameObject prefab,Transform socket){
      if(current)Object.Destroy(current);current=null;
      if(prefab&&socket){current=Object.Instantiate(prefab,socket);current.transform.localPosition=Vector3.zero;current.transform.localRotation=Quaternion.identity;}
    }
  }
}

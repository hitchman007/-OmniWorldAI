using System.Collections;
using UnityEngine;

namespace OnlyWar {
  public enum OperatorSkillType { KineticShield, ReconPulse, Overdrive, MicroDrone, ShockLauncher }

  public sealed class OnlyWarOperatorSkill : MonoBehaviour {
    public OperatorSkillType skill=OperatorSkillType.KineticShield;
    public float charge;
    public float required=100f;
    public float duration=8f;
    public bool active;
    public event System.Action<OperatorSkillType,bool> OnState;

    public void AddCharge(float value)=>charge=Mathf.Min(required,charge+Mathf.Max(0,value));
    public bool Activate(){
      if(active||charge<required)return false;
      charge=0;StartCoroutine(Run());return true;
    }
    IEnumerator Run(){
      active=true;OnState?.Invoke(skill,true);
      var motor=GetComponent<OnlyWarPlayerMotor>();
      var dmg=GetComponent<OnlyWarDamageable>();
      float oldArmor=dmg?dmg.armor:0;
      if(skill==OperatorSkillType.KineticShield&&dmg)dmg.armor+=125f;
      if(skill==OperatorSkillType.Overdrive&&motor){motor.walkSpeed*=1.22f;motor.sprintSpeed*=1.22f;}
      yield return new WaitForSeconds(duration);
      if(skill==OperatorSkillType.KineticShield&&dmg)dmg.armor=Mathf.Min(dmg.armor,oldArmor+25f);
      if(skill==OperatorSkillType.Overdrive&&motor){motor.walkSpeed/=1.22f;motor.sprintSpeed/=1.22f;}
      active=false;OnState?.Invoke(skill,false);
    }
  }
}

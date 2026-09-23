using UnityEngine;

namespace OnlyWar {
  [RequireComponent(typeof(Animator))]
  public sealed class OnlyWarThirdPersonAnimator : MonoBehaviour {
    public CharacterController controller;
    public OnlyWarInput input;
    public Animator animator;
    public Transform aimTarget;

    static readonly int Speed=Animator.StringToHash("Speed");
    static readonly int Strafe=Animator.StringToHash("Strafe");
    static readonly int Grounded=Animator.StringToHash("Grounded");
    static readonly int Crouch=Animator.StringToHash("Crouch");
    static readonly int Sprint=Animator.StringToHash("Sprint");
    static readonly int Ads=Animator.StringToHash("ADS");
    static readonly int Fire=Animator.StringToHash("Fire");
    static readonly int Reload=Animator.StringToHash("Reload");

    void Awake(){
      if(!animator)animator=GetComponent<Animator>();
      if(!controller)controller=GetComponentInParent<CharacterController>();
      if(!input)input=FindFirstObjectByType<OnlyWarInput>();
    }

    void Update(){
      if(!animator||!input)return;
      animator.SetFloat(Speed,input.Move.y,.12f,Time.deltaTime);
      animator.SetFloat(Strafe,input.Move.x,.12f,Time.deltaTime);
      animator.SetBool(Grounded,controller&&controller.isGrounded);
      animator.SetBool(Crouch,OnlyWarGame.I&&OnlyWarGame.I.player&&OnlyWarGame.I.player.IsCrouched);
      animator.SetBool(Sprint,input.SprintHeld);
      animator.SetBool(Ads,input.AdsHeld);
      if(input.FireHeld)animator.SetTrigger(Fire);
      if(input.ReloadPressed)animator.SetTrigger(Reload);
    }

    void OnAnimatorIK(int layerIndex){
      if(!animator||!aimTarget)return;
      animator.SetLookAtWeight(1f,.2f,.8f,.55f,.45f);
      animator.SetLookAtPosition(aimTarget.position);
    }
  }
}

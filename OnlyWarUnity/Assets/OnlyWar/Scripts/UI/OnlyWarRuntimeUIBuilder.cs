using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace OnlyWar {
  public sealed class OnlyWarRuntimeUIBuilder : MonoBehaviour {
    public OnlyWarInput input;
    public OnlyWarGame game;
    public OnlyWarWeaponController weapons;
    public OnlyWarOnlineBootstrap online;
    public Font font;
    Canvas canvas;
    GameObject lobby;
    GameObject hud;
    OnlyWarHUD hudController;

    void Awake() {
      if(!input)input=FindFirstObjectByType<OnlyWarInput>();
      if(!game)game=FindFirstObjectByType<OnlyWarGame>();
      if(!weapons)weapons=FindFirstObjectByType<OnlyWarWeaponController>();
      Build();
    }

    void Build() {
      if(FindFirstObjectByType<EventSystem>()==null){
        var es=new GameObject("EventSystem");
        es.AddComponent<EventSystem>();
        es.AddComponent<StandaloneInputModule>();
      }
      var cg=new GameObject("OnlyWar UI");
      canvas=cg.AddComponent<Canvas>();canvas.renderMode=RenderMode.ScreenSpaceOverlay;canvas.sortingOrder=50;
      cg.AddComponent<CanvasScaler>().uiScaleMode=CanvasScaler.ScaleMode.ScaleWithScreenSize;
      cg.GetComponent<CanvasScaler>().referenceResolution=new Vector2(1920,1080);
      cg.GetComponent<CanvasScaler>().matchWidthOrHeight=.5f;
      cg.AddComponent<GraphicRaycaster>();

      hud=Panel("HUD",cg.transform,new Color(0,0,0,0));
      hudController=hud.AddComponent<OnlyWarHUD>();
      BuildHud(hud.transform,hudController);
      BuildMobileControls(hud.transform);
      hud.SetActive(false);

      lobby=Panel("Lobby",cg.transform,new Color(.025f,.04f,.055f,1f));
      BuildLobby(lobby.transform);
    }

    void BuildHud(Transform root,OnlyWarHUD h){
      h.modeText=Label("Mode",root,"TEAM STRIKE",new Vector2(.5f,1),new Vector2(0,-35),180,34,13,TextAnchor.MiddleCenter);
      h.scoreText=Label("Score",root,"0 — 0",new Vector2(.5f,1),new Vector2(0,-68),180,28,12,TextAnchor.MiddleCenter);
      h.timerText=Label("Timer",root,"08:00",new Vector2(.5f,1),new Vector2(0,-96),180,28,11,TextAnchor.MiddleCenter);
      h.objectiveText=Label("Objective",root,"ELIMINATE HOSTILES",new Vector2(.5f,1),new Vector2(0,-128),340,30,10,TextAnchor.MiddleCenter);
      h.weaponText=Label("Weapon",root,"ARX-41",new Vector2(1,0),new Vector2(-105,75),200,24,10,TextAnchor.MiddleRight);
      h.ammoText=Label("Ammo",root,"30 / 150",new Vector2(1,0),new Vector2(-105,38),220,50,24,TextAnchor.MiddleRight);
      h.stanceText=Label("Stance",root,"STANDING",new Vector2(0,0),new Vector2(92,34),160,24,9,TextAnchor.MiddleLeft);

      h.healthFill=Bar("Health",root,new Vector2(0,0),new Vector2(108,85),190,8,Color.white);
      h.armorFill=Bar("Armor",root,new Vector2(0,0),new Vector2(108,65),190,8,new Color(.4f,.85f,.9f));

      var pause=Button("Pause",root,"Ⅱ",new Vector2(1,1),new Vector2(-55,-55),55,55,()=>Time.timeScale=Time.timeScale>0?0:1);
      pause.GetComponent<Image>().color=new Color(0,0,0,.48f);
    }

    void BuildMobileControls(Transform root){
      var joyBg=Panel("MoveStick",root,new Color(1,1,1,.08f));
      var jr=(RectTransform)joyBg.transform;jr.anchorMin=jr.anchorMax=new Vector2(0,0);jr.sizeDelta=new Vector2(170,170);jr.anchoredPosition=new Vector2(125,135);
      var knob=Panel("Knob",joyBg.transform,new Color(1,1,1,.14f));
      var kr=(RectTransform)knob.transform;kr.anchorMin=kr.anchorMax=new Vector2(.5f,.5f);kr.sizeDelta=new Vector2(70,70);kr.anchoredPosition=Vector2.zero;
      var stick=joyBg.AddComponent<OnlyWarMobileStick>();stick.input=input;stick.knob=kr;stick.radius=55;

      var look=Panel("LookPad",root,new Color(0,0,0,0));
      var lr=(RectTransform)look.transform;lr.anchorMin=new Vector2(.45f,0);lr.anchorMax=new Vector2(1,1);lr.offsetMin=lr.offsetMax=Vector2.zero;
      look.AddComponent<OnlyWarLookPad>().input=input;

      Hold("FIRE",root,new Vector2(1,0),new Vector2(-95,105),90,90,OnlyWarHoldButton.HoldAction.Fire);
      Hold("ADS",root,new Vector2(1,0),new Vector2(-205,170),76,58,OnlyWarHoldButton.HoldAction.Ads);
      Tap("JUMP",root,new Vector2(1,0),new Vector2(-205,92),76,58,OnlyWarTapButton.TapAction.Jump);
      Tap("RELOAD",root,new Vector2(1,0),new Vector2(-300,170),82,58,OnlyWarTapButton.TapAction.Reload);
      Tap("CROUCH",root,new Vector2(1,0),new Vector2(-300,92),82,58,OnlyWarTapButton.TapAction.Crouch);
      Tap("GRENADE",root,new Vector2(1,0),new Vector2(-396,170),86,58,OnlyWarTapButton.TapAction.Grenade);
      Tap("SWAP",root,new Vector2(1,0),new Vector2(-396,92),86,58,OnlyWarTapButton.TapAction.Swap);
      Hold("SPRINT",root,new Vector2(0,0),new Vector2(125,250),90,55,OnlyWarHoldButton.HoldAction.Sprint);
      Tap("USE",root,new Vector2(1,0),new Vector2(-95,215),76,55,OnlyWarTapButton.TapAction.Interact);
    }

    void BuildLobby(Transform root){
      Label("Brand",root,"ONLYWAR",new Vector2(0,1),new Vector2(120,-70),300,50,26,TextAnchor.MiddleLeft);
      Label("Sub",root,"TACTICAL OPEN COMBAT",new Vector2(0,1),new Vector2(120,-108),330,28,10,TextAnchor.MiddleLeft);

      var hero=Label("Hero",root,"ENTER THE\nWARZONE",new Vector2(0,.5f),new Vector2(300,40),520,180,48,TextAnchor.MiddleLeft);
      hero.fontStyle=FontStyle.Bold;

      Button("TeamStrike",root,"TEAM STRIKE",new Vector2(0,.5f),new Vector2(250,-100),190,55,()=>SelectMode(GameMode.TeamStrike));
      Button("Frontline",root,"FRONTLINE",new Vector2(0,.5f),new Vector2(455,-100),190,55,()=>SelectMode(GameMode.Frontline));
      Button("BR",root,"BATTLE ROYALE",new Vector2(0,.5f),new Vector2(660,-100),190,55,()=>SelectMode(GameMode.BattleRoyale));
      Button("Extraction",root,"BLACK SITE",new Vector2(0,.5f),new Vector2(865,-100),190,55,()=>SelectMode(GameMode.Extraction));

      var deploy=Button("Deploy",root,"DEPLOY →",new Vector2(0,.5f),new Vector2(260,-185),220,64,Deploy);
      deploy.GetComponent<Image>().color=new Color(.84f,.70f,.34f,1f);
      deploy.transform.Find("Text").GetComponent<Text>().color=Color.black;

      Label("Info",root,"LOADOUT  ·  OPERATORS  ·  GARAGE  ·  GUNSMITH  ·  RANKED",new Vector2(0,0),new Vector2(395,55),700,35,10,TextAnchor.MiddleLeft);
    }

    void SelectMode(GameMode mode){
      if(game)game.mode=mode;
      if(game&&game.modes)game.modes.StartMode(mode);
    }

    void Deploy(){
      lobby.SetActive(false);hud.SetActive(true);
      Time.timeScale=1;
      if(game){game.matchLive=true;hudController.Bind(game);}
      if(online){
        switch(game?game.mode:GameMode.TeamStrike){
          case GameMode.BattleRoyale: online.QueueBattleRoyale();break;
          case GameMode.Extraction: online.QueueExtraction();break;
          case GameMode.Frontline: online.QueueFrontline();break;
          default: online.QueueTeamStrike();break;
        }
      }
    }

    GameObject Panel(string name,Transform parent,Color color){
      var g=new GameObject(name);g.transform.SetParent(parent,false);
      var r=g.AddComponent<RectTransform>();r.anchorMin=Vector2.zero;r.anchorMax=Vector2.one;r.offsetMin=r.offsetMax=Vector2.zero;
      var im=g.AddComponent<Image>();im.color=color;return g;
    }

    Text Label(string name,Transform parent,string value,Vector2 anchor,Vector2 pos,float w,float h,int size,TextAnchor align){
      var g=new GameObject(name);g.transform.SetParent(parent,false);
      var r=g.AddComponent<RectTransform>();r.anchorMin=r.anchorMax=anchor;r.sizeDelta=new Vector2(w,h);r.anchoredPosition=pos;
      var t=g.AddComponent<Text>();t.text=value;t.font=font?font:Resources.GetBuiltinResource<Font>("Arial.ttf");t.fontSize=size;t.alignment=align;t.color=Color.white;t.raycastTarget=false;return t;
    }

    Button Button(string name,Transform parent,string label,Vector2 anchor,Vector2 pos,float w,float h,UnityEngine.Events.UnityAction action){
      var g=new GameObject(name);g.transform.SetParent(parent,false);
      var r=g.AddComponent<RectTransform>();r.anchorMin=r.anchorMax=anchor;r.sizeDelta=new Vector2(w,h);r.anchoredPosition=pos;
      var im=g.AddComponent<Image>();im.color=new Color(.08f,.11f,.14f,.86f);
      var b=g.AddComponent<Button>();b.targetGraphic=im;if(action!=null)b.onClick.AddListener(action);
      var t=Label("Text",g.transform,label,new Vector2(.5f,.5f),Vector2.zero,w,h,11,TextAnchor.MiddleCenter);t.fontStyle=FontStyle.Bold;
      return b;
    }

    void Hold(string label,Transform root,Vector2 anchor,Vector2 pos,float w,float h,OnlyWarHoldButton.HoldAction action){
      var b=Button(label,root,label,anchor,pos,w,h,null);var hold=b.gameObject.AddComponent<OnlyWarHoldButton>();hold.input=input;hold.action=action;
    }

    void Tap(string label,Transform root,Vector2 anchor,Vector2 pos,float w,float h,OnlyWarTapButton.TapAction action){
      var b=Button(label,root,label,anchor,pos,w,h,null);var tap=b.gameObject.AddComponent<OnlyWarTapButton>();tap.input=input;tap.action=action;
    }

    Image Bar(string name,Transform root,Vector2 anchor,Vector2 pos,float w,float h,Color color){
      var bg=new GameObject(name+"BG");bg.transform.SetParent(root,false);
      var br=bg.AddComponent<RectTransform>();br.anchorMin=br.anchorMax=anchor;br.sizeDelta=new Vector2(w,h);br.anchoredPosition=pos;
      bg.AddComponent<Image>().color=new Color(1,1,1,.12f);
      var fill=new GameObject(name+"Fill");fill.transform.SetParent(bg.transform,false);
      var fr=fill.AddComponent<RectTransform>();fr.anchorMin=new Vector2(0,0);fr.anchorMax=new Vector2(1,1);fr.offsetMin=fr.offsetMax=Vector2.zero;
      var im=fill.AddComponent<Image>();im.color=color;im.type=Image.Type.Filled;im.fillMethod=Image.FillMethod.Horizontal;im.fillOrigin=0;im.fillAmount=1f;return im;
    }
  }
}

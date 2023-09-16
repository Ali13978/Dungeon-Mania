using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour{
    public enum SkillRequire{
        fire, ice, electricity, dead
    }
    public SkillRequire skillRequire = SkillRequire.fire;
    public int valueSkillRequire;
    public float coolDown;
    public bool isCoolDown;
    public Image image;
    //public GameObject image2;
    bool isRequire;
    GameObject gameManager;
    AudioManager audioManager;
    string[] anim = new string[]{"shield", "bird", "whirpool", "ground", "shock"};
    PlayerManager playerManager;
    int index;
    public delegate void DelegateButton();
    public static event DelegateButton EventSkillButton;
    GameObject menu;
    GameObject pause;
    void Awake(){
        isCoolDown = false;
        index = transform.GetSiblingIndex();
        image = transform.GetChild(0).GetComponent<Image>();
        //image2 = transform.GetChild(1).gameObject;
        image.color = Color.grey;
        gameManager = GameObject.Find("GameManager");
        audioManager = gameManager.GetComponent<AudioManager>();
        playerManager = GameObject.Find("player").GetComponent<PlayerManager>();
        menu = GameObject.Find("MenuUi");
        pause = GameObject.Find("Pause");
    }

    void Start(){
        if( HeroInformation.player.characterList[(int)skillRequire].value >= valueSkillRequire )isRequire = true;
        CheckButton(false);
    }

    void OnEnable(){
        HeroInformation.SetButton += CheckButton;
        GameController.ContinueUpdateSkillButton += ContinueUpdateButton;
        RemoveArtifacte.removeArtifacte += CheckArtifacte;
        HeroInformation.nullButton += NullButton;
    }

    void OnDisable(){
        HeroInformation.SetButton -= CheckButton;
        GameController.ContinueUpdateSkillButton -= ContinueUpdateButton;
        RemoveArtifacte.removeArtifacte -= CheckArtifacte;
        HeroInformation.nullButton -= NullButton;
    }
    public void PressButton(){
        if(HeroInformation.isSkill || GameController.pause || isCoolDown || !HeroInformation.alive)return;
        else if(isRequire){
             audioManager.PlayerCommonAudio(3);
             isCoolDown = true;
             HeroInformation.isSkill = true;
             image.color = Color.black;
             image.fillAmount = 0;
             StartCoroutine(StartSkill());
             StartCoroutine(UpdateButton(1f, true));  
        }else{
            pause.SetActive(false);
            menu.SetActive(true);
            EventSkillButton();
        }
    }

    IEnumerator StartSkill(){
        playerManager.animator.Play(anim[index]);
        yield return new WaitForSeconds(1.3f);
        HeroInformation.isSkill = false;
    }

    IEnumerator UpdateButton(float value, bool first){
        //print(fill);
        float fillAmount = image.fillAmount;
        float elapsed = 0f;
        float timeCoolDown;
        if(first) timeCoolDown = 1 * coolDown;
        else timeCoolDown = value + coolDown;
        while (image.fillAmount < value && elapsed < timeCoolDown){
            if(!GameController.pause){
                elapsed += Time.deltaTime;
                image.fillAmount = Mathf.Lerp(fillAmount, value, elapsed/timeCoolDown);
                yield return null;
            }else yield return null;
        }
        isCoolDown = false;
        image.color = Color.white;
    }

    public void ContinueUpdateButton(){
        if(isCoolDown) StartCoroutine(UpdateButton(1f, false));
    }

    public void CheckButton(bool isNew){
        if(isNew){
            if(isRequire)return;
            else{
                if( HeroInformation.player.characterList[(int)skillRequire].value >= valueSkillRequire ){
                    image.color = Color.white;
                    isRequire = true;
                } else{
                    image.color = Color.black;
                } 
            }
        }
        else{
            if(isRequire){
                image.fillAmount = 1f;
                isCoolDown = false;
                image.color = Color.white;                
            }else{
                image.color = Color.black;
            } 
        }
    }

    void CheckArtifacte() {
        if (HeroInformation.player.characterList[(int)skillRequire].value == 0) {
            isRequire = false;
            image.color = Color.black;
            image.fillAmount = 1f;
            isCoolDown = false;
        }
    }

    void NullButton() {
        StopAllCoroutines();
        if (HeroInformation.player.characterList[(int)skillRequire].value < valueSkillRequire) {
            isRequire = false;
            image.color = Color.black;
            image.fillAmount = 1f;
            isCoolDown = false;
        }
    }
}

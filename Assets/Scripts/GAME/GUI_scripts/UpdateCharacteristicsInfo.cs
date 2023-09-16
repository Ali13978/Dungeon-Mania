using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateCharacteristicsInfo : MonoBehaviour {
    //GameObject menuUI;
    public InfoPanel infoPanel;
    public Sprite[] characteristicSprite;
    int index;
    GameObject gameManager;
    public delegate void delegateShop();
    public static event delegateShop eventShop;
    public string[] russian;
    public string[] english;
    public string[] infoSkill;
    public static void Shop() {
        eventShop();
    }
    void SetLoc() {
        infoSkill = LoadTextFiles.Load("skills", '/');
        foreach (Transform tr in transform) {
            tr.GetChild(3).transform.GetChild(1).GetComponent<Image>().sprite = characteristicSprite[tr.GetSiblingIndex()];
            Text name = tr.GetChild(0).GetChild(0).GetComponent<Text>();
            if (LocalizationManager.localizationIndex == 0) name.text = russian[tr.GetSiblingIndex()];
            else name.text = english[tr.GetSiblingIndex()];
            tr.GetChild(0).GetChild(1).GetComponent<Text>().text = infoSkill[tr.GetSiblingIndex()];
        }
    }
    void Awake(){
        gameManager = GameObject.Find("GameManager");
    }
    private void Start(){
        SetLoc();
    }
    void OnEnable(){
        SetLoc();
        SkillButton.EventSkillButton += Info;
    }
    void OnDisable(){
        SkillButton.EventSkillButton -= Info;
    }
    public void SetIndex(int i) {
        index = i;
        if(HeroInformation.player.experiencePoint >= 1){
            HeroInformation.player.experiencePoint --;
            //HeroInformation.player.characterList[index].value += HeroInformation.player.characterList[index].k;
            HeroInformation.player.characterList[index].bonus += HeroInformation.player.characterList[index].k;
            HeroInformation.UpdateInformation();
            HeroInformation.player.UpdateAbilitys();
            Info();
            HeroInformation.ButtonSet(true);
        }else{
            infoPanel.SetMenuState(4);
            //eventShop();
            Shop();
        }
    }
    public void Info() {
        int i = 0;
        foreach (Transform tr in transform){
            Text textInformation = tr.GetChild(1).GetChild(0).GetComponent<Text>();
            textInformation.resizeTextForBestFit = true;
            textInformation.resizeTextMinSize = 0;
            textInformation.resizeTextMaxSize = 15;
            GameObject button = tr.GetChild(2).gameObject;
            if (HeroInformation.player.characterList[i].value >= HeroInformation.player.characterList[i].maxValue){
                textInformation.color = Color.red;
                button.SetActive(false);
            }
            else {
                if (HeroInformation.player.characterList[i].isUp) textInformation.color = Color.green;
                else textInformation.color = Color.grey;
                button.SetActive(true);
            } 
            if (HeroInformation.player.characterList[i].percent)
                textInformation.text = HeroInformation.player.characterList[i].value.ToString() + "%";
            if (HeroInformation.player.characterList[i].percent && HeroInformation.player.characterList[i].plus)
                textInformation.text = "+" + HeroInformation.player.characterList[i].value.ToString() + "%";
            if (!HeroInformation.player.characterList[i].percent && !HeroInformation.player.characterList[i].plus)
                textInformation.text = HeroInformation.player.characterList[i].value.ToString();
            if (!HeroInformation.player.characterList[i].percent && HeroInformation.player.characterList[i].plus)
                textInformation.text = "+" + HeroInformation.player.characterList[i].value.ToString();
            i++;
        }
    }
}

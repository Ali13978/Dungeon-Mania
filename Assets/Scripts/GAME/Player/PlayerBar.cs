using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBar : MonoBehaviour{
    PlayerManager playerManager;
    void Awake(){
        playerManager = GetComponent<PlayerManager>();
    }
    void Start(){
        StartCoroutine(UpdateValue((float)HeroInformation.player.currentExperience/(float)HeroInformation.player.experience, playerManager.sliderExperiance));
    }
    public IEnumerator UpdateValue(float value, Slider slider){
        float fillAmount = slider.value;
        float elapsed = 0f;
        while(elapsed < 0.5f){
            elapsed += Time.deltaTime;
            slider.value = Mathf.Lerp(fillAmount, value, elapsed/0.5f);
            yield return null;
        }
        slider.value = value;
    }
    public void CheckExperience(int exp){
        HeroInformation.player.currentExperience += exp + ((GamePlayManager.level.currentLevel + HeroInformation.player.dungeonLevel + HeroInformation.player.gameLevel) * 15);
        StartCoroutine(UpdateValue((float)HeroInformation.player.currentExperience/(float)HeroInformation.player.experience, playerManager.sliderExperiance));
        if(HeroInformation.player.currentExperience >= HeroInformation.player.experience){
            playerManager.audioManager.WinAudio(0);
            playerManager.playerHelth.currentHelth = HeroInformation.player.helth.value;
            StartCoroutine(UpdateValue(1, playerManager.sliderHelth));
            HeroInformation.player.currentExperience = 0;
            StartCoroutine(UpdateValue(0, playerManager.sliderExperiance));
            HeroInformation.player.experiencePoint += HeroInformation.player.experiencePointBonus;
            HeroInformation.player.SetExperience();
            HeroInformation.UpdateInformation();
        }
    }
}

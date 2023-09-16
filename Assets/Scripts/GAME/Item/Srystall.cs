using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Srystall : MonoBehaviour{
    Transform thisParent;
    InstObject parentScript;
    void Start(){
        thisParent = transform.parent;
        parentScript = thisParent.GetComponent<InstObject>();
    }
    void OnTriggerEnter(){
        gameObject.SetActive(false);
        HeroInformation.player.experiencePoint++;
        HeroInformation.UpdateInformation();
        parentScript.audioManager.PlayerCommonAudio(6);
        /*
        int percentBonus = Random.Range(1, 101);
        int lucky = HeroInformation.player.lucky.value + 5;
        if (lucky > 15) lucky = 15;
        if (percentBonus < lucky) {
            parentScript.audioManager.WinAudio(1);
            GameController.ads.AdInfo(AdsManager.Earned.gems, 3);
        } else {
            HeroInformation.player.experiencePoint++;
            HeroInformation.UpdateInformation();
            parentScript.audioManager.PlayerCommonAudio(6);
        }
        */
    }
    public void SetObject(){
        int rand = Random.Range(0, 101);
        int per = HeroInformation.player.lucky.value + 10;
        if(per > 25) per = 25;
        if (rand < per) this.gameObject.SetActive(true);
        else this.gameObject.SetActive(false);
    }
}

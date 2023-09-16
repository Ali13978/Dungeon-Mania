using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerHelth : MonoBehaviour{
    [HideInInspector]public bool isResurection;
    PlayerManager playerManager;
    [HideInInspector]public int currentHelth, currentMana ;
    ParticleSystem pS;
    int kShield;
    void Awake(){
        playerManager = GetComponent<PlayerManager>();
    }
    void Start(){
        currentHelth = HeroInformation.player.helth.value;
        StartCoroutine(playerManager.playerBar.UpdateValue((float)currentHelth/(float)HeroInformation.player.helth.value, playerManager.sliderHelth));
    }
    public void PlayerDamage(Damage damage, int hit){
        if (HeroInformation.alive && !isResurection && !HeroInformation.isSkill && !GameController.pause){
            int dodgePercent = Random.Range(1, 101);
            if (dodgePercent < HeroInformation.player.lucky.value) {
                playerManager.audioManager.PlayerCommonAudio(5);
                return;
            } else {
                damage.damage -= HeroInformation.player.armor.value;
                if (damage.elementalType != 0) {
                    if (HeroInformation.player.characterList[damage.elementalType + 4].value == 0) damage.damageElemental *= 5;
                    else if (HeroInformation.player.characterList[damage.elementalType + 4].value > 0 & HeroInformation.player.characterList[damage.elementalType + 4].value < damage.damageElemental)
                        damage.damageElemental *= 2;
                    else if (HeroInformation.player.characterList[damage.elementalType + 4].value >= damage.damageElemental)
                        damage.damageElemental -= HeroInformation.player.characterList[damage.elementalType].value;
                }
                if (damage.damageElemental < 0) damage.damageElemental = 0;
                damage.crit -= HeroInformation.player.armor.value + HeroInformation.player.lucky.value * 10;
                if (damage.crit < 0) damage.crit = 0;
                int damageMain = damage.damage + damage.damageElemental + damage.crit;
                //
                if (HeroInformation.isShield) {
                    //damageMain -= damageMain * (int)(0.5f + (HeroInformation.player.death.value * 0.05f));
                    damageMain -= HeroInformation.player.death.value * 5;
                    if (damageMain <= 0) {
                        damageMain = 0;
                        playerManager.audioManager.PlayerCommonAudio(5);
                    } else {
                        playerManager.audioManager.PlayerHits();
                        SetDamage(hit, damage, damageMain);
                    } 
                } else {
                    if (damageMain <= 0) damageMain = 1;
                    playerManager.audioManager.PlayerHits();
                    SetDamage(hit, damage, damageMain);
                }
                //
                if (currentHelth <= 0) {
                    currentHelth = 0;
                    //GameController.StopShieldFX();
                    if (HeroInformation.player.carma == CharactersClass.Carma.negative) HeroInformation.player.currentDead = true;
                    HeroInformation.player.bossMeet = false;
                    ShieldFollowPlayer.StopPlay();
                    HeroInformation.alive = false;
                    playerManager.animator.Play("dead");
                    playerManager.audioManager.PlayerCommonAudio(1);
                    playerManager.mainInput.attack = false;
                    HeroInformation.EndGame();
                    playerManager.audioManager.WinAudio(3);
                }
            }
        }
    }
    void SetDamage(int hit, Damage damage, int damageMain) {
        switch (hit) {
            case 0://skelet
            if (damage.elementalType == 0) pS = playerManager.fXmanager.hits[0];
            else pS = playerManager.fXmanager.hits[damage.elementalType + 10];
            break;
            case 1://monsters simple
            if (damage.elementalType == 0) pS = playerManager.fXmanager.hits[1];
            else pS = playerManager.fXmanager.hits[damage.elementalType + 10];
            break;
            case 2://monsters power
            pS = playerManager.fXmanager.hits[2];
            break;
            case 3://boss simple
            if (damage.elementalType == 0) pS = playerManager.fXmanager.hits[1];
            else pS = playerManager.fXmanager.hits[damage.elementalType + 10];
            break;
            case 4://boss ppower
            pS = playerManager.fXmanager.hits[damage.elementalType + 3];
            break;
            case 5://demon simple
            pS = playerManager.fXmanager.hits[damage.elementalType + 10];
            break;
            case 6://demon power
            pS = playerManager.fXmanager.hits[Random.Range(7, 11)];
            break;
        }
        pS.transform.position = transform.position + (Vector3.up * 1f);
        pS.Play();
        currentHelth -= damageMain;
        StartCoroutine(playerManager.playerBar.UpdateValue((float)currentHelth / (float)HeroInformation.player.helth.value, playerManager.sliderHelth));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResurection : MonoBehaviour{
    PlayerManager playerManager;
    void Awake(){
        playerManager = GetComponent<PlayerManager>();
    }
    public void Resurection(){
        HeroInformation.resurectionK ++;
        playerManager.fXmanager.common[0].Play();
        playerManager.audioManager.PlayerCommonAudio(2);
        playerManager.playerHelth.isResurection = true;
        playerManager.animator.Play("up");
        playerManager.playerHelth.currentHelth = HeroInformation.player.helth.value;
        HeroInformation.alive = true;
        StartCoroutine(playerManager.playerBar.UpdateValue(1f, playerManager.sliderHelth));
        StartCoroutine(SetIsResurection());
    }
    public void NoResurection(){
        EnemyEvent.EnemyEventSystem(3);
        EnemyEvent.DoorClose();
        EnemyEvent.ChestClose(true);
        HeroInformation.player.score  = 0;
        Vector3 nullPosition = new Vector3(2, 0, 10);
        playerManager.animator.Play("in");
        transform.position = nullPosition;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        playerManager.cameraSystem.transform.position = nullPosition;
        playerManager.playerHelth.currentHelth = HeroInformation.player.helth.value;
        StartCoroutine(playerManager.playerBar.UpdateValue(1f, playerManager.sliderHelth));
        HeroInformation.alive = true;
        HeroInformation.UpdateInformation();
        GamePlayManager.Ini();
    }
    IEnumerator SetIsResurection(){
        yield return new WaitForSeconds (2f);
        playerManager.playerHelth.isResurection = false;
    }
}

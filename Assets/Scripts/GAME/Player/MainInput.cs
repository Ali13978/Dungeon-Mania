using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
public class MainInput : MonoBehaviour {
    [HideInInspector]public PlayerManager playerManager;
    [HideInInspector]public bool attack;
    [HideInInspector]public bool isChest;
    public bool crossInput;
    float h, v;
    GameObject chestGameObject;
    CharacterController characterController;
    public VariableJoystick joystick;
    public float speedRotation;
    bool isWoodChest;
    void OnApplicationPause(){
        GameController.PlayerSave();
        if (Social.localUser.authenticated) Social.ReportScore(
           (long)HeroInformation.player.score,
           "com.sgs.dungeon.bestscore",
           success => {
           }
           );
    }
	void Awake () {
        playerManager = GetComponent<PlayerManager>();
        characterController = GetComponent<CharacterController>();
        attack = false;
        isChest = false;
    }
    void FixedUpdate () {
        if(HeroInformation.alive){
            if(GamePlayManager.inTeleport) playerManager.animator.SetFloat( "speed", 0f );
            else{
                if(!HeroInformation.isSkill){
                    if (crossInput) {
                        h = CrossPlatformInputManager.GetAxis("Horizontal");
                        v = CrossPlatformInputManager.GetAxis("Vertical");
                    }
                    else {
                        h = joystick.Horizontal;
                        v = joystick.Vertical;
                    }
                    if (h != 0 || v != 0){
                        if(!GameController.pause){
                            Rotation( h, v );
                            playerManager.animator.SetFloat( "speed", 1f );
                        }
                    }
                    else playerManager.animator.SetFloat( "speed", 0f );
                }
            }
        }
    }
    private void Update(){
        if (HeroInformation.alive & !GameController.pause) {
            if(!HeroInformation.isSkill || !GamePlayManager.inTeleport || !GameController.pause){
                attack = CrossPlatformInputManager.GetButton("Fire1");
                if (attack) playerManager.animator.SetBool("attack1", true);
                else playerManager.animator.SetBool("attack1", false);
                if (attack && isChest) {
                    if(isWoodChest) playerManager.animator.Play("foot");
                    else if(GamePlayManager.level.isSweep) playerManager.animator.Play("foot");
                } 
            }
        }
    }
    void Rotation(float horizontal, float vertical){
        Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);

        //Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        //Quaternion newRotation = Quaternion.Slerp(PlayerManager.rb.rotation, targetRotation, speedRotation * Time.deltaTime);
        //PlayerManager.rb.MoveRotation(newRotation);

        characterController.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(characterController.transform.forward, targetDirection, speedRotation, 0f));
    }
    public void Chest(bool chest) {
        if (chest) isChest = true;
        else isChest = false;
    }
    public void ChestObject(GameObject chestObject) {
        chestGameObject = chestObject;
    }
    public void AttackChest() {
        if (isChest) {
            chestGameObject.SendMessage("Open");
            isChest = false;
        }
    }

    public void CheckChest(Chest.ChestType chestType) {
        if (chestType == global::Chest.ChestType.ChestWood) isWoodChest = true;
        else isWoodChest = false;
    }
}

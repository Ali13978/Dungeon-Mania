using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFollowPlayer : MonoBehaviour{
    Transform player;
    Transform thisTransform;
    static ParticleSystem particleSystem;
    int psTime;
    void OnEnable(){
        GameController.ContinueShieldFX += ContinueFX;
        GameController.PauseShieldFX += PauseFX;
        //GameController.StopFX += StopPlay;
    }
    void OnDisable(){
        GameController.ContinueShieldFX -= ContinueFX;
        GameController.PauseShieldFX -= PauseFX;
        //GameController.StopFX -= StopPlay;
    }
    void Start(){
        player = GameObject.Find("player").transform;
        thisTransform = GetComponent<Transform>();
        particleSystem = GetComponent<ParticleSystem>();
    }
    void Update(){
        if(HeroInformation.isShield) thisTransform.position = player.position;
    }
    void PauseFX(){
        if(HeroInformation.isShield){
            psTime = (int)particleSystem.time;
            particleSystem.Pause();
        }
    }
    void ContinueFX(){
        if(HeroInformation.isShield){
            particleSystem.time = 10 - psTime;
            particleSystem.Play();
        }
    }    
    void OnParticleSystemStopped(){
        HeroInformation.isShield = false;
    }
    public static void StopPlay() {
        particleSystem.Stop();
    }
}

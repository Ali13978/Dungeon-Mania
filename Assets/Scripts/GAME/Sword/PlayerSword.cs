using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerSword : MonoBehaviour{
    Transform model;
    Transform fx;
    private void Awake() {
        model = transform.GetChild(0);
        fx = transform.GetChild(1);
    }
    void OnEnable(){
        SelectSword.eventSetSwordModel += SetModel;
    }
    void OnDisable(){
        SelectSword.eventSetSwordModel -= SetModel;
    }
    void Start(){
        SetModel();
    }
    void SetModel(){
        foreach (Transform tr in model) {
            if (tr.GetSiblingIndex() == HeroInformation.player.sword.index) tr.gameObject.SetActive(true);
            else tr.gameObject.SetActive(false);
        }
        foreach (Transform tr in fx) {
            if (HeroInformation.player.sword.swordMageType == Item.TypeDamageMage.none) {
                tr.GetComponent<ParticleSystem>().Stop();
                //tr.gameObject.SetActive(false);
            } else {
                //if (tr.GetSiblingIndex() == (int)HeroInformation.player.sword.swordMageType - 1) tr.GetComponent<ParticleSystem>().Play();
                if (tr.GetSiblingIndex() == 1 || tr.GetSiblingIndex() == 2) tr.GetComponent<ParticleSystem>().Play();
                else tr.GetComponent<ParticleSystem>().Stop();
                //else tr.gameObject.SetActive(false);
            }
        }
    }
}

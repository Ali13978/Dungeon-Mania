using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InfoPanel : MonoBehaviour{
    void OnEnable(){
        SkillButton.EventSkillButton += SetState;
    }
    void OnDisable(){
        SkillButton.EventSkillButton -= SetState;
    }
    public void SetMenuState(int ii){
        for(int i = 0; i < 6; i++){
            if(transform.GetChild(i).GetSiblingIndex() == ii) transform.GetChild(ii).gameObject.SetActive(true);
            else transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    void SetState(){
        SetMenuState(4);
    }
}

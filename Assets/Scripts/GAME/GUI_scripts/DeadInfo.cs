using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadInfo : MonoBehaviour{
    public string r;
    public string e;
    public Text info;
    public void OnEnableDead() {
        if (LocalizationManager.localizationIndex == 0) info.text = r;
        else info.text = e;
        //info.text = r;
    }
}

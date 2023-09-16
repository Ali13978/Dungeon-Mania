using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class ChangeSensJoyctic : MonoBehaviour{
    public TouchPad pad;
    public Slider slider;
    Text currentValueText;
    void Start(){
        slider.value = HeroInformation.player.settings.joystick;
        pad.Xsensitivity = HeroInformation.player.settings.joystick;
        pad.Ysensitivity = HeroInformation.player.settings.joystick;  
        currentValueText = slider.transform.GetChild(3).GetComponent<Text>();
    }
    void Update(){
        if(GameController.pause){
            currentValueText.text = System.Math.Round(slider.value, 1).ToString();
            pad.Xsensitivity = slider.value;
            pad.Ysensitivity = slider.value;
            HeroInformation.player.settings.joystick = slider.value;
        }
    }
}

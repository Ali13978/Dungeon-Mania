using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
public class ChangeMusicVolume : MonoBehaviour{
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSound;
    public Slider sliderMusic;
    public Slider sliderSound;
    Text currentValueMusic;
    Text currentValueSound;
    public Toggle toggleMute;
    public TouchPad pad;
    public MainInput mainInput;
    public Slider sliderPad;
    public Toggle bloom;
    Text currentValuePad;
    public Camera camerA;
    public Slashes_MobileBloom scriptBloom;
    void Awake(){

        transform.localPosition = new Vector3(0, -20, 0);

        audioSourceMusic.mute = HeroInformation.player.settings.mute;
        audioSourceSound.mute = HeroInformation.player.settings.mute;

        audioSourceMusic.volume = HeroInformation.player.settings.music;
        audioSourceSound.volume = HeroInformation.player.settings.sound;

        sliderMusic.value = HeroInformation.player.settings.music;
        sliderSound.value = HeroInformation.player.settings.sound;

        toggleMute.isOn = HeroInformation.player.settings.mute;
    
        currentValueMusic = sliderMusic.transform.GetChild(3).GetComponent<Text>();
        currentValueSound = sliderSound.transform.GetChild(3).GetComponent<Text>();

        mainInput.speedRotation = HeroInformation.player.settings.joystick;
        sliderPad.value = HeroInformation.player.settings.joystick;
        currentValuePad = sliderPad.transform.GetChild(3).GetComponent<Text>();

        //sliderPad.value = HeroInformation.player.settings.joystick;
        //pad.Xsensitivity = HeroInformation.player.settings.joystick;
        //pad.Ysensitivity = HeroInformation.player.settings.joystick;  

        transform.parent.gameObject.SetActive(false);
        scriptBloom = camerA.GetComponent<Slashes_MobileBloom>();
    }
    void Update(){
        if(GameController.pause){
            audioSourceMusic.volume = sliderMusic.value;
            currentValueMusic.text = (System.Math.Round(audioSourceMusic.volume, 1) * 100).ToString();
            HeroInformation.player.settings.music = audioSourceMusic.volume;

            audioSourceSound.volume = sliderSound.value;
            currentValueSound.text = (System.Math.Round(audioSourceSound.volume, 1) * 100).ToString();
            HeroInformation.player.settings.sound = audioSourceSound.volume;

            if(toggleMute.isOn){
                audioSourceMusic.mute = true;
                audioSourceSound.mute = true;
                HeroInformation.player.settings.mute = true;
            }else{
                audioSourceMusic.mute = false;
                audioSourceSound.mute = false;   
                HeroInformation.player.settings.mute = false;             
            }

            currentValuePad.text = System.Math.Round(sliderPad.value).ToString();
            //pad.Xsensitivity = sliderPad.value;
            //pad.Ysensitivity = sliderPad.value;
            mainInput.speedRotation = (float)System.Math.Round(sliderPad.value);
            HeroInformation.player.settings.joystick = sliderPad.value;

            if(bloom.isOn) scriptBloom.enabled = true;
            else scriptBloom.enabled = false;
        }        
    }
}

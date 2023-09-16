using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Damage{
     public int damage;
     public int elementalType;
     public int damageElemental;
     public int crit;
     public bool isBow;
     public bool isSpell;
     public int spellID;
}
[System.Serializable]
public class Characteristic {
    public int value;
    public int maxValue;
    public int k;
    public bool plus;
    public bool percent;
    public int bonus;
    public bool isUp = false;
    public Characteristic(int v, int mV, int kC, bool pl, bool per) {
        value = v;
        maxValue = mV;
        k = kC;
        plus = pl;
        percent = per;
        bonus = value;
    }
    public Characteristic(int v) {
        value = v;
        maxValue = 100;
    }
}
[System.Serializable]
public struct Settings{
    public bool mute;
    public float music;
    public float sound;
    public float joystick;
    public bool firstStart;
    public Settings(bool setMute, float setMusic, float setSound, float setJoystick, bool f){
        mute = setMute;
        music = setMusic;
        sound = setSound;
        joystick = setJoystick;
        firstStart = f;
    }
}



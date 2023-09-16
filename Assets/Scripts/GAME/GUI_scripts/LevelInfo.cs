using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelInfo : MonoBehaviour{   
    public Text isSweepText;
    public Text currentLevel;
    public Text leftenemy;
    public Text inside;
    void Start(){
    }
    void Update(){
        isSweepText.text = GamePlayManager.level.isSweep.ToString();
        currentLevel.text = GamePlayManager.level.currentLevel.ToString();
        leftenemy.text = GamePlayManager.leftEnemiesForDoor.ToString() + " left enemy for door";
        inside.text = GamePlayManager.inside.ToString() + " inside";
    }
}

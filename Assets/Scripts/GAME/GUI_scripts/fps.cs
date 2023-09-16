using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fps : MonoBehaviour{
    float deltaTime = 0.0f;
    float fpss ;
    public Text text;
    void Update(){
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        //deltaTime += (Time.timeScale - deltaTime) * 0.1f;
        fpss = 1.0f / deltaTime;
        text.text = "fps : "+fpss.ToString();
    }
}

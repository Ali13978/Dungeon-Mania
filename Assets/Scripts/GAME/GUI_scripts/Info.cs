using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour{
    public string[] infoText;
    public GameObject infoObject;
    void Start(){
        infoText = LoadTextFiles.Load("info", '/');
        infoObject.GetComponent<Text>().text = infoText[Random.Range(0, infoText.Length)];
    }
}

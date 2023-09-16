using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParseButtonText : MonoBehaviour {

    public class JsonButton {

        public string[] ButtonPlayerText;
    }

    JsonButton jButton = new JsonButton();
    public Text[] buttonText;

    private void Start() {
        /*
        TextAsset jsonFile = Resources.Load("RU/Меню/Menu") as TextAsset;
        jButton = JsonUtility.FromJson<JsonButton>(jsonFile.text);
        for (int i=0; i<buttonText.Length; i++) {
            buttonText[i].text = jButton.ButtonPlayerText[i];
        }
        */
    }
}

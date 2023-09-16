using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenuParts : MonoBehaviour {

    public Text infoMenuParts;

    public class JasonMenuParts {

        public string[] InfoMenuParts;
    }

    JasonMenuParts jMenuParts = new JasonMenuParts();

	void Start () {
        TextAsset jsonFile = Resources.Load( "RU/Знания/InfoMenuParts" ) as TextAsset;
        jMenuParts = JsonUtility.FromJson<JasonMenuParts>( jsonFile.text );
    }

    public void SetInfo(int q) {
        if (q == 10) infoMenuParts.text = "";
        else
        infoMenuParts.text = jMenuParts.InfoMenuParts[q];
    }
}

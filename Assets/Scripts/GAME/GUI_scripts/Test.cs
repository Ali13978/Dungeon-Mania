using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour{
    public Text text;
    public Text text1;
    public Text text2;
    public Text text3;

    void Update() {
        text.text = "всего врагов осталось " + GamePlayManager.leftEnemiesArena.ToString();
        text1.text = "проверка - " + "QUEST_" + PlayerPrefs.GetInt("QUEST_COUNT").ToString();
        text2.text = "состояние квеста - " + PlayerPrefs.GetInt("QUEST_" + PlayerPrefs.GetInt("QUEST_COUNT").ToString());
        text3.text = HeroInformation.player.dungeonLevel.ToString();
    }
}

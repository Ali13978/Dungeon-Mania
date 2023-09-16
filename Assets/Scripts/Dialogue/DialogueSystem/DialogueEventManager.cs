using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEventManager : MonoBehaviour{
    public delegate void DialogueDelegate();
    public delegate void DialogueRewardDelegate(DialogueReward reward);
    public static event DialogueDelegate dialogueEnable;
    public static event DialogueDelegate dialogueDisable;
    public static event DialogueDelegate dialogueContinue;
    public static event DialogueRewardDelegate dialogueReward;

    public static void DialogueEnable() {
        dialogueEnable();
    }
    public static void DialogueDisable() {
        dialogueDisable();
    }
    public static void DialogueContinue() {
        dialogueContinue();
    }
    public static void DialogueReward(DialogueReward reward) {
        dialogueReward(reward);
    }
}

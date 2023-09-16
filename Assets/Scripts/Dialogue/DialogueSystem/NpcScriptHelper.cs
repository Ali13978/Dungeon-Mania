using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScriptHelper : MonoBehaviour {

    public void begin() {
        string name;
        name = LocalizationManager.dialogues[PlayerPrefs.GetInt(LocalizationManager.LOCALIZATION_DIALOGUE)];
        DialogueManager.CreateDialogue(name); }

    public void end() { DialogueManager.playerReplyCount = 0; }

    public void exit() { DialogueEventManager.DialogueDisable(); }

    //public void fight() { UIManager.UIManagerGamePlay(2); GameState.gameState = GameState.State.Fight; }

    public void npc(int i) { DialogueManager.NpcReply(i); }

    public void player(int i, int ii) { DialogueManager.PlayerReply(i, ii); }
}


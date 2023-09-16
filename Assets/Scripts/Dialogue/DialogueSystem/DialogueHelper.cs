using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHelper : MonoBehaviour {

    public Transform npcReply;
    public Transform playerReply;
    public static int[] nextNodeArray = new int[4] { 0, 0, 0, 0 };

    private void Awake() {
        HideReplys();   
    }

    private void OnEnable() {
        DialogueManager.NpcReplyEvent += NpcReply;
        DialogueManager.PlayerReplyEvent += CreatePlayerReply;
        GetButtonIndex.HideReplysEvent += HideReplys;
    }

    private void OnDisable() {
        DialogueManager.NpcReplyEvent -= NpcReply;
        DialogueManager.PlayerReplyEvent -= CreatePlayerReply;
        GetButtonIndex.HideReplysEvent -= HideReplys;
        HideReplys();
    }

    void NpcReply(string s, int i) {

        npcReply.GetChild(1).GetComponent<Text>().text = s;

    }

    void CreatePlayerReply(string s, int i) {

        playerReply.GetChild(DialogueManager.playerReplyCount).gameObject.SetActive(true);
        GameObject current = playerReply.GetChild(DialogueManager.playerReplyCount).GetChild(0).gameObject;
        current.GetComponent<Text>().text = s;
        nextNodeArray[DialogueManager.playerReplyCount] = i;
        DialogueManager.playerReplyCount++;
    }

    public void HideReplys() {
        foreach (Transform tr in playerReply.transform) {
            tr.gameObject.SetActive(false);
        }
    }
}


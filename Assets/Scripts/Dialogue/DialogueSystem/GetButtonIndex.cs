using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetButtonIndex : MonoBehaviour{
    public delegate void Hide();
    public static event Hide HideReplysEvent;

    public void GetNextDialogueNode() {
        HideReplysEvent();
        GamePlayManager.staticNpcObject.SendMessage("DialogueNodes", DialogueHelper.nextNodeArray[transform.GetSiblingIndex()]);
    }
}

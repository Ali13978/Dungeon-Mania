using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class DialogueManager {

    public static Dictionary<int, string> dialogue;

    public delegate void DialogueDelegat(string s, int i);
    public static event DialogueDelegat NpcReplyEvent;
    public static event DialogueDelegat PlayerReplyEvent;

    public static int playerReplyCount = 0;

    public static Dictionary<int,string> CreateDialogue(string name) {
        dialogue = new Dictionary<int, string>();
        TextAsset textDialogue = Resources.Load("Dialogues/Npc_" + name) as TextAsset;
        string stringDialogue = textDialogue.text;
        char[] sep = { '>' };
        string[] partsDialogue = stringDialogue.Split(sep);
        foreach (var pair in partsDialogue) {
            int position = pair.IndexOf("<");
            if (position < 0)
                continue;
            pair.Trim();
            dialogue.Add(Convert.ToInt32(pair.Substring(0, position)), pair.Substring(position + 1));
        }
        return dialogue;
    }

    public static void NpcReply(int index) {
        string reply = "";
        dialogue.TryGetValue(index, out reply);
        NpcReplyEvent(reply, 0);
    }

    public static void PlayerReply(int index, int nextNode) {
        string reply = "";
        dialogue.TryGetValue(index, out reply);
        PlayerReplyEvent(reply, nextNode);
    }
}

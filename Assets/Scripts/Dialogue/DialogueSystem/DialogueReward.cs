using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReward{

    public enum Reward {
        SWORD,
        ART,
        GOLD,
        EXP
    }
    public Reward reward;
    public int valueReward;

    public DialogueReward(Reward _reward, int _value) {
        reward = _reward;
        valueReward = _value;
    }

    public DialogueReward(Reward _reward) {
        reward = _reward;
    }
}

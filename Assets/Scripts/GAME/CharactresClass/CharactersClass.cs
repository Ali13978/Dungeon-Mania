using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class CharactersClass{
    public string name;
    public int level;
    public int playerLevel;
    public int gold;
    public int keys;
    public int score;
    public int experience;
    public int experiencePoint;
    public int experiencePointBonus;
    public int currentExperience;
    public Settings settings;

    public List<int> inventorySword = new List<int>();
    public int indicatorSwordList = 1;
    public int currentSwordIndex = 0;
    [System.NonSerialized] public Item sword = new Item();

    public int indicatorRelicList = 0;

    public int indicatorStory = 0;
    public int indicatorStoryDialogue = 0;

    public List<int> inventoryArtifacte = new List<int>();
    public List<int> currentArtifactes = new List<int>();
    public int cellArtifactes = 0;

    public Characteristic[] characterList;
    public Characteristic attack = new Characteristic(1, 99, 1, true, false);
    public Characteristic helth = new Characteristic(100, 999, 10, false, false);
    public Characteristic armor = new Characteristic(1, 99, 1, false, false);
    public Characteristic accurcy = new Characteristic(45, 80, 1, false, true);
    public Characteristic miner = new Characteristic(0, 99, 1, true, false);
    public Characteristic jesus = new Characteristic(25, 55, 1, false, true);
    public Characteristic medal = new Characteristic(0, 999, 50, true, true);
    public Characteristic lucky = new Characteristic(1, 25, 1, false, false);
    public Characteristic fire = new Characteristic(0, 99, 1, false, false);
    public Characteristic ice = new Characteristic(0, 99, 1, false, false);
    public Characteristic electricity = new Characteristic(0, 99, 1, false, false);
    public Characteristic death = new Characteristic(0, 99, 1, false, false);

    public enum StatePlayerForDialogue {
        FirstMeet, CommonMeet, QuestMeet, ItemMeet, OrgeMeet, GolemMeet, MinoMeet, IfritMeet, DemonMeet, BastardMeet, NegativeMeet
    }
    public StatePlayerForDialogue statePlayerForDialogue = StatePlayerForDialogue.FirstMeet;

    public bool itemMeet, storyMeet, bossMeet, demonMeet, firstBoss, firstDemon, firstDead;

    public enum Carma {
        nul, bastard, negative, neutral, positive, divine
    }
    public Carma carma = Carma.neutral;

    public int nul = 0;

    public bool currentDead = false;

    public int dungeonLevel = 0;
    public int gameLevel = 1;
}



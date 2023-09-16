using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerClass : HeroClass {
    public void SetExperience(){
        ++playerLevel;
        if (playerLevel == 2 || playerLevel == 4 || playerLevel == 6 || playerLevel == 10 || playerLevel == 15) {
            ++cellArtifactes;
        }
        experience += 1150 * playerLevel;
    }
    public PlayerClass(string n) { 
        name = n;
        level = 1;
        playerLevel = 0;
        gold = 0;
        keys = 0;
        score = 0;
        experience = 0;
        experiencePoint = 0;
        experiencePointBonus = 5;
        currentExperience = 0;
        settings = new Settings(false, 0.5f, 0.5f, 1f, true);
        CreateCharacteristicList();
        //CreateAbilitysList();
        //UpdateAbilitys();
        SetExperience();
    }
}

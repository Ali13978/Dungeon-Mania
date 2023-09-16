using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[System.Serializable]
public class HeroClass : CharactersClass{
    public void CreateCharacteristicList(){
        characterList = new Characteristic[12]{
            fire,
            ice,
            electricity,
            death,
            attack,
            helth,
            armor,
            accurcy,
            miner,
            jesus,
            medal,
            lucky,
        };
    }
    
    public void UpdateAbilitys() {
        ItemDataBase itemDataBase = ItemDataManager.itemDataBase;
        for (int i = 0; i < characterList.Length; ++i){
            characterList[i].value = characterList[i].bonus;
            int b = 0;
            foreach (int indexArtifacte in HeroInformation.player.currentArtifactes)
                if (i == (int)itemDataBase.artifactes[indexArtifacte].bonus) b += itemDataBase.artifactes[indexArtifacte].bonusValue;
            characterList[i].value += b;
            if (characterList[i].value + b > characterList[i].value) characterList[i].isUp = true;
            else characterList[i].isUp = false;
            if (characterList[i].value > characterList[i].maxValue) characterList[i].value = characterList[i].maxValue;
        }         
    }
}

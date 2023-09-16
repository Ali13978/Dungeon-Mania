using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public enum ItemType {
        SWORD,
        ARTIFACTE
    }
    public ItemType itemType = ItemType.SWORD;
    public enum ItemCategory {
        ordinary,
        rare,
        relic
    }
    public ItemCategory itemCategory = ItemCategory.ordinary;
    public Sprite icon = null;
    public int index = 0;
    public ItemLocalization[] itemLocalizations = new ItemLocalization[2];
    public int price = 0;
    public bool isQuestItem = false;
    //sword
    public int damageMin = 0;
    public int damageMax = 0;
    public int mageDamage = 0;
    public int requierLevel = 0;
    public bool isUse = false;
    public bool avialable = false;
    public enum TypeDamageMage {
        none, fire, ice, electricity, death
    }
    public TypeDamageMage swordMageType = TypeDamageMage.none;
    //artifacte
    public enum Bonus {
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
    }
    public Bonus bonus = Bonus.fire;
    public int bonusValue = 0;
}
[System.Serializable]
public class ItemLocalization {
    public string name = "Название";
    public string category = "Обычный";
    public string title = "Заголовок";
    public string description = "Описание";
}



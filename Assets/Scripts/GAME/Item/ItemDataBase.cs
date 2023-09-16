using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Предметы/Создать Базу", fileName = "ItemData")]
public class ItemDataBase : ScriptableObject {
    public List<Item> swords = new List<Item>();
    public List<Item> artifactes = new List<Item>();
    public List<Item> relic = new List<Item>();
}

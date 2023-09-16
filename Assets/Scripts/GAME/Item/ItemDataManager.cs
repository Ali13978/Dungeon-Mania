using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour{
    public static ItemDataBase itemDataBase;
    private void Start() {
        itemDataBase = Resources.Load("DataBase/Items/ItemData") as ItemDataBase;
    }
}

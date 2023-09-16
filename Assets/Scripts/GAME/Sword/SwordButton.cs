using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordButton : MonoBehaviour{
    public void GetIndex() {
        int index = transform.GetSiblingIndex();
        transform.parent.SendMessage("SwordButton", index);
    }
}

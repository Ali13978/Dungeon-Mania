using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class EditorArtifactes : EditorWindow {

    [MenuItem("Artifactes/Editor")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(EditorArtifactes));
    }
    ItemDataBase itemDataBase;
    List<Item> swords;
    List<Item> artifactes;
    List<Item> currentBase;
    Item currentItem;
    string baseName;
    enum StateEditor {
        BEGIN,
        CURRENT_BASE,
        CURRENT_ITEM
    }
    StateEditor stateEditor = StateEditor.BEGIN;
    Vector2 scroll;

    private void OnEnable() {
        itemDataBase = (ItemDataBase)AssetDatabase.LoadAssetAtPath("Assets/Resources/DataBase/Items/ItemData.asset", typeof(ItemDataBase));
        swords = itemDataBase.swords;
        artifactes = itemDataBase.artifactes;
    }

    private void OnGUI() {

        switch (stateEditor) {
            case StateEditor.BEGIN:
            GUILayout.Label("Items Data", EditorStyles.boldLabel);
            if (GUILayout.Button("Swords")) {
                currentBase = swords;
                baseName = "Swords";
                stateEditor = StateEditor.CURRENT_BASE;
            }
            if (GUILayout.Button("Artifactes")) {
                currentBase = artifactes;
                baseName = "Artifactes";
                stateEditor = StateEditor.CURRENT_BASE;
            }
            if (GUILayout.Button("Create text file")) {
                string str = "";
                foreach (Item item in itemDataBase.swords) {
                    str += item.itemLocalizations[0].name;
                    str += System.Environment.NewLine;
                    str += item.itemLocalizations[0].title;
                    str += System.Environment.NewLine;
                    str += System.Environment.NewLine;
                }
                foreach (Item item1 in itemDataBase.artifactes) {
                    str += item1.itemLocalizations[0].name;
                    str += System.Environment.NewLine;
                    str += item1.itemLocalizations[0].title;
                    str += System.Environment.NewLine;
                    str += System.Environment.NewLine;
                }
                string path = "Assets/Resources/LocalizationItems/" + "Items_Data" + ".txt";
                FileStream fileStream = new FileStream(path, FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(str);
                streamWriter.Close();
            }
            break;
            case StateEditor.CURRENT_BASE:
            scroll = GUILayout.BeginScrollView(scroll);
            GUILayout.BeginHorizontal();
            GUILayout.Label(baseName, EditorStyles.boldLabel);
            if (GUILayout.Button("Items Data")) {
                stateEditor = StateEditor.BEGIN;
            }
            if (GUILayout.Button("Clear Data " + baseName)) {
                currentBase.Clear();
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(15);
            if (currentBase.Count > 0) {
                foreach (Item i in currentBase) {
                    if (GUILayout.Button(i.itemLocalizations[0].name + ", ID: " + i.index)) {
                        currentItem = i;
                        stateEditor = StateEditor.CURRENT_ITEM;
                    }
                }
            }
            if (GUILayout.Button("New Item")) {
                Item item = new Item();
                for (int i = 0; i < item.itemLocalizations.Length; ++i) {
                    ItemLocalization iL = new ItemLocalization();
                    item.itemLocalizations[i] = iL;
                }
                currentBase.Add(item);
                currentItem = item;
                stateEditor = StateEditor.CURRENT_ITEM;
            }
            GUILayout.EndScrollView();
            break;
            case StateEditor.CURRENT_ITEM:
            scroll = GUILayout.BeginScrollView(scroll);
            GUILayout.BeginHorizontal();
            GUILayout.Label(currentItem.itemLocalizations[0].name + ", " + "ID: " + currentItem.index, EditorStyles.boldLabel);
            if (GUILayout.Button("Back")) {
                stateEditor = StateEditor.CURRENT_BASE;
            }
            if (GUILayout.Button("Delete Item")) {
                currentBase.Remove(currentItem);
                stateEditor = StateEditor.CURRENT_BASE;
            }
            GUILayout.EndHorizontal();
            currentItem.itemType = (Item.ItemType)EditorGUILayout.EnumPopup("Item Type", currentItem.itemType);
            currentItem.icon = EditorGUILayout.ObjectField("Icon", currentItem.icon, typeof(Sprite), false) as Sprite;
            for (int i = 0; i < currentItem.itemLocalizations.Length; ++i) {
                GUILayout.Label((i + 1).ToString() + " Localization", EditorStyles.boldLabel);
                currentItem.itemLocalizations[i].name = EditorGUILayout.TextField("Item Name", currentItem.itemLocalizations[i].name);
                currentItem.itemLocalizations[i].title = EditorGUILayout.TextField("Item Title", currentItem.itemLocalizations[i].title);
            }
            currentItem.index = currentBase.IndexOf(currentItem);
            GUILayout.Label("ID " + currentItem.index.ToString(), EditorStyles.boldLabel);
            currentItem.requierLevel = EditorGUILayout.IntField("Level", currentItem.requierLevel, GUILayout.ExpandHeight(false));
            switch (currentItem.itemType) {
                case Item.ItemType.SWORD:
                currentItem.damageMin = EditorGUILayout.IntField("Min. Damage", currentItem.damageMin, GUILayout.ExpandHeight(false));
                currentItem.damageMax = EditorGUILayout.IntField("Max. Damage", currentItem.damageMax, GUILayout.ExpandHeight(false));
                break;
                case Item.ItemType.ARTIFACTE:
                currentItem.bonus = (Item.Bonus)EditorGUILayout.EnumPopup("Bonus", currentItem.bonus);
                currentItem.bonusValue = EditorGUILayout.IntField("Bonus Value", currentItem.bonusValue);
                break;
                default:
                break;
            }
            GUILayout.EndScrollView();
            break;
            default:
            break;
        }

        if (GUI.changed) {
            EditorUtility.SetDirty(itemDataBase);
        }
    }
}

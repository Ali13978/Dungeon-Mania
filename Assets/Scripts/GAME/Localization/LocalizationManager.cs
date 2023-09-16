using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour{

    public static string LOCALIZATION_MENU = "LOCALIZATION_MENU";
    public static string LOCALIZATION_DIALOGUE = "LOCALIZATION_DIALOGUE";
 
    public static int localizationIndex;

    public static string[] dialogues = new string[10] { "RU", "EN", "DE", "SP", "POR", "T", "PL", "FR", "ID", "KO" };

    public static SystemLanguage[] systemLanguages = new SystemLanguage[10] {
        SystemLanguage.Russian,
        SystemLanguage.English,
        SystemLanguage.German,
        SystemLanguage.Spanish,
        SystemLanguage.Portuguese,
        SystemLanguage.Italian,
        SystemLanguage.Polish,
        SystemLanguage.French,
        SystemLanguage.Indonesian,
        SystemLanguage.Korean
    };

    private void Awake() {
        if (!PlayerPrefs.HasKey(LOCALIZATION_DIALOGUE)) PlayerPrefs.SetInt(LOCALIZATION_DIALOGUE, LocalizationSetDialogue());
        if (!PlayerPrefs.HasKey(LOCALIZATION_MENU)) {
            int l = LocalizationSetMenu();
            PlayerPrefs.SetInt(LOCALIZATION_MENU, l);
            localizationIndex = l;
        }
    }

    public static int LocalizationSetDialogue() {
        if (Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian) return 0;
        else {
            for (int i = 0; i < systemLanguages.Length; i++) {
                if (Application.systemLanguage == systemLanguages[i]) return i;
            }
            return 1;
        }
    }

    public static int LocalizationSetMenu() {
        if (Application.systemLanguage == SystemLanguage.Russian ||
            Application.systemLanguage == SystemLanguage.Ukrainian ||
            Application.systemLanguage == SystemLanguage.Belarusian)
            return 0;
        else return 1;
    }
}

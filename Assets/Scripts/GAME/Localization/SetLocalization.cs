using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLocalization : MonoBehaviour{

    public Dropdown dropdownM;
    public Dropdown dropdownD;

    private void OnEnable() {

        for (int i = 0; i < LocalizationManager.systemLanguages.Length; i++) {
            dropdownD.options[i].text = "" + LocalizationManager.systemLanguages[i];
        }

        SetDropdown();
    }

    public void ChooseLocalizationMenu() {
        int i = dropdownM.value;
        PlayerPrefs.SetInt(LocalizationManager.LOCALIZATION_MENU, i);
        LocalizationManager.localizationIndex = i;
    }

    public void ChooseLocalizationDialogue() {
        PlayerPrefs.SetInt(LocalizationManager.LOCALIZATION_DIALOGUE, dropdownD.value);
    }

    void SetDropdown() {
        dropdownM.value = PlayerPrefs.GetInt(LocalizationManager.LOCALIZATION_MENU);
        dropdownD.value = PlayerPrefs.GetInt(LocalizationManager.LOCALIZATION_DIALOGUE);
    }
}

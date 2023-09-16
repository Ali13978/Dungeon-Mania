using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArtifactesInfo : MonoBehaviour{
    Transform currentArtifactes;
    public Transform inventoryArtifactes;
    public Transform artifactesPrefabs;
    Sprite[] bonusAbility;
    public UpdateCharacteristicsInfo abilityObject;
    int[] currentArtifactesValue = new int[] { 2, 4, 6, 10, 15 };
    int indexUI;
    private void Awake() {
        currentArtifactes = transform.GetChild(0);
        inventoryArtifactes = transform.GetChild(1).GetChild(0);
        bonusAbility = abilityObject.characteristicSprite;
        for (int i = 0; i < 20; ++i) {
            Instantiate(artifactesPrefabs, inventoryArtifactes);
        } 
    }
    public void SetArtifactes() {
        foreach (Transform tr in inventoryArtifactes) {
            tr.gameObject.SetActive(false);
        }

        foreach (Transform tr in currentArtifactes) {
            if (HeroInformation.player.playerLevel >= currentArtifactesValue[tr.GetSiblingIndex()]) {
                tr.GetChild(0).gameObject.SetActive(false);
                if (HeroInformation.player.currentArtifactes.Count >= tr.GetSiblingIndex() + 1) {
                    Transform currentTr = tr.GetChild(1);
                    currentTr.gameObject.SetActive(true);
                    currentTr.GetChild(0).GetComponent<Image>().sprite = ItemDataManager.itemDataBase.artifactes[HeroInformation.player.currentArtifactes[tr.GetSiblingIndex()]].icon;
                } else {
                    tr.GetChild(1).gameObject.SetActive(false);                }
            } else {
                tr.GetChild(0).gameObject.SetActive(true);
                tr.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = currentArtifactesValue[tr.GetSiblingIndex()].ToString();
                tr.GetChild(1).gameObject.SetActive(false);
            }
        }
        /*
        if (HeroInformation.player.currentArtifactes.Count > 0) {
            for (int i = 0; i < HeroInformation.player.currentArtifactes.Count; ++i) {
                currentArtifactes.GetChild(i).GetChild(1).gameObject.SetActive(true);
                currentArtifactes.GetChild(i).GetChild(1).GetChild(0).GetComponent<Image>().sprite =
                    ItemDataManager.itemDataBase.artifactes[HeroInformation.player.currentArtifactes[i]].icon;
            }
        }
        */
        indexUI = 0;
        foreach (int artifacte in HeroInformation.player.inventoryArtifacte) {
            int currentLocalization = LocalizationManager.localizationIndex;
            Item localArtifacte = ItemDataManager.itemDataBase.artifactes[artifacte];
            //Transform artifacteUiObject = inventoryArtifactes.GetChild(HeroInformation.player.inventoryArtifacte.IndexOf(artifacte));
            Transform artifacteUiObject = inventoryArtifactes.GetChild(indexUI);
            artifacteUiObject.gameObject.SetActive(true);
            GameObject buttonGet = artifacteUiObject.GetChild(2).gameObject;
            GameObject buttonSell = artifacteUiObject.GetChild(3).gameObject;
            GameObject requierLevel = artifacteUiObject.GetChild(4).gameObject;
            GameObject info = artifacteUiObject.GetChild(1).gameObject;
            buttonSell.SetActive(true);
            buttonSell.transform.GetChild(1).GetComponent<Text>().text = localArtifacte.price.ToString();
            info.SetActive(true);
            info.transform.GetChild(0).GetComponent<Image>().sprite = localArtifacte.icon;
            info.transform.GetChild(1).GetComponent<Text>().text = localArtifacte.itemLocalizations[currentLocalization].name;
            //info.transform.GetChild(2).GetComponent<Text>().text = localArtifacte.itemLocalizations[currentLocalization].title;
            info.transform.GetChild(3).GetComponent<Image>().sprite = bonusAbility[(int)localArtifacte.bonus];
            if (HeroInformation.player.characterList[(int)localArtifacte.bonus].percent) {
                info.transform.GetChild(4).GetComponent<Text>().text = "+" + localArtifacte.bonusValue.ToString() + "%";
            } else {
                info.transform.GetChild(4).GetComponent<Text>().text = "+" + localArtifacte.bonusValue.ToString();
            }
            if (HeroInformation.player.playerLevel < localArtifacte.requierLevel) {
                buttonGet.SetActive(false);
                requierLevel.SetActive(true);
                requierLevel.transform.GetChild(0).GetComponent<Text>().text = localArtifacte.requierLevel.ToString();
            } else {
                if (HeroInformation.player.cellArtifactes > 0) buttonGet.SetActive(true);
                else buttonGet.SetActive(false);
                requierLevel.SetActive(false);
            }
            ++indexUI;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectSword : MonoBehaviour {
    public Transform swordUIprefab;
    public ItemDataBase itemDataBase;
    public Sprite[] swordIcons;
    public Sprite[] swordComponents;
    Sprite[] bonusAbility;
    public UpdateCharacteristicsInfo abilityObject;
    public InfoPanel infoPanel;
    GameObject gameManager;
    AudioManager audioManager;
    public delegate void SetSwordModel();
    public static event SetSwordModel eventSetSwordModel;
    public static void SetSword() {
        eventSetSwordModel();
    }
    void Awake(){
        gameManager = GameObject.Find("GameManager");
        audioManager = gameManager.GetComponent<AudioManager>();
        bonusAbility = abilityObject.characteristicSprite;
        //foreach(Item sword in itemDataBase.swords) Instantiate(swordUIprefab, transform);
    }
	public void SetSwords(){
        foreach (Transform t in transform) t.gameObject.SetActive(false);
        foreach (int swordIndex in HeroInformation.player.inventorySword) {
            int currentLocalization = LocalizationManager.localizationIndex;
            Transform tr = transform.GetChild(swordIndex);
            tr.gameObject.SetActive(true);
            Item sword = itemDataBase.swords[swordIndex];
            //началло инофо
            GameObject button = tr.GetChild(1).gameObject;
            GameObject value = tr.GetChild(2).gameObject;
            GameObject info = tr.GetChild(3).gameObject;
            Transform damage = tr.GetChild(0).GetChild(1).GetChild(0);
            Transform mage = tr.GetChild(0).GetChild(2);
            info.transform.GetChild(0).GetComponent<Image>().sprite = sword.icon;
            info.transform.GetChild(1).GetComponent<Text>().text = sword.itemLocalizations[currentLocalization].name;

            damage.GetComponent<Text>().text = "+ " + sword.damageMin.ToString() + " ... " + sword.damageMax.ToString();

            if (sword.swordMageType == Item.TypeDamageMage.none) {
                mage.gameObject.SetActive(false);
            } else {
                mage.gameObject.SetActive(true);
                mage.GetChild(0).GetComponent<Text>().text = sword.mageDamage.ToString() + " %";
            }

            if (sword.requierLevel > HeroInformation.player.playerLevel) {
                button.SetActive(false);
                value.SetActive(true);
                value.transform.GetChild(0).GetComponent<Text>().text = sword.requierLevel.ToString();
            } else {
                button.SetActive(true);
                value.SetActive(false);
                Image image = button.transform.GetChild(0).GetComponent<Image>();
                if (sword.index == HeroInformation.player.sword.index) {
                    image.sprite = swordComponents[1];
                    image.color = new Color(0.6f, 0.6f, 0.6f);
                    tr.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
                } else {
                    image.sprite = swordComponents[0];
                    image.color = new Color(0.6f, 0.6f, 0.6f);
                    tr.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = Color.white;
                }
            }
            //конец инфо
        }
    }

    public void SwordButton(int i){     
        if (HeroInformation.player.currentSwordIndex != i) {
            HeroInformation.player.currentSwordIndex = i;
            HeroInformation.player.sword = itemDataBase.swords[i];
            audioManager.MenuAudio(3);
            SetSwords();
            eventSetSwordModel();
        }
    }
}

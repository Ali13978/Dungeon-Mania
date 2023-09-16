using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Purchasing;
public class ShopMain : MonoBehaviour{
    [Serializable]
    public struct Gem {
        public Sprite sprite;
        public int price;
        public int amount;
        public int storePrice;
    }
    public Gem[] gems;
    GameObject gameManager;
    AudioManager audioManager;
    public Text s;
    private void Awake() {
        transform.parent.parent.transform.localPosition = new Vector3(-250, 0, 0);
        gameManager = GameObject.Find("GameManager");
        audioManager = gameManager.GetComponent<AudioManager>();
        foreach (Transform tr in transform) {
            if (tr.GetSiblingIndex() > 0 & tr.GetSiblingIndex() < 5) { 
                int i = tr.GetSiblingIndex();
                i--;
                tr.GetChild(1).GetComponent<Image>().sprite = gems[i].sprite;
                tr.GetChild(2).GetChild(0).GetComponent<Text>().text = gems[i].amount.ToString();
                tr.GetChild(3).GetChild(0).GetComponent<Text>().text = gems[i].price.ToString();
                tr.GetChild(4).GetChild(0).gameObject.SetActive(true);
                if (CodelessIAPStoreListener.initializationComplete) {
                    //tr.GetChild(4).GetChild(0).gameObject.SetActive(true);
                    string price = CodelessIAPStoreListener.Instance.StoreController.products.all[i].metadata.localizedPriceString;
                    tr.GetChild(4).GetChild(0).GetComponent<Text>().text = price;
                }
                else
                    //tr.GetChild(4).GetChild(0).gameObject.SetActive(false);
                    tr.GetChild(4).GetChild(0).GetComponent<Text>().text = "...";
            }
        }
    }
    public void BuyGems(int i) {
        if (HeroInformation.player.gold >= gems[i].price) {
            HeroInformation.player.experiencePoint += gems[i].amount;
            HeroInformation.player.gold -= gems[i].price;
            HeroInformation.UpdateInformation();
            Info();
            audioManager.MenuAudio(1);
        } else {
            //ADS();
            return;
        } 
    }
    public void ADS() {
        //запускаем рекламу
    }
    void OnEnable(){
        //подгружаем рекламу
        UpdateCharacteristicsInfo.eventShop += Info;
        Info();
    }
    void OnDisable(){
        UpdateCharacteristicsInfo.eventShop -= Info;
    }
    public void Info(){
        foreach (Transform tr in transform) {
            if (tr.GetSiblingIndex() == 0) {
                 if (LocalizationManager.localizationIndex == 0) s.text = "Каждая покупка в приложении отключает рекламу";
                 else s.text = "Every in app purchase remove ads";
                /*
                if (IapManager.CheckNoAds()) {
                    tr.GetChild(2).gameObject.SetActive(false);
                    tr.GetChild(3).gameObject.SetActive(true);
                }
                else {
                    tr.GetChild(2).gameObject.SetActive(true);
                    tr.GetChild(3).gameObject.SetActive(false);
                    if (CodelessIAPStoreListener.initializationComplete) {
                        string price = CodelessIAPStoreListener.Instance.StoreController.products.WithID("no_ad").metadata.localizedPriceString;
                        tr.GetChild(2).GetChild(0).GetComponent<Text>().text = price;
                    }
                    else {
                        tr.GetChild(2).GetChild(0).GetComponent<Text>().text = "...";
                    }
                }
                */
            }
            else if (tr.GetSiblingIndex() > 0 & tr.GetSiblingIndex() < 5) {
                if (HeroInformation.player.gold >= gems[tr.GetSiblingIndex()-1].price) {
                    tr.GetChild(3).GetChild(0).GetComponent<Text>().color = new Color(0.62f, 0.62f, 0.62f);
                }
                else {
                    tr.GetChild(3).GetChild(0).GetComponent<Text>().color = Color.red;
                }
            }
        }
    }
}

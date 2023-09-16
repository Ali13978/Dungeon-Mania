using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
public class IapManager : MonoBehaviour{
    public void GetProduct(int i) {
        HeroInformation.player.experiencePoint += i;
        PlayerPrefs.SetString("NO_ADS", "yep");
        HeroInformation.UpdateInformation();
        GameController.PlayerSave();
    }

    public void NoAd() {
        PlayerPrefs.SetString("NO_ADS", "yep");
        UpdateCharacteristicsInfo.Shop();
    }

    public static bool CheckNoAds() {
        if (PlayerPrefs.HasKey("NO_ADS")) return true;
        else return CodelessIAPStoreListener.Instance.StoreController.products.WithID("no_ad").hasReceipt;
    }
 
}

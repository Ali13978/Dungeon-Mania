using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGems : MonoBehaviour{
    public int gems;
    public int price;
    GameObject gameManager;
    AudioManager audioManager;
    Image image;
    ShopMain shopMain;
    Text gemsText;
    Text priceText;
    void Awake(){
        gameManager = GameObject.Find("GameManager");
        audioManager = gameManager.GetComponent<AudioManager>();
        image = transform.GetChild(1).GetComponent<Image>();
        shopMain = transform.parent.GetComponent<ShopMain>();
        gemsText = transform.GetChild(0).GetChild(1).GetComponent<Text>();
        priceText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        priceText.text = price.ToString();
        gemsText.text = gems.ToString();
    }
    public void Buy(){
        if(HeroInformation.player.gold >= price){           
            audioManager.MenuAudio(1);
            //StartCoroutine(heroInformation.UpdateStat(-price, 0));
            HeroInformation.player.gold -= price;
            HeroInformation.player.experiencePoint += gems;
            HeroInformation.UpdateInformation();
            shopMain.Info(); 
        }
        else{
            //go to shop
        }
    }
    public void SetInfo(){
        if(HeroInformation.player.gold >= price) image.color = Color.white;
        else image.color = Color.red;
    }
}

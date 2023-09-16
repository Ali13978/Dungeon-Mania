using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Traning : MonoBehaviour{
    public Image leftStick;
    public Image rightStick;
    public Image leftImage;
    public Image rightImage;
    public GameObject bonusObject;
    public GameController gameController;
    public GameObject pauseObject;
    public GameObject adButton;

    private void Start() {
        StartCoroutine(StartGame());
    }

    public void SetExpert(bool b){
        if (!b) {
            leftStick.color = new Color(0, 0, 0, 0);
            rightStick.color = new Color(0, 0, 0, 0);
            leftImage.gameObject.SetActive(false);
            rightImage.gameObject.SetActive(false);
        } else {
            leftStick.color = new Color(0, 0, 0, 0.5f);
            rightStick.color = new Color(0, 0, 0, 0.5f);
            leftImage.gameObject.SetActive(true);
            rightImage.gameObject.SetActive(true);
        }
    }
    public void GetBonusGold() {
        HeroInformation.player.gold += 1000;
        HeroInformation.UpdateInformation();
    }
    public void GetDublleBonus() {
        bonusObject.SetActive(false);
        //gameController.ads.AdInfo(AdsManager.Earned.gold, 10000);
    }

    public IEnumerator Training() {
        //StartCoroutine(StartTrain());
        if (HeroInformation.player.settings.firstStart) {
            HeroInformation.player.settings.firstStart = false;
            gameController.Pause();
            pauseObject.SetActive(false);
            yield return new WaitForSeconds(2f);
            bonusObject.SetActive(true);
            adButton.SetActive(false);
            if (LocalizationManager.localizationIndex == 0)
                bonusObject.transform.GetChild(3).GetComponent<Text>().text = "Подземелье приветсвует тебя! Самое главное - золото! Ищи, собирай и меняй золото на кристаллы для улучшения персонажа!";
            else bonusObject.transform.GetChild(3).GetComponent<Text>().text = "The Dungeon greets you! The most important thing is Gold! Search, collect and exchange Gold for crystals to improve your character!";
        }
        else {
            bonusObject.SetActive(false);
        }
    }

    IEnumerator StartGame() {
        gameController.Pause();
        pauseObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        gameController.Pause();
        pauseObject.SetActive(true);
    }

    public IEnumerator StartTrain() {
        bonusObject.SetActive(false);
        if (HeroInformation.player.settings.firstStart) {
            HeroInformation.player.settings.firstStart = false;
            gameController.Pause();
            pauseObject.SetActive(false);
            SetExpert(true);
            yield return new WaitForSeconds(2f);
            SetExpert(false);
            bonusObject.SetActive(true);

            //SetTextBonus(PlayerPrefs.HasKey("NO_ADS"));

            adButton.SetActive(false);
            if (LocalizationManager.localizationIndex == 0)
                bonusObject.transform.GetChild(3).GetComponent<Text>().text = "Подземелье приветсвует тебя! Самое главное - золото! Ищи, собирай и меняй золото на кристаллы для улучшения персонажа!";
            else bonusObject.transform.GetChild(3).GetComponent<Text>().text = "The Dungeon greets you! The most important thing is Gold! Search, collect and exchange Gold for crystals to improve your character!";

        } else SetExpert(false);
    }

    void SetTextBonus(bool b) {

        if (b) {
            adButton.SetActive(true);
            adButton.transform.GetChild(1).gameObject.SetActive(false);
            if (LocalizationManager.localizationIndex == 0)
                bonusObject.transform.GetChild(3).GetComponent<Text>().text = "Подземелье приветсвует тебя! Самое главное - золото!" +
                    " Ищи, собирай и меняй золото на кристаллы для улучшения персонажа, а для начала получи подарок - один из древних артефактов Подземелья!";
            else bonusObject.transform.GetChild(3).GetComponent<Text>().text = "The Dungeon greets you! The most important thing is Gold! Search, collect and exchange Gold for crystals to improve your character " +
                    "and first, get a gift - one of the ancient artifacts of the Dungeon!";
        }
        else {
            if (/*AdsManager.CheckAds()*/ Advertisements.Instance.IsInterstitialAvailable()) 
            {
                adButton.SetActive(true);
                adButton.transform.GetChild(1).gameObject.SetActive(true);
                if (LocalizationManager.localizationIndex == 0)
                    bonusObject.transform.GetChild(3).GetComponent<Text>().text = "Подземелье приветсвует тебя! Самое главное - золото!" +
                        " Ищи, собирай и меняй золото на кристаллы для улучшения персонажа, а для начала получи подарок - один из древних артефактов Подземелья!";
                else bonusObject.transform.GetChild(3).GetComponent<Text>().text = "The Dungeon greets you! The most important thing is Gold! Search, collect and exchange Gold for crystals to improve your character " +
                        "and first, get a gift - one of the ancient artifacts of the Dungeon!";
            }
            else {
                adButton.SetActive(false);
                if (LocalizationManager.localizationIndex == 0)
                    bonusObject.transform.GetChild(3).GetComponent<Text>().text = "Подземелье приветсвует тебя! Самое главное - золото! Ищи, собирай и меняй золото на кристаллы для улучшения персонажа!";
                else bonusObject.transform.GetChild(3).GetComponent<Text>().text = "The Dungeon greets you! The most important thing is Gold! Search, collect and exchange Gold for crystals to improve your character!";
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using System.Globalization;
using GooglePlayGames;

public class EndGame : MonoBehaviour{
    public Text medalPlayer;
    public Text medalTop;
    public Text resurectionPercent;
    public GameObject resurection100;
    string id;
    public GameController gameController;
    public Text text;
    public void ResurectionMenu(){
        CheckButtons();
#if UNITY_IPHONE
        id = "com.sgs.dungeon.bestscore";
        if ( GamePlayManager.canResurection ) resurection100.SetActive(true);
        else resurection100.SetActive(false);
        CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
        medalPlayer.text = HeroInformation.player.score.ToString("0,0", elGR);
        if(Social.localUser.authenticated) Social.LoadScores( id, high =>{
            if(Social.localUser.authenticated && high.Length > 0) medalTop.text = high[0].formattedValue.ToString();
        });        
        resurectionPercent.text = HeroInformation.player.jesus.value.ToString() + "%";
        if(Social.localUser.authenticated) Social.ReportScore(
            (long)HeroInformation.player.score,
            id,
            success =>{
            }
        );
#elif UNITY_ANDROID
        id = "CgkI_v7B6sUREAIQAQ";
        resurectionPercent.text = HeroInformation.player.jesus.value.ToString() + "%";
        CheckButtons();
        CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
        medalPlayer.text = HeroInformation.player.score.ToString("0,0", elGR);

        PlayGamesPlatform.Instance.LoadScores(
            id,
            GooglePlayGames.BasicApi.LeaderboardStart.TopScores,
            10,
            GooglePlayGames.BasicApi.LeaderboardCollection.Public,
            GooglePlayGames.BasicApi.LeaderboardTimeSpan.AllTime,
            (data) => {
                medalTop.text = data.Scores[0].value.ToString("0,0", elGR);
            }
            ) ;
  
        PlayGamesPlatform.Instance.ReportScore((long)HeroInformation.player.score, id, "AllTime", (bool success) => { });
#endif
    }
    public void CheckButtons() {
        if (LocalizationManager.localizationIndex == 0) text.text = "Вероятность воскрешения";
        else text.text = "Chance of Resurrection";
        if (IapManager.CheckNoAds()) {
            if (GamePlayManager.canResurection) {
                resurection100.SetActive(true);
                resurection100.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            } 
            else resurection100.SetActive(false);
        }
        else {
            if (GamePlayManager.canResurection & Application.internetReachability != NetworkReachability.NotReachable) {
                //if (AdsManager.CheckAds()) {
                    resurection100.SetActive(true);
                    resurection100.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                }
                //else resurection100.SetActive(false);
            //}
            else {
                resurection100.SetActive(false);
            }
        }
    }
}

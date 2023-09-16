using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager ads;
    // Start is called before the first frame update
    void Start()
    {
        ads = this;
        Advertisements.Instance.SetUserConsent(true);
        Advertisements.Instance.Initialize();


        ///// Showing Banner /////////

        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.SmartBanner);
    }

    public void ShowingInterstitial()
    {
        Advertisements.Instance.ShowInterstitial(InterstitialClosed);

    }
    private void InterstitialClosed(string advertiser)
    {
        Debug.Log("Interstitial closed from: " + advertiser + " -> Resume Game ");
    }

    public void ShowingRewardedVideo()
    {
        Advertisements.Instance.ShowRewardedVideo(CompleteMethod);

    }
    private void CompleteMethod(bool completed, string advertiser)
    {
        Debug.Log("Closed rewarded from: " + advertiser + " -> Completed " + completed);
        if (completed == true)
        {
            //give the reward
        }
        else
        {
            //no reward
        }
    }


}

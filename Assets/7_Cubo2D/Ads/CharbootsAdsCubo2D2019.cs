using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using ChartboostSDK;
public class CharbootsAdsCubo2D2019 : MonoBehaviour {

    public Button VideoAdsRecompensasBoton;
    public CanvasGroup Canvas;
    [SerializeField]
    bool CargarInterstOnStart = false;
    // Use this for initialization
    void Start () {
        //Chartboost.CreateWithAppId("57d97c7504b0167185e841ee", "f8151a53a8fce086ac6c1d95e31bce39496a6d0c");
        //Chartboost.setAutoCacheAds(true);

        //Chartboost.didCompleteRewardedVideo -= didCompleteRewardedVideo;

        if (CargarInterstOnStart) {
            showInterstitial();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ActualizarBoton() {

        /*if (Chartboost.hasRewardedVideo(CBLocation.MainMenu))
        {
            VideoAdsRecompensasBoton.interactable = true;
            if (Canvas != null)
                Canvas.alpha = 1;
        }
        else
        {
            // We don't have a cached video right now, but try to get one for next time
            VideoAdsRecompensasBoton.interactable = false;
            if (Canvas != null)
                Canvas.alpha = 0;
        }*/

    }

    public void RequestRewaredAds() {
       // Chartboost.cacheRewardedVideo(CBLocation.MainMenu);
    }

    public void OnClickShowRewaredAds() {

#if UNITY_EDITOR
        SendMessage("videoRecompensaCompleto", "1");
#endif

        /*if (Chartboost.hasRewardedVideo(CBLocation.MainMenu))
        {
            VideoAdsRecompensasBoton.interactable = false;
            Chartboost.showRewardedVideo(CBLocation.MainMenu);
        }
        else
        {
            // We don't have a cached video right now, but try to get one for next time
            Chartboost.cacheRewardedVideo(CBLocation.MainMenu);
        }*/
    }

    public void RequestInterstitial()
    {

        ///Chartboost.cacheInterstitial(CBLocation.MainMenu);
    }

    public void OnClickShowInterstitial() {
        showInterstitial();
    }

    public void showInterstitial() {

       /* if (Chartboost.hasInterstitial(CBLocation.MainMenu))
        {
            Chartboost.showInterstitial(CBLocation.MainMenu);
        }
        else
        {
            // We don't have a cached video right now, but try to get one for next time
            Chartboost.cacheInterstitial(CBLocation.MainMenu);
        }*/

    }

    public void showBanner() { 
        
    }

    // Called after a rewarded video has been viewed completely and user is eligible for reward.
   /* void didCompleteRewardedVideo(CBLocation location, int reward) {
        SendMessage("videoRecompensaCompleto", reward);
    }*/
}

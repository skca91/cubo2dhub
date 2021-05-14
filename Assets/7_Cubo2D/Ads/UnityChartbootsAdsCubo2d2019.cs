using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using ChartboostSDK;
using UnityEngine.Advertisements;

public class UnityChartbootsAdsCubo2d2019 : MonoBehaviour ,IUnityAdsListener
{
    public Button VideoRecompensaButton;
    CanvasGroup CanvasGroupButton;
    public Button VideoRecompensaButton2;
    CanvasGroup CanvasGroupButton2;
    [SerializeField]
    float PazDuracion = 120;
    [SerializeField]
    string AndroidAppIdUnity;
    [SerializeField]
    string iOSAppIdUnity;
    bool paz = false;
    bool MostrarAds = true;
    int contAds = 0;
    [SerializeField]
    GameObject RemoveAdsButton;
    [SerializeField]
    bool Debug = false;
    [SerializeField]
    bool TestMode = false;
    public static readonly string video = "video";
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetString("MostrarAds", "si").Equals("si"))
        {
            MostrarAds = true;
        }
        else {
            MostrarAds = false;
            if(RemoveAdsButton != null)
                RemoveAdsButton.SetActive(false);
        }

        if (!MostrarAds && !Debug) {
            //UnityEngine.Debug.Log("sin ads activado");
            return;
        }

        contAds = 0;
        //Chartboost.setAutoCacheAds(true);
        CanvasGroupButton = VideoRecompensaButton?.GetComponent<CanvasGroup>();
        if(VideoRecompensaButton2!=null)
            CanvasGroupButton2 = VideoRecompensaButton2.GetComponent<CanvasGroup>();
        InvokeRepeating("UpdateVideoRecompensaButton", 0,0.5f);


        //UnityEngine.Debug.Log("CanvasGroupButton ok");

#if UNITY_IPHONE
        if (string.IsNullOrEmpty(iOSAppIdUnity))
        {
            //Debug.Log("falta iOSAppIdUnity ");
        }
        else
        {

            if (Advertisement.isSupported)
            {
                Advertisement.Initialize(iOSAppIdUnity);

                //Debug.Log($"Initialize iOSAppIdUnity:{iOSAppIdUnity}");
            }
            else
            {
                //Debug.Log("Plataforma no soportada para " + Advertisement.version);
            }
        }
#else
        //UnityEngine.Debug.Log("plataforma " + Application.platform.ToString());

        if (string.IsNullOrEmpty(AndroidAppIdUnity))
        {
            //UnityEngine.Debug.Log("falta AndroidAppIdUnity " );
        }
        else {

            if (Advertisement.isSupported)
            {

                //UnityEngine.Debug.Log($"intento Initialize AndroidAppIdUnity:{AndroidAppIdUnity}");

                Advertisement.AddListener(this);
                Advertisement.Initialize(AndroidAppIdUnity, TestMode);

                //UnityEngine.Debug.Log($"Initialize AndroidAppIdUnity:{AndroidAppIdUnity} ok");
            }
            else {
                //UnityEngine.Debug.Log("Plataforma no soportada para " + Advertisement.version);
            }
        }
#endif


        //UnityEngine.Debug.Log($"loads");

        Advertisement.Load(video);
        Advertisement.Load("showInterstitial");
        Advertisement.Load("banner");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DesactivarPaz() {
        paz = false;
    }


    public void showInterstitial()
    {
        //UnityEngine.Debug.Log("showInterstitial");
        if (paz||(!MostrarAds && !Debug))
        {
            return;
        }
        
        if (Advertisement.IsReady("video") && !(contAds%3==0)) {
            Advertisement.Show("video");
            paz = true;
            Invoke("DesactivarPaz", PazDuracion);
        }
        else {
            /*if (Chartboost.hasInterstitial(CBLocation.MainMenu))
            {
                Chartboost.showInterstitial(CBLocation.MainMenu);
                paz = true;
                Invoke("DesactivarPaz", PazDuracion);
            }
            else
            {
                // We don't have a cached video right now, but try to get one for next time
                Chartboost.cacheInterstitial(CBLocation.MainMenu);
                
            }*/

            //if (Advertisement.IsReady("video"))
            Advertisement.Load("video");

        }

        contAds++;
    }

    private void UpdateVideoRecompensaButton()
    {
        if (VideoRecompensaButton == null)
            return;

        if ( Advertisement.IsReady("rewardedVideo"))
        {
            VideoRecompensaButton.interactable = true;
            if (CanvasGroupButton != null)
                CanvasGroupButton.alpha = 1;

            if (VideoRecompensaButton2 != null)
            {
                VideoRecompensaButton2.interactable = true;
                CanvasGroupButton2.alpha = 1;
            }
        }
        else
        {
            // We don't have a cached video right now, but try to get one for next time
            VideoRecompensaButton.interactable = false;
            if (CanvasGroupButton != null)
                CanvasGroupButton.alpha = 0;

            if (VideoRecompensaButton2 != null)
            {
                VideoRecompensaButton2.interactable = false;
                CanvasGroupButton2.alpha = 0;
            }
        }
    }

    public void OnClickShowRewaredAds(){
        //UnityEngine.Debug.Log("OnClickShowRewaredAds");

        if (Advertisement.IsReady("rewardedVideo"))
        {
            VideoRecompensaButton.interactable = false;
            //var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo");
        }
        else {
            Advertisement.Load("rewardedVideo");
        }

/*#if UNITY_EDITOR
        SendMessage("videoRecompensaCompleto", "1");
#endif*/
    }


    #region Video compensa Respuesta


    //unityads
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                //UnityEngine.Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                paz = true;
                Invoke("DesactivarPaz", PazDuracion * 2f);
                SendMessage("videoRecompensaCompleto", "1");
                break;
            case ShowResult.Skipped:
                //UnityEngine.Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                //UnityEngine.Debug.LogError("The ad failed to be shown.");
                break;
        }
    }


    #endregion Video compensa Respuesta


    public void showBanner()
    {
        if (!MostrarAds && !Debug) {
            return;
        }

        //UnityEngine.Debug.Log("showBanner");
        if (Advertisement.IsReady("banner"))
        {

            Advertisement.Banner.Show("banner");
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            //Advertisement.Banner.Hide();
        }
        else {
            Advertisement.Load("banner");
        }
    }

    public void hideBanner()
    {
        //UnityEngine.Debug.Log("hideBanner");
        Advertisement.Banner.Hide();
        
    }


    public void NoAds() {
        PlayerPrefs.SetString("MostrarAds","no");
        MostrarAds = false;
        //UnityEngine.Debug.Log("wii NoAds");
        RemoveAdsButton.SetActive(false);
    }

    public void OnUnityAdsReady(string placementId)
    {
        //UnityEngine.Debug.Log($"OnUnityAdsReady placementId: {placementId}");
    }

    public void OnUnityAdsDidError(string message)
    {
        //UnityEngine.Debug.Log($"OnUnityAdsDidError message: {message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //UnityEngine.Debug.Log($"OnUnityAdsDidStart placementId: {placementId} ");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //UnityEngine.Debug.Log($"OnUnityAdsDidFinish placementId: {placementId} showResult: {showResult}");
        if (placementId == video) {
            HandleShowResult(showResult);
        }
    }
}

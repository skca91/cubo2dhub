using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
#if UNITY_IOS
// Include the IosSupport namespace if running on iOS:
using Unity.Advertisement.IosSupport;
#endif


public class UnityChartbootsAdsCubo2d2019 : MonoBehaviour, IUnityAdsListener
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
    public static bool paz = false;
    bool MostrarAds = true;
    public static int contAds = 0;
    [SerializeField]
    GameObject RemoveAdsButton;
    [SerializeField]
    bool DebugMode = false;
    [SerializeField]
    bool TestMode = false;
    public static readonly string video = "video";
    [SerializeField]
    int frecuenciaAds = 3;
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

        if (!MostrarAds && !DebugMode) {
            //UnityEngine.Debug.Log("sin ads activado");
            return;
        }

        contAds = 0;
        //Chartboost.setAutoCacheAds(true);
        CanvasGroupButton = VideoRecompensaButton?.GetComponent<CanvasGroup>();
        if(VideoRecompensaButton2!=null)
            CanvasGroupButton2 = VideoRecompensaButton2.GetComponent<CanvasGroup>();
        InvokeRepeating("UpdateVideoRecompensaButton", 0,0.5f);


        if (Advertisement.isSupported)
        {
            if (!Advertisement.isInitialized)
            {
                InicializarAds(iOSAppIdUnity, AndroidAppIdUnity);
            }
            else {
            }

            Advertisement.Load(video);
            Advertisement.Load("showInterstitial");
            Advertisement.Load("banner");
        }
        else {
            Debug.Log($"Plataforma {Application.platform} no soportada Ads para la version " + Advertisement.version);
        }
    }


    public void InicializarAds(string iOSAppId,string AndroidAppId) {

        Advertisement.AddListener(this);

#if UNITY_IPHONE
        if (string.IsNullOrEmpty(iOSAppIdUnity))
        {
            Debug.Log("falta iOSAppIdUnity ");
        }
        else
        {
            // Check the user's consent status.
            // If the status is undetermined, display the request request: 
            if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                ATTrackingStatusBinding.RequestAuthorizationTracking();
            }

            Advertisement.Initialize(iOSAppId, TestMode);
        }
#else

        if (string.IsNullOrEmpty(AndroidAppIdUnity))
        {
            UnityEngine.Debug.Log("falta AndroidAppIdUnity " );
        }
        else
        {
            Advertisement.Initialize(AndroidAppId, TestMode);
        }
#endif
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
        if (paz||(!MostrarAds && !DebugMode))
        {
            return;
        }
        
        if (Advertisement.IsReady(video) &&(frecuenciaAds == 0 ||!(contAds % frecuenciaAds == 0))) {
            Advertisement.Show(video);
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
            Advertisement.Load(video);

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
        if (!MostrarAds && !DebugMode) {
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

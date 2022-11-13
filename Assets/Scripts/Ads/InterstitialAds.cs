using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class InterstitialAds : MonoBehaviour, IUnityAdsListener
{
    private string gameID = "4525532";
    private string bannerID = "Banner_2";
    private string interstitialID = "Interstitial_Android";
    public bool TestMode;
    public Button showInterstitial;

    public GameObject Interstitial;

    void Start()
    {
        Advertisement.Initialize(gameID, TestMode);
        showInterstitial.interactable = Advertisement.IsReady(interstitialID);
        Advertisement.AddListener(this);
    }

    public void ShowInterstitial()
    {
        if (Advertisement.IsReady(interstitialID))
        {
            Advertisement.Show(interstitialID);
        }
    }


    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementID)
    {

        if (placementID == interstitialID)
        {
            showInterstitial.interactable = true;
        }

        if (placementID == bannerID)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerID);
        }
    }

    public void OnUnityAdsDidFinish(string placementID, ShowResult showResult)
    {
        if (placementID == interstitialID)
        {
            if (showResult == ShowResult.Finished)
            {
                //Do nothing
            }
            else if (showResult == ShowResult.Skipped)
            {
                //Do nothing
            }
            else if (showResult == ShowResult.Failed)
            {
                //tell player ads failed
            }
        }
    }


    public void OnUnityAdsDidError(string message)
    {
        //Show or log the error here
    }

    public void OnUnityAdsDidStart(string placementID)
    {
        //Do this if ads starts
    }


}

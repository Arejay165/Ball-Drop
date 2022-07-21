using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class AdManager : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update
    string playstoreID = "4006423";
    string appleID = "4006422";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    [SerializeField]
    private GameObject errorUI;

    [SerializeField]
    private bool isTargetPlayStore;
    [SerializeField]
    private bool isTestAd;

    [SerializeField]
    private GameObject reviveAdUI;

    [SerializeField]
    private GameManager gameManager;


    public UIManager uIManager;

    public Button claimRewardButton;
    public GiftManager giftManager;
    public RewardManager rewardManager;
    public Button retryButton;
   
    void Start()
    {
        // Initialize the Ads service:
        //Advertisement.AddListener(this);
              intializeAd();
        Advertisement.AddListener(this);
  
    }

    void intializeAd()
    {
        if (isTargetPlayStore)
        {
            Advertisement.Initialize(playstoreID, isTestAd);
            // Show an ad:
            // Advertisement.Show();
        }
        else
        {
            Advertisement.Initialize(appleID, isTestAd);
            // Show an ad:
            //Advertisement.Show();
        }
    }

    public void playInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        else
        {
            Advertisement.Show(interstitialAd);
        }
    }

    public void PlayRewardedVideoAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        else
        {
            Advertisement.Show(rewardedVideoAd);

        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
        AudioListener.pause = true;

        AudioListener.volume = 0;

      
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        AudioListener.pause = false;

        AudioListener.volume = 1;



        switch (showResult)
        {
            case ShowResult.Failed:
                ///Show message about not finishing the ad
                ///
                reviveAdUI.SetActive(false);
                errorUI.SetActive(true);

                break;

            case ShowResult.Skipped:
                ///Show message about not finishing the ad
                ///
                reviveAdUI.SetActive(false);
                errorUI.SetActive(true);

                break;

            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {

                   

                    claimRewardButton.onClick.AddListener(giftManager.rewards);
                    retryButton.onClick.AddListener(rewardManager.retryRoll);
                  
                }
                if (placementId == interstitialAd)
                {
                    
                    

                    Debug.Log("FinishInterstisda");
                }
                break;
        }
    }


    

   

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject playerRef;
    public GameObject tileManager;
    public GameObject shopManagerUI;
    public GameObject mainMenuUI;
    public GameObject shopMenuUI;
    public GameObject inGameUI;
    public GameObject adUI;
    public GameObject pauseUI;
    public GameObject reviveUI;
    public GameObject errorUI;
    public GameObject volumeOnUI;
    public GameObject volumeOffUI;
    public GameObject vibrateOnUI;
    public GameObject vibrateOffUI;
    public GameObject noAdsUI;
    public GameObject settingUI;
    public GameObject exitSettingUI;
    public GameObject settingButton;
    public GameObject playButton;
    public Text mainMenuCoinUI;
    public Text mainMenuPointUI;
    public Text shopCoinTextUI;
    public Text shopPointTextUI;
    public bool isRetryState;
    public int isRetry;
    public int isRetryRef;
    public bool isVibrate;
    public AdManager adManager;
    public int adCounter;
    public enum PurchaseType { removeAds };
    public PurchaseType purchaseType;
    public Rigidbody rigidbody;
    public int gameRounds;
    public GameObject epicPrompt;
    public GameObject challengeUI;
    public int progressGift;
    public RewardManager rewardManager;
    public ReviveUITransitionPrompt reviveUITransitionPrompt;
    public GiftManager giftManager;
    public GameObject giftUI;
    public GameObject rewardUI;
    public GameObject playerShop;
    public GameObject floorShop;
    public GameObject trailShop, progressUI;
    public int RandChance;
    public UnlockFloors unlockFloors;
    public TileManager TileManager;
    public GameObject[] StartPlatforms;
    public int levelReference;
    public int currentCoins;
    public int currentPoints;
    public GameManager gameManager;
    public Text challengePoint, challengeCoin;
    // Start is called before the first frame update


    void Start()
    {
        tileManager.SetActive(true);
        gameRounds = PlayerPrefs.GetInt("gameRounds", gameRounds);
        DisplayPointsandCoins();
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Time.timeScale = 1;
        adCounter = PlayerPrefs.GetInt("adCounter");
        levelReference = PlayerPrefs.GetInt("levelNumber");
        currentCoins = PlayerPrefs.GetInt("currentCoin");
        currentPoints = PlayerPrefs.GetInt("currentCoin");
        progressGift = PlayerPrefs.GetInt("progressGift");
        Debug.Log(progressGift);
        //if(adCounter == 1)
        //{
        //    NoAdUI();
        //}

        if(progressGift >= 100)
        {
            progressGift = 0;
            PlayerPrefs.SetInt("progressGift", progressGift);
        }

        if (gameRounds % 5 == 0 && RandChance > 50)
        {
            epicPrompt.SetActive(true);
        }

    }


    public void MainMenuUI()
    {

        shopMenuUI.SetActive(false);
        DisplayPointsandCoins();
        isRetryState = false;
        isRetry = 0;
        PlayerPrefs.SetInt("isRetry", isRetry);
        PlayerPrefs.Save();
    }

    public void BackMainMenuButton()
    {
        shopMenuUI.SetActive(false);
        settingUI.SetActive(false);
        mainMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        adUI.SetActive(false);
        DisplayPointsandCoins();
        shopManagerUI.SetActive(false);
        isRetryState = false;
        isRetry = 0;
        playerRef.SetActive(true);
        tileManager.SetActive(true);
        challengeUI.SetActive(false);
       
        PlayerPrefs.SetInt("isRetry", isRetry);
        PlayerPrefs.Save();

    }

    public void StartGame()
    {
        rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;

     
        TileManager.StartSpawning();
        gameManager.StartDisplayCurrency();
        inGameUI.SetActive(true);
        mainMenuUI.SetActive(false);
        shopMenuUI.SetActive(false);
        adUI.SetActive(false);
        //reviveUI.SetActive(false);
        challengeUI.SetActive(false);
        isRetry = 1;
        PlayerPrefs.SetInt("isRetry", isRetry);
        PlayerPrefs.Save();

    }
    public void ShopMenuUI()
    {
       StartCoroutine(moveRightTransition( mainMenuUI,  shopMenuUI));
        for(int i = 0; i < StartPlatforms.Length; i++)
        {
            StartPlatforms[i].SetActive(false);
        }
        shopManagerUI.SetActive(true);
        playerRef.SetActive(false);
        tileManager.SetActive(false);
        DisplayShopCoinandPoint();
    }

    public void PauseUI()
    {
        inGameUI.SetActive(false);
        pauseUI.SetActive(true);
    }

    public void UnPause()
    {
        inGameUI.SetActive(true);
        pauseUI.SetActive(false);
    }

    public void ReviveUI()
    {
      
        inGameUI.SetActive(false);
        progressUI.SetActive(true);
        if (epicPrompt.activeSelf)
        {
            rewardUI.SetActive(true);
            rewardManager.StartAnimation();
         
        }
        else if(progressGift >= 100)
        {
            giftUI.SetActive(true);
            giftManager.StartAnimation();
            giftManager.rewards();
        }
        else
        {
            reviveUI.SetActive(true);
            reviveUITransitionPrompt.StartAnimation();
        }
    }
    public void ErrorAdUI()
    {
        inGameUI.SetActive(false);
        errorUI.SetActive(true);
    }

    void DisplayPointsandCoins()
    {
        mainMenuCoinUI.text = PlayerPrefs.GetInt("currentCoin").ToString();
        mainMenuPointUI.text = PlayerPrefs.GetInt("currentPoint").ToString();
        //mainMenuCoinUI.text = currentCoins.ToString();
        //mainMenuPointUI.text = currentPoints.ToString();
    }

    public void DisplayShopCoinandPoint()
    {
        shopCoinTextUI.text = PlayerPrefs.GetInt("currentCoin").ToString();
        shopPointTextUI.text = PlayerPrefs.GetInt("currentPoint").ToString();
    }

    public void ChallengeDisplayCoinAndPoint()
    {
        challengeCoin.text = PlayerPrefs.GetInt("currentCoin").ToString();
        challengePoint.text = PlayerPrefs.GetInt("currentPoint").ToString();
    }

    public void loadlevel(int scenenumber)
    {
     
        Time.timeScale = 1;
        gameRounds += 1;
        int pointRef = PlayerPrefs.GetInt("points");
        int coinRef = PlayerPrefs.GetInt("coins");
        pointRef = 0;
        coinRef = 0;
        if (progressGift <= 100)
        {
            progressGift += 5;
        }
        
        PlayerPrefs.SetInt("pointsRef", pointRef);
        PlayerPrefs.SetInt("coinsRef", coinRef);
        PlayerPrefs.SetInt("gameRounds", gameRounds);
        PlayerPrefs.SetInt("progressGift", progressGift);

        PlayerPrefs.Save();
        SceneManager.LoadScene(scenenumber);

    }

    public void AddValue()
    {
        isRetry = 1;
        PlayerPrefs.SetInt("isRetry", isRetry);
        PlayerPrefs.Save();

    }

    public void VolumeON()
    {
        volumeOffUI.SetActive(false);
        volumeOnUI.SetActive(true);
        AudioListener.pause = false;

        AudioListener.volume = 1;
    }

    public void VolumeOff()
    {
        volumeOnUI.SetActive(false);
        volumeOffUI.SetActive(true);
        AudioListener.pause = true;

        AudioListener.volume = 0;

    }

    public void VibrateOn()
    {
        vibrateOffUI.SetActive(false);
        vibrateOnUI.SetActive(true);
        isVibrate = true;
    }

    public void VibrateOff()
    {
        vibrateOffUI.SetActive(true);
        vibrateOnUI.SetActive(false);
        isVibrate = false;
    }

    public void ShowSettingUI()
    {

        StartCoroutine(moveYTransition(mainMenuUI, settingUI));
 
        playButton.SetActive(false);
      
        exitSettingUI.SetActive(true);


    }

    public void NoAdUI()
    {
        IAPManager.instance.BuyRemoveAds();
        adManager.enabled = false;

    }
    public void ExitSettings()
    {
      StartCoroutine(ResetPositionTransition(mainMenuUI, settingUI));
        tileManager.SetActive(true);
    }
    public void ExitChallengeUI()
    {
        StartCoroutine(ResetPositionTransition(mainMenuUI, challengeUI));
        tileManager.SetActive(true);
    }
    
    public void ExitShopUI()
    {
      
        StartCoroutine(ResetPositionTransition(mainMenuUI, shopMenuUI));
    
        for (int i = 0; i < StartPlatforms.Length; i++)
        {
            StartPlatforms[i].SetActive(true);
        }
        playerRef.SetActive(true);
        tileManager.SetActive(true);
        shopManagerUI.SetActive(false);
    }

   
    public void ChallengeUI()
    {
       StartCoroutine(moveLeftTransition(mainMenuUI, challengeUI));
        ChallengeDisplayCoinAndPoint();

    }

   IEnumerator moveYTransition(GameObject objectTransition, GameObject objectMove)
    {

        LeanTween.moveLocalY(objectTransition, -621f, 0.7f).setEase(LeanTweenType.easeOutElastic);
        yield return new WaitForSeconds(0.5f);
        objectTransition.SetActive(false);
        objectMove.SetActive(true);



    }

    IEnumerator ResetPositionTransition(GameObject objectTransition, GameObject objectMove)
    {
  
       LeanTween.moveLocal(objectTransition, new Vector3(0,0,0), 0.7f).setEase(LeanTweenType.easeOutElastic);
        yield return new WaitForSeconds(0.5f);
        objectTransition.SetActive(true);
        objectMove.SetActive(false);
    }

    IEnumerator moveLeftTransition(GameObject objectTransition, GameObject objectMove)
    {
        LeanTween.moveLocalX(objectTransition, -621f, 0.7f).setEase(LeanTweenType.easeOutElastic);
        yield return new WaitForSeconds(0.5f);
        objectTransition.SetActive(false);
        objectMove.SetActive(true);
    }

    IEnumerator moveRightTransition(GameObject objectTransition, GameObject objectMove)
    {
        LeanTween.moveLocalX(objectTransition, 348f, 0.7f).setEase(LeanTweenType.easeOutElastic);
        yield return new WaitForSeconds(0.5f);
        objectTransition.SetActive(false);
        objectMove.SetActive(true);
    }

    public void PlayerShop()
    {
        playerShop.SetActive(true);
        floorShop.SetActive(false);
        trailShop.SetActive(false);
    }

    public void FloorShop()
    {
        playerShop.SetActive(false);
        floorShop.SetActive(true);
        trailShop.SetActive(false);
    }
    public void TrailShop()
    {
        playerShop.SetActive(false);
        floorShop.SetActive(false);
        trailShop.SetActive(true);
    }
}
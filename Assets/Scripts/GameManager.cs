using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public Text coinText, pointText, scoreText, highscoreText, beforeAdText, afterAdText,deathScoreText;
    public int currentPoint, currentCoin, currentScore, coinsRef, pointsRef, adCounter;
    public Transform playerTransform;
    public float score, highscore;
    public Transform spawnLoc;
    public bool coinAddSelect, pointAddSelect;

    private GameObject[] player;
    public int characterChoose;
    public UIManager uIManager;
    public AdManager adManager;
    public GameObject designHighScoreImage;
    public LevelManager levelManager;
    public Sprite checkMark, crossMark;
    
    public Image[] checkers;
    public Sprite lockedImage;
    public Image[] challenges;
    public GameObject[] levelImage;
    public CoinManager coinManager;
    public Transform spawnPoint;
    public GameObject highscorePrompt;
    public GameObject coinPrefab;
    public int randomNum;
    public GameObject[] replayButton;
    public GameObject[] noAdsReplayButton;
    public GameObject noAdsRollButton;
    public GameObject adsRollButton;
    public GameObject noAdsClaimButton;
    public GameObject adsClaimButton;
    public GameObject noAdsTimesThree;
    public GameObject adsTimesThree;
    public Text[] levelName, levelCost;
    public int levelNumber;
    public Text inGameDiamondText, inGamePointText;
    public RectTransform crownTransform;
    public SoudManager soudManager;
    public ProgressBar progressBar;
    public float randomAd;
    // Start is called before the first frame update
    void Start()
    {
        randomAd = Random.Range(0, 100);

        if(randomAd >= 50)
        {
            adManager.PlayRewardedVideoAd();
        }
         adCounter = PlayerPrefs.GetInt("adCounter");
        characterChoose = PlayerPrefs.GetInt("characterNumber", characterChoose);
        if (adCounter == 1)
        {
            //Change Sprite UI's 
            adsTimesThree.SetActive(false);
            adsRollButton.SetActive(false);
            adsClaimButton.SetActive(false);
            noAdsRollButton.SetActive(true);
            noAdsClaimButton.SetActive(true);
            noAdsTimesThree.SetActive(true);
            for (int i = 0; i < levelManager.levels.Length; i++)
            {
             
                noAdsReplayButton[i].SetActive(true);
                replayButton[i].SetActive(false);
            }

        }
        //CharacterChoose();
        pointsRef = 0;
        coinsRef = 0;
        PlayerPrefs.SetInt("pointsRef", pointsRef);
        PlayerPrefs.SetInt("coinsRef", coinsRef);
        PlayerPrefs.Save();

         highscore = PlayerPrefs.GetFloat("highscore", highscore);
         highscoreText.text = highscore.ToString("0");
        ReplayChallenge();

    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerTransform.position.z.ToString("0");
        score = playerTransform.position.z;
 
    }

    public void SpawnCatcher()
    {
        if (score >= highscore)
        {
            SpawnHighScorePrompt();
        }
        else
        {
            SpawnDiamonds();
        }
    }

    public void SetPoints(int points)
    {
        currentPoint = PlayerPrefs.GetInt("currentPoint", currentPoint);
        pointsRef = PlayerPrefs.GetInt("pointRef", pointsRef);
        currentPoint += points;
        pointText.text =  " "+ currentPoint;
        pointsRef += points;
        Debug.Log(pointsRef);
        PlayerPrefs.SetInt("pointsRef", pointsRef);
        PlayerPrefs.SetInt("currentPoint", currentPoint);
        PlayerPrefs.Save();
    }

    public void SetCoins(int coins)
    {
        currentCoin = PlayerPrefs.GetInt("currentCoin", currentCoin);
        currentCoin += coins;
        coinText.text = " " + currentCoin;
        coinsRef += coinsRef;
        PlayerPrefs.SetInt("coinsRef", coinsRef);
        PlayerPrefs.SetInt("currentCoin", currentCoin);
        PlayerPrefs.Save();
    }

    public void DisplayCoin()
    {

        coinsRef = PlayerPrefs.GetInt("coinsRef");
        currentCoin = PlayerPrefs.GetInt("currentCoin", currentCoin);
        currentCoin += coinsRef;
        coinText.text = " " + currentCoin;
        PlayerPrefs.SetInt("currentCoin", currentCoin);
        PlayerPrefs.Save();

    }

    public void StartDisplayCurrency()
    {
        currentCoin = PlayerPrefs.GetInt("currentCoin", currentCoin);
        currentPoint = PlayerPrefs.GetInt("currentPoint", currentPoint);
        coinText.text = " " + currentCoin;
        pointText.text = " " + currentPoint;
        inGameDiamondText.text = " " + currentCoin;
        inGamePointText.text = " " + currentPoint;
    }

    public void DisplayPoint()
    {
        pointsRef = PlayerPrefs.GetInt("pointsRef");
        currentPoint = PlayerPrefs.GetInt("currentPoint", currentPoint);
        currentPoint += pointsRef;

        pointText.text = " " + currentPoint;
       
        PlayerPrefs.SetInt("currentPoint", currentPoint);
        PlayerPrefs.Save();
    }

    public void AdsDisplayPoint()
    {
      
        pointsRef = PlayerPrefs.GetInt("pointRef", pointsRef);
        Debug.Log("After death" + pointsRef);
        afterAdText.text = " x " +pointsRef * 3;
    }

    public void AdsTimesThreePoint()
    {
        if (adCounter != 1)
        {
            adManager.playInterstitialAd();
        }
        coinsRef = PlayerPrefs.GetInt("pointsRef");
        coinsRef *= 3;
        currentPoint = PlayerPrefs.GetInt("currentPoint", currentPoint);
        currentPoint += coinsRef; 
        Debug.Log( "Current Point" + currentPoint);
        Debug.Log(coinsRef);
        PlayerPrefs.SetInt("currentPoint", currentPoint);
      
        PlayerPrefs.Save();

        uIManager.loadlevel(1);
       
    }

 
    public void SetHigherScore()
    {
        

        highscore = PlayerPrefs.GetFloat("highscore", highscore);
       
        PlayerPrefs.Save();
        if (score >= highscore)
        {
            soudManager.CongratsOnSfx();
            highscore = score;
            designHighScoreImage.SetActive(true);
            StartCoroutine(crownAnimation());
            deathScoreText.text = scoreText.text;
            PlayerPrefs.SetFloat("highscore", highscore);
            PlayerPrefs.Save();

        }
        else
        {

            designHighScoreImage.SetActive(false);
            deathScoreText.text = scoreText.text;
        }

    }

    public IEnumerator crownAnimation()
    {
        // Tween mytween = crownTransform.DOJumpAnchorPos(new Vector2(6, -57), 5f, 2, 2f, false);
        Tween mytween = crownTransform.DOShakeScale(2f, 2f, 20, 180, true);
          yield return mytween.WaitForCompletion();
    }

   
   public void SpawnDiamonds()
    {
        GameObject go = Instantiate(coinPrefab, spawnLoc.position, Quaternion.identity) as GameObject;
        go.transform.Rotate(0, 0, 180f);
        spawnLoc.transform.position = go.transform.position - new Vector3(0, -5, 6);
    }

    public void SpawnHighScorePrompt()
    {
        GameObject go = Instantiate(highscorePrompt, spawnLoc.position, Quaternion.identity) as GameObject;
        spawnLoc.transform.position = go.transform.position - new Vector3(0, -5, 6);
    }

   public void CalculatePointsCoinsScore()
    {
        int coinAdded = PlayerPrefs.GetInt("currentCoin", currentCoin);
        int pointAdded = PlayerPrefs.GetInt("currentPoint", currentPoint);
        int setScore = PlayerPrefs.GetInt("currentScore", currentScore);
        currentCoin += coinAdded;
        currentPoint += pointAdded;
        currentScore = setScore;
        PlayerPrefs.SetInt("currentCoin", currentCoin);
        PlayerPrefs.SetInt("currentPoint", currentPoint);
        PlayerPrefs.SetInt("currentScore", currentScore);
        PlayerPrefs.Save();
    }

    public void RevivePlayer()
    {
        coinAddSelect = false;
        pointAddSelect = false;
        playerTransform.transform.position = spawnLoc.transform.position + new Vector3(0, -5, 6);
    }

    public void Retry()
    {
        playerTransform.transform.position = Vector3.zero;

      
        SceneManager.LoadScene(0);
    
  
    }

    public void AddPointsThruAd()
    {
        pointAddSelect = true;
        coinAddSelect = false;
        pointsRef = PlayerPrefs.GetInt("pointsRef");
        pointsRef *= 3;
        currentPoint = PlayerPrefs.GetInt("currentPoint", currentPoint);
        currentPoint += pointsRef;
        
        PlayerPrefs.SetInt("currentPoint", currentPoint);
     
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
    public void AddCoinsThruAd()
    {
        pointAddSelect = false;
        coinAddSelect = true;
         coinsRef = PlayerPrefs.GetInt("coinsRef");
        coinsRef *= 3;
        currentCoin = PlayerPrefs.GetInt("currentCoin", currentCoin);
        currentCoin += coinsRef;
        PlayerPrefs.SetInt("currentCoin", currentCoin);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    public void AddDiamondsInGift()
    {
      
        Debug.Log("Diamond Gift");
        currentCoin = PlayerPrefs.GetInt("currentCoin", currentCoin);
        currentCoin += 25;
        PlayerPrefs.SetInt("currentCoin", currentCoin);
        PlayerPrefs.Save();
    }

    public void AddPointsInGift()
    {
        Debug.Log("Points Gift");
        currentPoint = PlayerPrefs.GetInt("currentPoint", currentPoint);
        currentPoint += 25;

        PlayerPrefs.SetInt("currentPoint", currentPoint);

        PlayerPrefs.Save();
    }

    public void CharacterChoose()
    {
        //For loop for picking the character
        for (int i = 0; i < player.Length; i++)
        {
            if (i == characterChoose)
            {
                GameObject playerRef = Instantiate(player[i], Vector3.zero, Quaternion.identity);
                break;
            }
        }
    }

    public void ReplayChallenge()
    {
        levelManager.GenerateLevel();
       
        for (int i = 0; i <  levelManager.levels.Length; i++)
        {
            levelName[i].text = levelManager.levelobj[i].levelNumber;
            levelCost[i].text = levelManager.levelobj[i].pointsCost.ToString();
            levelManager.levels[i].SetActive(false);
                if (levelManager.levelobj[i].isUnlock)
                {
                //   challenges[i].transform.GetComponent<Image>().sprite = levelImage[i];
                levelImage[i].SetActive(true);
            
             //   checkers[i].transform.GetComponent<Image>().sprite = checkMark;
         
                }
                else
                {
                challenges[i].transform.GetComponent<Image>().sprite = lockedImage;
              //  checkers[i].transform.GetComponent<Image>().sprite = crossMark;
                levelImage[i].SetActive(false);

            }
         
            
        }
    }
    public void ReplayButton(int levelIndex)
    {

        for (int i = 0; i < levelManager.levels.Length; i++)
        {
          
            if (levelManager.levelobj[i].isUnlock)
            {
                if (i == levelIndex)
                {
                    if(currentPoint > levelManager.levelobj[i].pointsCost)
                    {
                        currentPoint = PlayerPrefs.GetInt("currentPoint", currentPoint);
                        currentPoint -= levelManager.levelobj[i].pointsCost;
                        PlayerPrefs.SetInt("currentPoint", currentPoint);
                        PlayerPrefs.Save();

                        Debug.Log(currentPoint);
                        if (uIManager.adCounter != 1)
                        {
                            adManager.playInterstitialAd();
                        }
                    }

                   // checkers[i].transform.GetComponent<Image>().sprite = checkMark;
        
                   
                }

                
                levelManager.SpecialLevel(levelIndex);
              
                uIManager.StartGame();
            }
         }  
          
       
        
            
    }


    private void OnApplicationQuit()
    {
        pointsRef = 0;
        coinsRef = 0;
        PlayerPrefs.SetInt("pointsRef", pointsRef);
        PlayerPrefs.SetInt("coinRef", pointsRef);
        PlayerPrefs.Save();
    }

    
}

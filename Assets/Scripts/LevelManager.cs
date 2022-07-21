using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public Levels[] levelobj;
    //public float[] highScore;
    public int gameRounds;
    public int RandChance;
    public int specialRandChance;
    public float desiredScore;
    public float score;
    public GameManager gameManager;
    public SkinChanger skinChanger;
    public GameObject player;
    public GameObject completeChallengePrompt, characterOpenUI, progressUI;
    public GameObject[] patternUI;
    public GameObject firstLevel, levelText;
    public int levelNumber;
    public Text levelDesiredText;
    public bool isLevelOn, isOpenOnce;
    public ProgressBar progressBar;
    public int currentPoint;
    // Start is called before the first frame update


    void Start()
    {

        RandChance = Random.Range(1, 100);
        gameRounds = PlayerPrefs.GetInt("gameRounds");
        currentPoint = PlayerPrefs.GetInt("currentPoint", currentPoint);
        //if (gameRounds % 5 == 0 && RandChance > 50)
        //{
        //    //Generate Special Level
        //    SpecialLevel();

        //}
        //else
        //{
        //    GenerateLevel();

        //}

    }

    private void Update()
    {
        score = gameManager.score;

        if (player.transform.position.y < -4f)
        {
            if (isLevelOn)
            {
                if (score > desiredScore)
                {
                    //if (!isOpenOnce)
                    //{
                    //    CharacterOn();
                    //}


                }
                else
                {
                    isLevelOn = false;
                }
            }
            else
            {
               // progressUI.SetActive(true);
            }
        }
      
    }


    public void GenerateLevel()
    {
        levels[0].SetActive(true);
        for (int i = 1; i < levels.Length; i++)
        { 
            levels[i].SetActive(false);
        }
        levelNumber = 0;
        PlayerPrefs.SetInt("levelNumber", levelNumber);
        PlayerPrefs.Save();

    }
    public void SpecialLevel(int levelIndex)
    {
        isLevelOn = true;
        levels[0].SetActive(true);
        levelText.SetActive(true);
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
            if (i == levelIndex)
            {


                levelobj[levelIndex].isUnlock = true;
                desiredScore = levelobj[levelIndex].desiredScore;
                levelDesiredText.text = desiredScore.ToString();
              
                int RandomChance = Random.Range(0, patternUI.Length);
                patternUI[RandomChance].SetActive(true);
                StartCoroutine(FadeTheDesiredScore());

            }

        }
      

    }

    public IEnumerator FadeTheDesiredScore()
    {
        Tween mytween = levelDesiredText.DOFade(0f, 10f);
        yield return mytween.WaitForCompletion();
    }

    public void CharacterOn()
    {
        isOpenOnce = true;
        int characterRange = Random.Range(0, 7);
        progressUI.SetActive(true);
   
        skinChanger.BuyCharacter(characterRange);
        Debug.Log(characterRange);
        progressBar.rewardSprite.GetComponent<Image>().sprite = skinChanger.characters[characterRange].characterImage;
        StartCoroutine(progressBar.OpenCharacterAnimation());

    }
}

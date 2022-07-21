using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class RewardManager : MonoBehaviour
{
    public Rewards[] rewards;
    public GameObject[] cursorRef;
    public int currentPoint;
    public int currentCoin;
    public int randNum;
    public float xDistance;
    public GameObject[] images;
    public int counter;
    public float duration;
    public int cursorIndex;
    public SkinChanger skinChanger;
    private Rewards rewardRef;
    public GameObject fillbar;
    public GameObject bar;
    public GameObject retryButton;
    public float time;
    public GameObject rewardPrompt;
    public Text textPrompt;
    public int adCounter;
    public AdManager adManager;
    public GameObject rollAgainButton;
    public GameObject noAdsButton;
    public Image rewardImage;
    public int referenceCursor = 1;
    public RectTransform promptTransform;
    // Start is called before the first frame update
    void Start()
    {
        currentCoin = PlayerPrefs.GetInt("currentCoin");
        currentPoint = PlayerPrefs.GetInt("currentPoint");


        adCounter = PlayerPrefs.GetInt("adCounter");
 
        if(adCounter == 1)
        {
            rollAgainButton.SetActive(false);
        }
    }



    public void StartAnimation()
    {
        
        ShuffleOrder();
        StartCoroutine(autoMoveCursorRef());
    }


    public void ShuffleOrder()
    {
        for (int i = 0; i < rewards.Length; i++)
        {
            //int randNum = Random.Range(0, rewards.Length);
            //rewardRef = rewards[randNum];
            //rewards[randNum] = rewards[i];
            //rewards[i] = rewardRef;
            images[i].transform.GetComponent<Image>().sprite = rewards[i].Image;
        }
    }



    public void unlockRewards(int indexRef)
    {
        //Randomize the rewards and its placement

        if (rewards[indexRef].rewardType == Rewards.RewardType.CoinReward)
        {
            currentCoin += rewards[indexRef].coins;

            PlayerPrefs.SetInt("currentCoin", currentCoin);
            PlayerPrefs.Save();

            textPrompt.text = " " + rewards[indexRef].coins;
            rewardImage.transform.GetComponent<Image>().sprite = rewards[indexRef].Image;

        }
        else if (rewards[indexRef].rewardType == Rewards.RewardType.PointReward)
        {
            currentPoint += rewards[indexRef].points;

            PlayerPrefs.SetInt("currentPoint", currentPoint);
            PlayerPrefs.Save();
            textPrompt.text =  " " + rewards[indexRef].points;
         
            rewardImage.transform.GetComponent<Image>().sprite = rewards[indexRef].Image;
        }
        else if (rewards[indexRef].rewardType == Rewards.RewardType.CharacterReward)
        {
            //unlock character
            int RandomNumber = Random.Range(0, 7);

            while (skinChanger.characters[RandomNumber].hasBrought)
            {
                RandomNumber = Random.Range(0, 7);
            }

            if (!skinChanger.characters[RandomNumber].hasBrought)
            {
                skinChanger.BuyCharacter(RandomNumber);

            }
            textPrompt.text = "NEW CHARACTER!";
            rewardImage.transform.GetComponent<Image>().sprite = rewards[indexRef].Image;
        }
     
        rewardPrompt.SetActive(true);
        
         promptTransform = rewardPrompt.GetComponent<RectTransform>();
        promptTransform.DOScale(new Vector3(3.3f, 2.5f, 0), 1f);



    }

    public void retryUnlockRewards()
    {
        randNum = Random.Range(0, rewards.Length);
        counter++;
    }

    //public void movecursor()
    //{
    //    retryUnlockRewards();
    //}

    //public void moveCursorRef()
    //{
    //    //  LeanTween.moveLocalX(cursorRef, cursorRef.transform.position.x + xDistance, 1f);

    //    for (int i = 0; i < rewards.Length; i++)
    //    {
    //        if (i == counter)
    //        {
    //            cursorRef[i].SetActive(true);
    //        }
    //        else
    //        {
    //            cursorRef[i].SetActive(false);
    //        }

    //    }

    //    if (counter == 4)
    //    {
    //        counter = 0;
    //    }
    //    else
    //    {
    //        counter = counter + 1;
    //    }

    //}

    public IEnumerator autoMoveCursorRef()
    {
        // randNum = Random.Range(5, 10);

        for (int i = 0; i != randNum; i++)
        {

            if (cursorIndex >= 4)
            {
                cursorIndex = 0;

            }

            if (cursorIndex == 0)
            {
                cursorRef[0].SetActive(true);
                cursorRef[cursorRef.Length - 1].SetActive(false);

            }

            else
            {
                cursorRef[cursorIndex - 1].SetActive(false);
                cursorRef[cursorIndex].SetActive(true);
            }
            
            cursorIndex++;
            yield return new WaitForSeconds(duration);

        }
        cursorIndex -= 1;
     
        unlockRewards(cursorIndex);
        StartCoroutine(barAnimation());
    }

    IEnumerator barAnimation()
    {
        LeanTween.scaleX(fillbar, 1.0375f, time).setOnComplete(AppearButton);
        yield return new WaitForSeconds(time);

    }

    public void AppearButton()
    {
        LeanTween.scale(retryButton, new Vector3(0.6866003f, 1.168775f, 2.83312f), 0.7f);
        LeanTween.scale(rollAgainButton, new Vector3(1.1f, 2.0f, 1f), 0.7f);
        LeanTween.scale(noAdsButton, new Vector3(1.1f, 2.0f, 1f), 0.7f);
        rewardPrompt.SetActive(true);
    }


    public void retryRoll()
    {
        rewardPrompt.SetActive(false);
        promptTransform.DOScale(new Vector3(0, 0, 0), 1f);
        rollAgainButton.SetActive(false);
        noAdsButton.SetActive(false);
        StartAnimation();
        

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class ProgressBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Text percentText;
    public RectTransform gift, percentTransform, promptTransform, retryButton;
    public int progressGift;
    public int incrementValue;
    public UIManager uIManager;
    public Sprite giftOpen;
    public GameObject rewardSprite;

    public GameObject giftObj;
    
    void Start()
    {
        progressGift = PlayerPrefs.GetInt("progressGift");

        Debug.Log(progressGift);
    
       
      
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public IEnumerator GiftAnimation()
    {
      
        percentText.text = progressGift.ToString() + "%";
        Sequence sequence = DOTween.Sequence();
        //Tween myTween = scoreBoard.DOAnchorPosX(0, 1f);

        //sequence.Append(gift.DOAnchorPos(new Vector3(-31, 30, 0), 1f))
        //        .Append(gift.DORotate(new Vector3(0, 0, 18), 1))
        //        .Append(gift.DOAnchorPos(new Vector3(34, 11, 0), 1f))
        //        .Append(gift.DORotate(new Vector3(0, 0, -15), 1))
        //        .Append(gift.DORotate(new Vector3(0, 0, 0), 1))
        //        .Append(gift.DOAnchorPos(new Vector3(10, 11, 0), 1f))
        //sequence.Append(gift.DOShakeRotation(1, 35, 90, 180f, true)).WaitForCompletion();
        Tween myTween = gift.DOShakeRotation(1, 35, 90, 180f, true);
        // StartCoroutine(TextAnimation());
        DisplayTexxt();
        yield return myTween.WaitForCompletion();

        //progressGift += 5;
        //percentText.text = progressGift.ToString() + "%";

        //  sequence.Append(gift.DOScale(1, 35, 90, 180f, true)).WaitForCompletion();
        myTween = percentTransform.DOScale(0, 0.1f);
        myTween = gift.DOScale(0, 0.1f).OnComplete(ForReviving);
        yield return myTween.WaitForCompletion();


        //Tween myTween = gift.DOAnchorPosX(-31, 1f);
        //yield return myTween.WaitForCompletion();


    }

    public IEnumerator OpenCharacterAnimation()
    {
        percentText.text = "";
        Tween myTween = gift.DOShakeRotation(1, 35, 90, 180f, true);

        yield return myTween.WaitForCompletion();

        myTween = gift.DOJumpAnchorPos(new Vector2(10f, 30f), 90f, 1, 0.5f, true);
        gift.transform.GetComponent<Image>().sprite = giftOpen;


        yield return myTween.WaitForCompletion();

        myTween = promptTransform.DOScale(new Vector3(3.3f, 2.4f, 1), 1f);
        yield return myTween.WaitForCompletion();
        myTween = retryButton.DOScale(new Vector3(1.0f, 1.0f, 0), 1f);
        yield return myTween.WaitForCompletion();

        //LeanTween.scale(gift, new Vector3(0.5074842f, 0.07538906f, 0.3383228f), 0.7f).setEase(LeanTweenType.easeInElastic);
        //yield return new WaitForSeconds(1f);
        //LeanTween.scale(gift, new Vector3(0.355314f, 0.3383228f, 0.3383228f), 0.7f).setEase(LeanTweenType.easeOutElastic);
        //gift.GetComponent<Image>().sprite = giftOpen;
     //   yield return new WaitForSeconds(1f);
    }



    IEnumerator TextAnimation()
    {
        while (true)
        {
            if (progressGift % 5 != 0)
            {
                progressGift++;
                percentText.text = progressGift.ToString() + "%";
              
            }
            yield return new WaitForSeconds(incrementValue);

        }

    }

    public void DisplayTexxt()
    {
        progressGift += 50;
        percentText.text = progressGift.ToString() + "%";
    }

    public void ForReviving()
    {
        uIManager.ReviveUI();
    }
    
}

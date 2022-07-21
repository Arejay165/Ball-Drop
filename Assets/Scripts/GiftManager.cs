using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GiftManager : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject claimRewardButton;
    public GameObject fillbar;
    public float time;
    public GameObject gift;
    public Sprite openGift;
    public Sprite closedGift;
    public UIManager uiManager;
    public AdManager adManager;
    public GameManager gameManager;
    public GameObject bar;
    public Vector3 originalSize;
    public Button claimRewardBut;
    public GameObject noAdsButton;
    public RectTransform rewardPrompt;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator barAnimation()
    {
        LeanTween.scaleX(fillbar, 1.0375f, time).setOnComplete(AppearButton);
        yield return new WaitForSeconds(time);
    }

    public void AppearButton()
    {
        LeanTween.scale(retryButton, new Vector3(0.2238479f, 0.2390909f, 2.83312f), 0.7f);
    }

    public void StartAnimation()
    {
        StartCoroutine(giftAnimation());

    }

    public IEnumerator giftAnimation()
    {

     
       
        LeanTween.scaleX(fillbar, 1.0375f, 4f).setOnComplete(AppearButton);
        yield return new WaitForSeconds(4f);
        LeanTween.scale(gift, new Vector3(0.5074842f, 0.07538906f, 0.3383228f), 0.7f).setEase(LeanTweenType.easeInElastic);
        yield return new WaitForSeconds(time);
        LeanTween.scale(gift, originalSize, 0.7f).setEase(LeanTweenType.easeOutElastic);
        gift.GetComponent<Image>().sprite = openGift;
        yield return new WaitForSeconds(time);
        if (uiManager.adCounter != 1)
        {
            adManager.PlayRewardedVideoAd();
        }
        bar.SetActive(false);
 
        Tween myTween = rewardPrompt.DOAnchorPosY(137, 0.7f);
        yield return myTween.WaitForCompletion();
         myTween = rewardPrompt.DOScale(new Vector3(2.7f, 1.8f, 1), 0.7f).SetEase(Ease.InBounce); 
        yield return myTween.WaitForCompletion();
        
       // rewards();
    }

    public void rewards()
    {
        gameManager.AddDiamondsInGift();
        gameManager.AddPointsInGift();
        uiManager.loadlevel(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ReviveUITransitionPrompt : MonoBehaviour
{
    public RectTransform scoreBoard, backToMainMenu, adButton, noAdsButton;
    public RectTransform fillbar;

    public GameObject promptforAd;
  //  public GameObject fillbar;
    public float time;
    public GameObject bar;
    public int adCounter;
    private void Start()
    {
        adCounter = PlayerPrefs.GetInt("adCounter");
        if(adCounter == 1)
        {
       
            promptforAd.transform.GetComponent<Image>().color = new Color(promptforAd.transform.GetComponent<Image>().color.r, promptforAd.transform.GetComponent<Image>().color.g, promptforAd.transform.GetComponent<Image>().color.b, 0f);
        }

    }

    public IEnumerator deathAnimation()
    {

        Tween myTween = scoreBoard.DOAnchorPosX(0, 1f);

        yield return myTween.WaitForCompletion();
       
        myTween = adButton.DOAnchorPosX(-15, 1f);
   
        yield return myTween.WaitForCompletion();
   
        myTween = fillbar.DOScaleX(1.0125f, time).OnComplete(AppearButton);
    
        yield return myTween.WaitForCompletion();
      
    }

    public void AppearButton()
    {
   
        Tween myTween = backToMainMenu.DOScale(new Vector3(1, 1.6136f, 1), 0.5f);
     
    }


    public void StartAnimation()
    {
        StartCoroutine(deathAnimation());
    }
}

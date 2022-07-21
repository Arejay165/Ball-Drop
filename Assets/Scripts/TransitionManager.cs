using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TransitionManager : MonoBehaviour
{
   
    public float transitionTime;
    public Vector3 desiredSize;

    // Start is called before the first frame update
    void Start()
    {
     
      
        StartCoroutine(StartAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void displayMenu()
    {
        SceneManager.LoadScene(1);
        gameObject.SetActive(false);
    }

    IEnumerator StartAnim()
    {
        //LeanTween.scale(gameObject, desiredSize, 0.5f);
        //yield return new WaitForSeconds(transitionTime);
        //mainMenuUI.SetActive(true);
        //gameObject.SetActive(false);

        //  Tween mytween = gameObject.transform.DOScale(desiredSize,transitionTime).OnComplete(displayMenu);
        Tween mytween = gameObject.transform.GetComponent<Image>().DOFade(0, transitionTime).OnComplete(displayMenu).SetEase(Ease.OutBack);
        yield return mytween.WaitForCompletion();


    }

  
}

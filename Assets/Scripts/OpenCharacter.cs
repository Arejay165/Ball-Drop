using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class OpenCharacter : MonoBehaviour
{
    public RectTransform gift;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpenCharacterAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OpenCharacterAnimation()
    {
    
        Tween myTween = gift.DOShakeRotation(1, 35, 90, 180f, true);

        yield return myTween.WaitForCompletion();

        myTween = gift.DOScale(0, 0.1f);

        yield return myTween.WaitForCompletion();

      //  SceneManager.LoadScene(0);

    }
}

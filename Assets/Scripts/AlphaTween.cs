using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaTween : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.alphaText(gameObject.GetComponent<RectTransform>(), 1f, 0.5f).setEase(LeanTweenType.easeInCirc);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

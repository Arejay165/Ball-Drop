using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    public Vector3 desiredSize;
    public float Time;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(gameObject, desiredSize, Time).setEase(LeanTweenType.easeInCirc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

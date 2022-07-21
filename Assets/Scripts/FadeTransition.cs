using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FadeTransition : MonoBehaviour
{
    public Text companyName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fade()
    {
        companyName.text = "Auturgist";
        GetComponent<MeshRenderer>().material.DOFade(0.0f, 0.5f);
    }
}

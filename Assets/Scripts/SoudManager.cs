using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoudManager : MonoBehaviour
{
    public AudioClip bounceSfx;
    public AudioSource audioSource;
    public AudioClip clickOnSfx;
    public AudioClip clickOffSfx;
    public AudioClip diamondSfx;
    public AudioClip pointSfx;
    public AudioClip congratsSfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    public void ClickOnSfx()
    {
        audioSource.PlayOneShot(clickOnSfx);
    }
    public void ClickOffSfx()
    {
        audioSource.PlayOneShot(clickOffSfx);
    }
    public void BounceSfx()
    {
        audioSource.PlayOneShot(bounceSfx);
    }

    public void DiamondSfx()
    {
        audioSource.PlayOneShot(diamondSfx);
    }

    public void PointSfx()
    {
        audioSource.PlayOneShot(pointSfx);
    }

    public void CongratsOnSfx()
    {
        audioSource.PlayOneShot(congratsSfx);
    }
}

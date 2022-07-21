using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpManager : MonoBehaviour
{
    public int currentPoint;
    public Slider[] slides;
    public float targerProgress;
    public Character[] characters;
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = PlayerPrefs.GetInt("currentPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillBar(float newProgress)
    {
        currentPoint -= (int)newProgress;
       
    }
}

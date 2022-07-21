using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject currentGameObject;
    public Material currentMat;
    public float alpha = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAlpha(Material mat, float alphaValue)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaValue);
        mat.SetColor("_Color", newColor);
    }


}

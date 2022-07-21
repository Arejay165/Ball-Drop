using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockTrails : MonoBehaviour
{
    public Trails[] trail;
    public int currentPoint;
    public Text pointText;
    public TrailRenderer trailRef;
    public Sprite lockedImage;
    public GameObject[] trailImage;
    public int trailReference;
    public int trailNumber;
    public TrailRenderer playerTrail;
    public Sprite equipImage;
    public GameObject[] buyButtons;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("currentPoint", currentPoint);
        trailReference = PlayerPrefs.GetInt("trailNumber", trailNumber);
        selectTrailSkin(trailReference);
        WearTrailSkin();
        lockedTrails();
    }

   void lockedTrails()
    {
        for (int i = 0; i < trail.Length; i++)
        {
            if (!trail[i].isUnlock)
            {

                trailImage[i].transform.GetComponent<Image>().sprite = lockedImage;
            }
            else
            {

                buyButtons[i].transform.GetComponent<Image>().sprite = equipImage;
                trailImage[i].transform.GetComponent<Image>().sprite = lockedImage;
            }

        }
    }

    public void buyTrail(int trailIndex)
    {
        Trails selectedTrail = trail[trailIndex];

        if (!selectedTrail.isUnlock)
        {
            if (currentPoint > selectedTrail.amountOfPoints)
            {
                currentPoint -= selectedTrail.amountOfPoints;
                PlayerPrefs.SetInt("currentPoint", currentPoint);
                PlayerPrefs.Save();
                lockedTrails();
                selectedTrail.isUnlock = true;
            }
        }
        else
        {
            selectTrailSkin(trailIndex);
        }

    }
    public void selectTrailSkin(int trailIndex)
    {
        Trails selectedFloor = trail[trailIndex];
        trailNumber = trailIndex;
        if (selectedFloor.isUnlock)
        {
            for (int i = 0; i < trail.Length; i++)
            {
                if (trailIndex == i)
                {
                    trailRef.sharedMaterial = trail[i].material;
                    playerTrail.sharedMaterial = trail[i].material;
                    trail[i].isSelected = true;
                }
                else
                {
                    trail[i].isSelected = false;
                }

            }
            PlayerPrefs.SetInt("trailNumber", trailNumber);
            PlayerPrefs.Save();
        }

    }

    public void WearTrailSkin()
    {
        for(int i = 0; i < trail.Length; i++)
        {
            if (trail[i].isSelected)
            {
                trailRef.sharedMaterial = trail[i].material;
                playerTrail.sharedMaterial = trail[i].material;
            }
        }
    }

}

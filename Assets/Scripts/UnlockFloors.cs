using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class UnlockFloors : MonoBehaviour
{
    public Floor[] floors;
    public int currentCoin;
    public Text coinText;
    public Renderer floorRef;
    public Sprite lockedImage;
    public GameObject[] floorImage;
    public int floorNumber;
    public Renderer[] floorPrefab;
    public int floorReference;
    public Renderer[] floorObject;
    public Sprite equipImage;
    public GameObject[] buyButtons;
    // Start is called before the first frame update
    void Start()
    {
        currentCoin = PlayerPrefs.GetInt("currentCoin", currentCoin);
        floorReference = PlayerPrefs.GetInt("floorNumber", floorNumber);

        OnSkinSelect(floorReference);
        WearFloorSkin();
       

        lockedFloors();
    }

    private void Update()
    {

    }

    public void EquipFloorSkins()
    {
        
        for(int i = 0; i < floorObject.Length; i++)
        {
           floorObject[i].sharedMaterial  = floors[floorNumber].material;
        }
        WearFloorSkin();

    
    }


    public void OnSkinSelect(int floorIndex)
    {
        Floor selectedFloor = floors[floorIndex];
        floorNumber = floorIndex;
      
       for (int i = 0; i < floors.Length; i++)
       {
         if (i == floorIndex)
          {
                floorRef.sharedMaterial = floors[i].material;
          }
       }
        PlayerPrefs.SetInt("floorNumber", floorNumber);
        PlayerPrefs.Save();   
    }
    public void WearFloorSkin()
    {
        for (int i = 0; i < floorPrefab.Length; i++)
        {

            floorPrefab[i].sharedMaterial = floors[floorNumber].material;
      
        }
 


    }

    public void lockedFloors()
    {
        for (int i = 0; i < floors.Length; i++)
        {
            if (!floors[i].isUnlock)
            {
                floorImage[i].transform.GetComponent<Image>().sprite = lockedImage;
            }
            else
            {
                buyButtons[i].transform.GetComponent<Image>().sprite = equipImage;
                floorImage[i].transform.GetComponent<Image>().sprite = lockedImage;
            }

        }
    }

    
    public void buyFloor(int floorIndex)
    {
        Floor selectedFloor = floors[floorIndex];
        
        if (!selectedFloor.isUnlock)
        {
            if (currentCoin > selectedFloor.amountOfCoin)
            {
                currentCoin -= selectedFloor.amountOfCoin;
                PlayerPrefs.SetInt("currentCoin", currentCoin);
                PlayerPrefs.Save();
                lockedFloors();
                selectedFloor.isUnlock = true;
            }
           
          
        }
        else
        {
           
            OnSkinSelect(floorIndex);
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockCharacters : MonoBehaviour
{
    public Sprite[] characterImages;
    public GameObject[] ShopItem;
    public Sprite lockedImage;
    public Character[] characters;
    public Sprite equipImage;
    public GameObject[] buyButtons;

    public int currentCoins;
    public int currentPoints;
    // Start is called before the first frame update
    void Start()
    {
        // ShopItem = new GameObject[characterImages.Length];
        currentCoins = PlayerPrefs.GetInt("currentCoin");
        currentPoints = PlayerPrefs.GetInt("currentCoin");
        lockedCharacters();
    }

    
    public void unlockCharacter(int characterIndex)
    {
        for(int i = 0; i < characterImages.Length -1 ; i++)
        {
            if(i == characterIndex)
            {
                //ShopItem[i] = transform.GetChild(i).gameObject;
                ShopItem[i].transform.GetComponent<Image>().sprite = characterImages[i];
            }
        }
        
    }

    public void lockedCharacters()
    {
        
       for(int i = 0; i < characterImages.Length -1 ; i++)
        {
            if (!characters[i].hasBrought)
            {
                // ShopItem[i] = transform.GetChild(i).gameObject;
                Debug.Log("Stuff");
                ShopItem[i].transform.GetComponent<Image>().sprite = lockedImage;
            }
            else
            {
                ShopItem[i].transform.GetComponent<Image>().sprite = lockedImage;
                buyButtons[i].transform.GetComponent<Image>().sprite = equipImage;
            }
           
               
        }
    }
   
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinChanger : MonoBehaviour
{
    public Renderer rend;
    public Material[] mats;
    public Character[] characters;
    public int characterNumber;
    public int currentCoin;
    public int currentPoint;
    public Text pointText;
    public Text coinText;
    public Renderer refRend;
    public UnlockCharacters unlock;
    //public Slider[] slides;
    public float fillSpeed = 1.0f;
    public int slideRef;
    public bool isClick;
    public UIManager uIManager;
    public int characterReference;

 //   public GameObject slideManager;

 
    void Start()
    {
        //currentCoin = PlayerPrefs.GetInt("currentCoin");
        characterReference = PlayerPrefs.GetInt("characterNumber", characterNumber);
          WearSkin(characterReference);
       // EquipSkin();
        //lockedFillBars();
      
    }



    private void Update()
    {
        //if (isClick)
        //{
        //    StartCoroutine(AddSlider(slideRef));
        //}
        //  
    }

    public void EquipSkin()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].isSelected)
            {
                rend.sharedMaterial = mats[i];
                refRend.sharedMaterial = mats[i];
                characters[i].isSelected = true;
            }
            else
            {
                characters[i].isSelected = false;
            }
        }
    }

    public void WearSkin(int characterReference)
    {
        Character selectedCharacters = characters[characterReference];
        for (int i = 0; i < characters.Length; i++)
        {
            if(i == characterReference)
            {
                rend.sharedMaterial = mats[i];
                refRend.sharedMaterial = mats[i];
            }


        }

    }

    public void OnSkinSelect(int characterIndex)
    {
        Character selectedCharacters = characters[characterIndex];
        characterNumber = characterIndex;
        if (selectedCharacters.hasBrought == true)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (i == characterNumber)
                {
                    rend.sharedMaterial = mats[i];
                    refRend.sharedMaterial = mats[i];
                    selectedCharacters.isSelected = true;
                }
                else
                {
                    selectedCharacters.isSelected = false;
                }
            }

            PlayerPrefs.SetInt("characterNumber", characterNumber);
            PlayerPrefs.Save();
        }

    }


   

    public void BuyCharacter(int characterIndex)
    {


        Character selectedCharacters = characters[characterIndex];
        if (selectedCharacters.hasBrought == false)
        {
           
                unlock.unlockCharacter(characterIndex);
             
                selectedCharacters.hasBrought = true;
        
    
        }

    }

    public void FillBar(int characterIndex)
    {
        Character selectedCharacters = characters[characterIndex];
        if (selectedCharacters.hasBrought == false)
        {

            selectedCharacters.exp += currentPoint;

        
        }
    }


    //public void AddExp(int characterIndex)
    //{
    //    whoever the buttons
    //   Slider slider;


    //    for (int i = 0; i < slides.Length; i++)
    //    {
    //        if (characterIndex == i)
    //        {

    //            isClick = true;
    //        }
    //    }


    //    if (currentPoint > 0)
    //    {
    //        isClick = true;
    //    }
    //    else
    //    {
    //        isClick = false;
    //    }

    //}

    //public void lockedFillBars()
    //{
    //    for (int i = 0; i < slides.Length; i++)
    //    {

    //        slides[i].gameObject.SetActive(false);
    //    }
    //}

    public int characterIndexReference()
    {
        int characterIndex = 0;

        


        return characterIndex;
    }

    //public int SlideReference()
    //{
    //    int slideREf;
  
    //    for (int i = 0; i < slides.Length; i++)
    //    {
       
    //        slideREf = i;
    //    }
    //    slideREf = slideRef;

    //    return slideRef;
    //}

    //public IEnumerator AddSlider(int sliderRef)
    //{
    //    int slideTemp = SlideReference();
    //    Slider slide = slides[0];
    //    int slideChild = slideManager.transform.childCount;
    //    Character selectedCharacters = characters[0];

    //    //for (int i = 0; i < slides.Length; i++)
    //    //{
    //    //    if (slideRef == slideChild)
    //    //    {

    //    //        slideRef = i;
    //    //        slide = slides[i];
    //    //        selectedCharacters = characters[i];
    //    //        break;
    //    //    }



    //    //}

    //  if(currentPoint > 0)
    //    {
    //        if (slide.value != 1)
    //        {
    //            currentPoint -= 1;
    //            slide.value += fillSpeed * Time.deltaTime;
    //            uIManager.DisplayShopCoinandPoint();
    //            PlayerPrefs.SetInt("currentPoint", currentPoint);


    //            PlayerPrefs.Save();

    //        }
    //        else
    //        {
    //            selectedCharacters.hasBrought = true;
    //            isClick = false;
    //        }

    //    }

    //    uIManager.DisplayShopCoinandPoint();
    //        yield return null;
        
    //}

    //bool isClickable()
    //{
     
    //    //Character selectedCharacters = characters[0];
       
    //    if (currentPoint != 0)
    //    {
    //        return isClick = false;
    //    }
    //    else 
    //    {
    //        return isClick = true;
    //    }

    

    //}
}

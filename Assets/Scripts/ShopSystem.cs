using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public Character[] characters;
    public int characterNumber;
    public int currentCoin;
    public int currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentCoin = PlayerPrefs.GetInt("currentCoin");
        currentPoint = PlayerPrefs.GetInt("currentPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyCharacter(int characterIndex)
    {
        Character selectedCharacters = characters[characterIndex];

        if (currentCoin > selectedCharacters.inGamecost)
        {
            currentCoin -= selectedCharacters.inGamecost;
            PlayerPrefs.SetInt("currentCoin", currentCoin);
            PlayerPrefs.Save();
            ///Buy the character
        }
        else
        {
            Debug.Log("Not enough money");
        }

    }
    public void onCharacterSelect(int characterIndex)
    {

        Character selectedCharacters = characters[characterIndex];
        characterNumber = characterIndex;

        PlayerPrefs.SetInt("characterNumber", characterNumber);
        PlayerPrefs.Save();
        Debug.Log("You've choosen" + selectedCharacters.name);

    }
}

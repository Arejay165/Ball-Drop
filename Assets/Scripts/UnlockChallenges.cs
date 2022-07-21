using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockChallenges : MonoBehaviour
{
    // public Sprite[] openImages;
    //public LevelManager levelManager;
    //public Levels[] levels;
    //public Sprite lockedImage;
    //GameObject[] challengeList;

    //public GameObject[] levelImage;
    //public Text levelName;
    //public Text levelCost;
    // Start is called before the first frame update
    void Start()
    {
       // challengeList = new GameObject[levelImage.Length];
       // lockedChallenges();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //public void openChallenges()
    //{
    //    for(int i = 0; i < openImages.Length; i++)
    //    {
    //        if (levels[i].isUnlock)
    //        {
    //            challengeList[i] = transform.GetChild(i).gameObject;
    //            challengeList[i].transform.GetComponent<Image>().sprite = openImages[i];

    //        }
    //    }
    //}

    //public void lockedChallenges()
    //{
    //    for (int i = 0; i < levelImage.Length; i++)
    //    {

    //        if (!levels[i].isUnlock)
    //        {
    //            challengeList[i] = transform.GetChild(i).gameObject;
    //            challengeList[i].transform.GetComponent<Image>().sprite = lockedImage;
    //        }
    //        else
    //        {
    //            challengeList[i] = transform.GetChild(i).gameObject;
    //            //  challengeList[i].transform.GetComponent<Image>().sprite = levelImage[i];
    //            levelImage[i].SetActive(true);
    //        }
    //    }
    //}
}

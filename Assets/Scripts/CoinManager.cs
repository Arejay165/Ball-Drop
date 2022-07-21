using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text coinText;
    [SerializeField] GameObject animatedCoinPrefab;
    [SerializeField] Transform target;


    [SerializeField] int maxCoin;

    Queue<GameObject> coinQueqe = new Queue<GameObject>();

    [SerializeField] [Range(0.5f, 0.9f)] float minAnimTime;
    [SerializeField] [Range(0.5f, 2.0f)] float maxAnimTime;

    Vector3 targetPos;

    //Assumingly the playerprefs coin
    private int currentCoins;

    [SerializeField] Ease easeType;

    public Transform spawnPoint;
    private int _c = 0;

    //public int Coins
    //{
    //    get { return _c; }
    //    set
    //    {
    //        _c = value;
    //        // The changing of amount
    //        coinText.text = Coins.ToString();
    //    }
    //}



    private void Awake()
    {
        // Target refers to the destination of the coins
        targetPos = target.position;
        currentCoins = PlayerPrefs.GetInt("currentCoin", currentCoins);
        PrepareCoins();
      
    }

    private void Start()
    {
        // Tried doing it in the start muna bago ko iapply sa ibang objects
        AddCoins(spawnPoint.transform.position, 7);
    }

    void PrepareCoins()
    {
        //Instantiating coins
        GameObject coin;
        for (int i = 0; i < maxCoin; i++)
        {
            coin = Instantiate(animatedCoinPrefab);
            coin.transform.parent = transform;
            coin.SetActive(false);
            coinQueqe.Enqueue(coin);
        }

    }
    // Whole bulk of the code
    void Animate(Vector3 collectedCoinPosition, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            if(coinQueqe.Count > 0)
            {
                GameObject coin = coinQueqe.Dequeue();
                coin.SetActive(true);

                coin.transform.position = collectedCoinPosition;

                float duration = Random.Range(minAnimTime, maxAnimTime);
                coin.transform.DOMove(targetPos, duration)
                .SetEase(easeType)
                .OnComplete(() => {
                    //executes whenever coin reach target position
                    //Coins++;
                    coin.SetActive(false);
                    coinQueqe.Enqueue(coin);

          
                    coinText.text = PlayerPrefs.GetInt("currentCoin").ToString();

                    currentCoins++;

                    PlayerPrefs.SetInt("currentCoin", currentCoins);
                    PlayerPrefs.Save();
                });
            }
        }
    }
    // Initialization
    public void AddCoins(Vector3 collectedCoinPosition,int amount)
    {
        Animate(collectedCoinPosition, amount);
    }
}

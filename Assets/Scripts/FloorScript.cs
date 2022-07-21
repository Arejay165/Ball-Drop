using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FloorScript : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform spawnPoint;
    public int randomNum;
    public bool respawn;
    public bool canMoveUp;
    public bool canMoveDown;
    public float minuend;
    public float desiredScore;
    public GameObject highscorePrompt;
    public float currentScore;
    public float highScore;
    public Transform playerTransform;
    public Text scoreText;
    public GameManager gameManager;
    public float speed;
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        SpawnDiamonds();
         
        //  gameManager.SpawnCatcher();
    }

    // Update is called once per frame
    void Update()
    {

        if (canMoveUp)
        {
           
        
         //   transform.position += Vector3.forward * Time.deltaTime * speed;
           
        }
        if (canMoveDown)
        {
          //  transform.position -= Vector3.forward * Time.deltaTime * speed;
        }
       
        
    }

    private void OnCollisionEnter(Collision collision)
    {

      
        
        if (collision.gameObject.tag == "Player")
        {
          

            Destroy(gameObject);
        }
     
        if(collision.gameObject.tag == "Ground")
        {
            if (canMoveUp)
            {

                canMoveDown = true;
                canMoveUp = false;
            }
            if (canMoveDown)
            {
                canMoveUp = true;
                canMoveDown = false;

            }
        }
      

    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    void SpawnDiamonds()
    {
    
        randomNum = Random.Range(0, 5);
        if(currentScore > highScore)
        {
             go = Instantiate(highscorePrompt, spawnPoint.position, Quaternion.identity) as GameObject;
            
        }
        else
        {
            go = Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
            go.transform.Rotate(0, 0, 180f);
            go.transform.SetParent(gameObject.transform);
        }
     
    }
 
}



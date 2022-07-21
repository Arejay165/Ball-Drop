using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMovement : MonoBehaviour
{
    public Rigidbody rb2d;
    public float speed;
    public float forwardSpeed;
    public float adden;
    public LayerMask coinLayer;
    public GameManager gameManager;
    public UIManager uIManager;
    public GameObject tileManager;
    public SoudManager soudManager;
    public CameraShake cameraShake;
    public bool OnAir;
    public LayerMask ground;
    public LayerMask point;
    public float stopAdden;
    public GameObject deathBox;
    public LayerMask boxCollider;
   
    public float maxSpeed;
    public ProgressBar progressBar;
    public LevelManager levelManager;
   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        // Movement Thingy

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnAir)
            {
                stop();
            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (OnAir)
            {
                stop();
            }
         
        }
       

    }

    private void FixedUpdate()
    {
        if(rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = Vector3.ClampMagnitude(rb2d.velocity, maxSpeed);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (uIManager.isVibrate == true)
        //{
        //    Handheld.Vibrate();
        //}
        movement();
        

        speed += adden * Time.deltaTime;
        forwardSpeed += adden * Time.deltaTime;
        stopAdden += adden * Time.deltaTime;

        if ((boxCollider.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            Death();
        }
    }


   public void Death()
    {

  
        rb2d.constraints = RigidbodyConstraints.FreezeAll;

        if (!levelManager.isLevelOn)
        {
            StartCoroutine(progressBar.GiftAnimation());
            gameManager.SetHigherScore();
            gameManager.StartDisplayCurrency();
           //  gameManager.AdsDisplayPoint();
        }
    


    }

    void movement()
    {
        rb2d.AddForce(0, 10, forwardSpeed * Time.deltaTime, ForceMode.Impulse);
        soudManager.BounceSfx();
        OnAir = true;
    }

    void stop()
    {
       
        rb2d.AddForce(0, -stopAdden, 0, ForceMode.Impulse);
        OnAir = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((coinLayer.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer) 
        {
            gameManager.SetCoins(1);
            soudManager.DiamondSfx();
        }

        if ((point.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            gameManager.SetPoints(1);
          

        }
    }

   
}

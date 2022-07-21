using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb2d;
    public GameObject parabolaRoot;
    public LayerMask coinLayer;
    public LayerMask pointsLayer;
    public GameManager gameManager;
    public UIManager uIManager;
    public GameObject tileManager;
    public CameraFollow cameraFollow;
    public float speed;
 
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       

        if (Input.GetKeyDown(KeyCode.Space))
            StopMovement();


        if (transform.position.y < -8)
        {
            Time.timeScale = 0;
            uIManager.ReviveUI();


        }
      
        if (transform.position.z > 50f)
        {
            Debug.Log("transform.position.z");
            cameraFollow.ChangeCamColor();
        }

    }
    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (uIManager.isVibrate)
        //{
        //    Handheld.Vibrate();
        //}
    
        UpdateParabolaPosition();
        MovementFunction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((coinLayer.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            gameManager.SetCoins(1);
        }
        if ((pointsLayer.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            gameManager.SetPoints(1);
        }

    }
    void UpdateParabolaPosition()
    {
        // parabolaRoot.transform.position += new Vector3(0, 0, 10f);
        parabolaRoot.transform.position = transform.position;
    }



    void MovementFunction()
    {
        GetComponent<ParabolaController>().FollowParabola();

    }

   public void StopMovement()
    {
        GetComponent<ParabolaController>().StopFollow();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // public Transform player;
    public Transform player;
    private Vector3 camOffset;

    [Range(0.01f, 1.0f)]
    public float smooth;

    public bool lookAtPlayer = false;

    public Color[] colors;
    int lastIndex = 0;
    float t = 0;
    int colorIndex = 0;
 
    [SerializeField] [Range(0,1f)] float lerpTime;
    private Rigidbody reference;

    public Transform playerCamRef;
    private void Start()
    {
        camOffset = transform.position - player.transform.position;
        reference = player.GetComponent<Rigidbody>();
        // reference.constraints = RigidbodyConstraints.FreezePositionZ;

         //   Camera.main.backgroundColor = colors[RandomColorIndex()];
        // InvokeRepeating("ChangeCamColor", 0.3f, 1f);
   
    }

    private void Update()
    {
        if ((reference.constraints & RigidbodyConstraints.FreezePositionZ) != RigidbodyConstraints.FreezePositionZ)
        {
            Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, colors[colorIndex], lerpTime * Time.deltaTime);

            ascendIndex();
        }

          
    }

    private void LateUpdate()
    {
        Vector3 newPos = player.position + camOffset;
     
        transform.position = Vector3.Slerp(transform.position, newPos, smooth);
        if (lookAtPlayer)
            transform.LookAt(player);
        if (player.position.y < -5f)
        {
            player = playerCamRef;
          
        }


    }


    public int RandomColorIndex()
    {
        if (colors.Length <= 1)
            return 0;
        int randIndex = lastIndex;
        while (randIndex == lastIndex)
        {
            randIndex = Random.Range(0, colors.Length);
        }
        lastIndex = randIndex;
        return randIndex;
    } 

    public void ascendIndex()
    {
         t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= colors.Length) ? 0 : colorIndex;
        }
      
    }
    public void ChangeCamColor()
    {

        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, colors[colorIndex], lerpTime * Time.deltaTime);
        ascendIndex();
       
    }
}

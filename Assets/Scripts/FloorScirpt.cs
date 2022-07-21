using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScirpt : MonoBehaviour
{
    public Rigidbody rb2d;
    public Vector3 adForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       }

    private void OnCollisionEnter(Collision collision)
    {
        rb2d.AddForce(adForce, ForceMode.Impulse);
    }
}

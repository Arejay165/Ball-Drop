using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceBounce : MonoBehaviour
{
    public Rigidbody rb2d;
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
        rb2d.AddForce(0, 7 , 0, ForceMode.Impulse);
    }
}

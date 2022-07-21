using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb2d;
    public float thrust;

    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpStop();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        JumpStop();
    }

    private void OnCollisionExit(Collision collision)
    {
        rb2d.AddForce(rb2d.velocity * thrust, ForceMode.Impulse);
    }

    void JumpStop()
    {
        rb2d.velocity = Vector3.zero;
    }
}

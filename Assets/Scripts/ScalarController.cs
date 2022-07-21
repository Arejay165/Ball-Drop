using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalarController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject parentRef;
    public float adden;

    void Start()
    {
        parentRef = transform.parent.gameObject;
    }

   

  

    private void OnTriggerEnter(Collider other)
    {
        parentRef.transform.localScale += new Vector3(adden, 0, adden);
    }

}

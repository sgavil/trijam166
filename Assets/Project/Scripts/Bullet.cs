using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject cachedObject;
    Rigidbody cachedRb;

    [SerializeField]
    float speed = 0.3f;


    // Start is called before the first frame update
    void Start()
    {

     cachedObject = this.gameObject;
     cachedRb = this.transform.GetComponentInChildren<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(cachedObject.activeInHierarchy){

             cachedRb.velocity = transform.forward * speed;
        }
        
    }
}

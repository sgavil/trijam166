using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject cachedObject;
    Rigidbody cachedRb;

    [SerializeField]
    float speed = 3f;

    private static BulletProperties baseProperties = new BulletProperties();

    private BulletProperties selfProperties;

    public static BulletProperties BaseProperties { get { return baseProperties; } }

    // Start is called before the first frame update
    void Start()
    {

        cachedObject = this.gameObject;
        cachedRb = this.transform.GetComponentInChildren<Rigidbody>();

    }

    private void generateProperties(){

        selfProperties = baseProperties.generateRandom();

    }

    public void activate(){

        generateProperties();

        CancelInvoke();
        Invoke("deactivate", 5);

    }

    public void deactivate(){

        cachedRb.velocity = Vector3.zero;
        cachedObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (cachedObject.activeInHierarchy)
        {

             cachedRb.velocity = transform.forward * speed;

        }

    }
}

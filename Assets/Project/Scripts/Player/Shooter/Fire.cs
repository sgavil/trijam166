using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    Pool bulletPool;

    Transform cachedTransform;
    
    [SerializeField]
    Transform shotOrigin;

    void Start()
    {
        bulletPool = Pool.Instance;
        cachedTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire(){

       var bullet = bulletPool.getFromPool();
        bullet.transform.forward = cachedTransform.forward;
        bullet.transform.position = shotOrigin.position;
        bullet.SetActive(true);

    }

}

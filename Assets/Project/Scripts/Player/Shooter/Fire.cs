using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    Pool bulletPool;

    Transform cachedTransform;
    
    [SerializeField]
    Transform shotOrigin;

    private int bulletsPerShot = 1;

    public int BulletsPerShot {get { return bulletsPerShot; } set { bulletsPerShot = value;}}

    void Start()
    {
        bulletPool = Pool.Instance;
        cachedTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shot(){

        var bullet = bulletPool.getFromPool();
        var bulletTranform = bullet.transform;
        bulletTranform.forward = cachedTransform.forward;
        bulletTranform.position = shotOrigin.position;
        bulletTranform.GetComponent<Bullet>().activate();
        bullet.SetActive(true);

    }

    public void fire(){

        var bullets = 0;

        while(bullets < bulletsPerShot){
            Invoke("shot", 0.2f * bullets);
            bullets++;
        }
    }

}

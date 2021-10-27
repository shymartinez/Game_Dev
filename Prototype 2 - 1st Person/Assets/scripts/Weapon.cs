using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool; 
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed; 

    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;
    
    void Awake ()
    {
        // Are we attached to player 
        if(GetComponent<PlayerController>())
        {
            isPlayer = true;
        }
    }
    // Can we shoot a buller 
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo> 0 || infiniteAmmo == true )
            {
                return true;
            }
        }
        return false;
    }
    public void Shoot ()
    {
        lastShootTime = Time.time;
        curAmmo --;
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;

        // Set velocity of bulletProjectile 
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;
    
    public gameObject hitParticle

    void OnEnable()
    {
        shootTime = Time.time;
    }
     // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //create particle effect 
        gameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 1.0f);

        // did we hit the target aka player
        if(other.CompareTag("Player"))
             other.GetComponent<PlayerController>().TakeDamage(damage);
        else 
            if(other.CompareTag("Enemy"))
                other.GetComponent<Enemy>().TakeDamage(damage);
        //disable bullet 
        gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
}

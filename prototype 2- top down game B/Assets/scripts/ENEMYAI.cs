using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 direction = player.position - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      rb.rotation =angle;
      direction.Normalize();
      movment = direction;
    }
     // Occurs at a fixed rate per frame 
     void FixedUpdate()
     {
       MoveEnemy(movement); 
     }
     void MoveEnemy(Vector2 direction)
     {
       rb.MovePositon((Vector2)transform.position * (direction * movespeed * Time.deltaTime));
     }

     void onTriggerEnter2D(Collider2D other)
    {
      if(other.gameobject.Compatetag("Projectile"))
       Destroy(gameobject); 
    }
}

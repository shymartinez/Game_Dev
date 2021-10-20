using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCONTROLLER : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnspeed = 15.0f;

   private float hInput;
   private float vInput;

   public float xRange = 10.5f;
   public float yRange = 4.5f;

   public GameObject projectile;
   public Transform firePoint; 

    // Update is called once per frame
    void Update()
    {
       // Setup input connections to keymaps 
       vInput = Input.GetAxis("Vertical");
       hInput = Input.GetAxis("Horizontal");

        // Move and rotate player 
      transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
      transform.Rotate(Vector3.back, turnspeed * hInput * Time.deltaTime);

      // create wall on the left side 
      if(transform.position.x > xRange)
      {
         transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
      // right wall
      }
      if(transform.position.x < -xRange)
      {
         transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
      // top wall
      }
       if(transform.position.y > yRange)
      {
         transform.position = new Vector3(transform.position.x,yRange, transform.position.z);
        // bottom wall
      }
      if(transform.position.y < -yRange)
      {
         transform.position = new Vector3(transform.position.x,-yRange, transform.position.z);
      }
       // Hit spacebar to shoot
      if(Input.GetKeyDown(KeyCode.Space))
      {
        Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
      }
    }
}

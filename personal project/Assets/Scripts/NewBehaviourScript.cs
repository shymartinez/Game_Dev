using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnspeed = 15.0f;

    private float hInput;
    private float vInput;

    // Update is called once per frame
    void Update()
    {
        // setup input to make connections to keymap
        vInput.Input.GetAxis("Vertical");
        hInput.Input.GetAxis("Horizontal");

        // move and rotate player
        transform.Translate(Vector3.up * speed * Time.deltatime * vInput);
        transform.Rotate(Vector3.back, turnspeed * hInput * Time.deltatime);

        //create wall on left 
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y,transform.position.z);
             // wall on right
        }
       if(transform.position.x < -xRange)
       
        
        //wall on top 

        // wall on bottom
            
        
    }
}

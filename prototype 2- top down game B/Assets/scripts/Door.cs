using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collidre2D other)
    {
        if(other.CompareTag("Player")&& GameManager.haskey)
        {
            print("you have unlocked the door")
            GameManager. 
        }
    }

}

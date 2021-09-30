using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string pickupName;

    public int amount;

    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.Gameobject.CompareTag("Player"))
        {
             print("you've picked up a"+ pickupName);
             GameManager.hasKey = true; 
              Destroy(gameObject);
        }
       
    }
}

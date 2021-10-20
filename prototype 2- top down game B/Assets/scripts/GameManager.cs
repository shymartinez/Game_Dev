using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public bool hasKey;
   public bool isDoorLocked;

   //start is called before first frame update 
   void Start()
    {
      hasKey = false;;
      isDoorLocked = true;  
    }

    // Update is called once per frame
    void Update()
    {
        // Player unlocks the door and exits the room 
        if(hasKey && !isDoorLocked)
        {
            print("you opend the door to leave the room!");
        }
    }
}

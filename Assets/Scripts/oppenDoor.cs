using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oppenDoor : MonoBehaviour
{
    // Start is called before the first frame update
   
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Difrent get component
        PickupScript pickup = gameObject.GetComponent<PickupScript>();
        GameObject otherGameObject = collision.gameObject;
        lockedDoor hitLock = otherGameObject.GetComponent<lockedDoor>();
        glasväg hitglas = otherGameObject.GetComponent<glasväg>();
        GameObject play = collision.gameObject;

        //Send signal to door to run door script
        if (pickup.holdingKey == true)
        {
            if (hitLock != null)
            {
                hitLock.unlock();

            }
        }

        //Send signal to glas to run glas wall script
        if (pickup.holdingPipe == true)
        {
            if (hitglas != null)
            {
                hitglas.Destroywindow();
                pickup.holdingPipe = false;

            }
        }


    }
}

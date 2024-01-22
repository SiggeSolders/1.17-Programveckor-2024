using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    PickupScript pickup;
    
    void Start()
    {
        pickup = gameObject.GetComponent<PickupScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //float speed = 3;
        GameObject otherGameObject = collision.gameObject;
        //door hitenemy = otherGameObject.GetComponent<door>();
        //door2 hitdoor = otherGameObject.GetComponent<door2>();
        lockedDoor hitLock = otherGameObject.GetComponent<lockedDoor>();
        glasväg hitglas = otherGameObject.GetComponent<glasväg>();
        //if (hitenemy != null)
        //{
        //  hitenemy.TakeDamage();

        //}
        GameObject play = collision.gameObject;
        if (pickup.holdingKey == true)
        {
            if (hitLock != null)
            {
                hitLock.unlock();

            }
        }
        if (pickup.holdingPipe == true)
        {
            if (hitglas != null)
            {
                hitglas.Destroywindow();
                pickup.holdingPipe = false;

            }
        }
        // if (pickup.holdKey = true)
        //{
        //  if (hitdoor != null)
        //{
        //  hitdoor.TakeDoor();

        //}
        //}

    }
}

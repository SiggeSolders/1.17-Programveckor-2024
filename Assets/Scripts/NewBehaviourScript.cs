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
        LLLock hitLock = otherGameObject.GetComponent<LLLock>();
        glasv�g hitglas = otherGameObject.GetComponent<glasv�g>();
        //if (hitenemy != null)
        //{
        //  hitenemy.TakeDamage();

        //}
        GameObject play = collision.gameObject;
        Debug.Log("gick in i d�r");
        if (pickup.holdKey == true)
        {
            Debug.Log("har nyckel");
            if (hitLock != null)
            {
                Debug.Log("har nyckel");
                hitLock.TakeLock();

            }
        }
        if (pickup.holdPipe == true)
        {
            if (hitglas != null)
            {
                hitglas.Destroywindow();

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

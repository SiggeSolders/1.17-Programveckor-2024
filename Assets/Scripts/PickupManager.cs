using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField]
    GameObject pickUp1;


    int holding = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            PickUp();
            holding++;
        }

 
    }
    void PickUp()
    {
            bool hold1 = false;

            hold1 = true;
            if(hold1)
            {
                pickUp1.transform.position = transform.position + new Vector3(1, 1, 0);
                if (Input.GetKey(KeyCode.Q))
                {
                    hold1 = false;
                    holding--;
                }
            }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigi.AddForce(new Vector3(0, 0, 30));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigi.AddForce(new Vector3(0, 0, -30));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigi.AddForce(new Vector3(-30, 0, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigi.AddForce(new Vector3(30, 0, 0));
        }
    }
}

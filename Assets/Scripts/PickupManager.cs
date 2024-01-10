using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public Transform equipPos;
    public float equipDistance = 10f;
    GameObject holding;
    GameObject item;

    bool grabbable = false;

    private void FixedUpdate()
    {
        CheckItem();

        if (grabbable)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if(holding != null)
                {
                    Debug.Log("GRAB");
                    Drop();
                    PickUp();
                }
            }
        }
        if (holding != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Drop();
            }
        }
    }
private void CheckItem()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit, equipDistance))
        {
            if (hit.transform.tag == "Grabable")
            {
                grabbable = true;
                item = hit.transform.gameObject;
            }
        }
        else
        {
            grabbable = false;
        }
    }

    void PickUp()
    {
        Debug.Log("huh");
        holding = item;
        holding.transform.position = equipPos.transform.position;
        holding.transform.parent = equipPos;
        holding.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        holding.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Drop()
    {
        holding.GetComponent<Rigidbody>().isKinematic = false;
        holding.transform.parent = null;
        holding = null;
    }
}

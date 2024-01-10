using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform Player;
    public GameObject Item;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Unequip();
            Check();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Unequip();

        }
    }

    void Check()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                Equip();
            }
        }
    }

    void Unequip()
    {
        Player.DetachChildren();
        Item.transform.eulerAngles = new Vector3(Item.transform.eulerAngles.x, Item.transform.eulerAngles.y, Item.transform.eulerAngles.z - 45);
        Item.GetComponent<Rigidbody>().isKinematic = false;
    }

    void Equip()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
        Item.transform.position = Player.transform.position;
        Item.transform.rotation = Player.transform.rotation;
        Item.transform.SetParent(Player);
    }
}
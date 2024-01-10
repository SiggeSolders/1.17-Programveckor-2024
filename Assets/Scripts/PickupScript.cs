using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PickupScript : MonoBehaviour
{

    public Transform Player;
    public GameObject Item;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;
    public bool holdKey = false;
    public bool holdPipe = false;
    public bool holdScroll = false;
    string name;
    [SerializeField]
    GameObject pickUpText;

    TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        textComponent = pickUpText.GetComponent<TextMeshProUGUI>();
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            PickUp(); 
        }
    }


    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Key")
            {
                Item = hit.transform.gameObject;
                name = "Key";
                Item.SetActive(false);
                holdKey = true;
                pickUpText.SetActive(true);
                textComponent.text = "You Picked Up A " + name + "!";
                StartCoroutine(Timer());
            }
            if (hit.transform.tag == "Pipe")
            {
                Item = hit.transform.gameObject;
                Item.SetActive(false);
                holdPipe = true;
                pickUpText.SetActive(true);
                name = "Pipe";
                textComponent.text = "You Picked Up A " + name + "!";
                StartCoroutine(Timer());
            }
            if (hit.transform.tag == "Scroll")
            {
                Item = hit.transform.gameObject;
                Item.SetActive(false);
                holdScroll = true;
                pickUpText.SetActive(true);
                name = "Scroll";
                textComponent.text = "You Picked Up A " + name + "!";
                StartCoroutine(Timer());
            }

        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        pickUpText.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PickupScript : MonoBehaviour
{

    public GameObject item;
    public Camera camera;
    public float pickupRange = 2f;
    public float open = 100f;
    public bool holdingKey = false;
    public bool holdingPipe = false;
    public bool holdingScroll = false;
    string name;

    [SerializeField]
    GameObject pickUpText;
    [SerializeField]
    AudioSource pickupSound;

    [SerializeField]
    GameObject PickUpPosition;

    [SerializeField]
    GameObject Pipe;
    [SerializeField]
    GameObject Pipe2;

    EnemyMovement enemy;

    TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Start()
    {
        pickUpText.SetActive(false);
        textComponent = pickUpText.GetComponent<TextMeshProUGUI>();
        enemy = FindAnyObjectByType<EnemyMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        // Om E trycks på, kommer en raycast skickas.

        if (Input.GetKey(KeyCode.E))
        {
            PickUp(); 
        }
    }


    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, pickupRange))
        {

            // Om den tag som sitter på saken som träffas är "Key" Försvinner den, holdingKey blir sann, texts skriver att man tog upp den och en timer startas
            if (hit.transform.tag == "Key")
            {
                item = hit.transform.gameObject;
                name = "Nyckel";
                item.SetActive(false);
                holdingKey = true;
                pickUpText.SetActive(true);
                textComponent.text = "Du Plockade Upp En " + name + "!";
                StartCoroutine(Timer());
            }
            //samma som nyckeln, men här blir röret en child till kameran, så att den följer efter, Sedan hamnar den på pickupPosition och förlorar sin collider
            if (hit.transform.tag == "Pipe")
            {
                pickupSound.Play();
                Pipe.transform.parent = camera.transform;
                Pipe.transform.position = PickUpPosition.transform.position;
                Collider collider = Pipe.GetComponent<BoxCollider>();
                collider.enabled = false;
                holdingPipe = true;
                pickUpText.SetActive(true);
                name = "Rör";
                textComponent.text = "Du Plockade Upp Ett " + name + "!";
                StartCoroutine(Timer());
            }

            // samma som förra if-satsen men en annan variabel så att den andra glasrutan inte ska gå att krossa
            if (hit.transform.tag == "Pipe2")
            {
                pickupSound.Play();
                Pipe2.transform.parent = camera.transform;
                Pipe2.transform.position = PickUpPosition.transform.position;
                Collider collider2 = Pipe2.GetComponent<BoxCollider>();
                collider2.enabled = false;
                holdingPipe = true;
                pickUpText.SetActive(true);
                name = "Rör";
                textComponent.text = "Du Plockade Upp Ett " + name + "!";
                StartCoroutine(Timer());
            }

            // Samma som nyckeln men dokument.
            if (hit.transform.tag == "Scroll")
            {
                item = hit.transform.gameObject;
                item.SetActive(false);
                enemy.GoAway();
                holdingScroll = true;
                pickUpText.SetActive(true);
                name = "Dokument";
                textComponent.text = "Du Plockade Upp Ett " + name + "!";
                StartCoroutine(Timer());
            }

        }
    }


    // Timern tar bort texten efter 5 sekunder
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        pickUpText.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EnemyMovement : MonoBehaviour
{
    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float sightRange;
    public float detectionRange;

    public Rigidbody rigi;
    public GameObject target;
    [SerializeField]

    private bool seePlayer;
    public NavMeshAgent agent;
    [SerializeField]
    GameObject deathText;
    [SerializeField]
    GameObject crosshair;
    [SerializeField]
    VideoPlayer deathVideo;

    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        deathText.SetActive(false);
        Time.timeScale = 1;
        crosshair.SetActive(true);
    }

    void FixedUpdate()
    {
        //Letar efter spelaren i en sphär. Om den inte ser spelar gör den inget, annars börjar den jagar spelaren
        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, detectionRange);

            foreach (var Hitcollider in hitColliders)
            {
                if (Hitcollider.tag == "Player")
                {
                    target = Hitcollider.gameObject;
                    seePlayer = true;
                }
            }
        }
        else
        {
            //Börjar jaga spelaren
            if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out Hit, sightRange))
            {
                if (Hit.collider.tag != "Player")
                {
                    seePlayer = false;
                }
                else
                {
                    StartCoroutine(AttackDelay());
                }
            }
        }
    }

    //väntar i 3 sekunder innan den sätter destinationen till spelaren
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(2);
        agent.SetDestination(target.transform.position);
    }

    // när den nuddar något, om dens tag är "Player" Spelas videon till när man dör. Sedan startas en timer
    private void OnCollisionEnter(Collision collision)
    {
        GameObject playerDeath = collision.gameObject;

        if (playerDeath.transform.tag == "Player")
        {
            deathVideo.Play();
            StartCoroutine(Video());
        }
    }
    //efter 5 sekunder syns texten där man kan komma tillbaka till menyn och muspekaren blir upplåst
    IEnumerator Video()
    {
        agent.speed = 0;
        yield return new WaitForSeconds(5);
        Debug.Log("kaka");
        deathText.SetActive(true);
        crosshair.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Den går tillbaka 2 scener till menyn
    public void returnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    //När dokumentet tas upp står den still och en timer startas
    public void GoAway()
    {
        agent.speed = 0;
        StartCoroutine(Delay());
    }

    // Efter fem sekunder börjar den röra på sig igen med en fart av 5
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        agent.speed = 5;
    }

}

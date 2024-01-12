using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float maxSpeed;
    public float Speed;

    private Collider[] hitColliders;
    private RaycastHit Hit;

    public float sightRange;
    public float detectionRange;

    public Rigidbody rigi;
    public GameObject target;
    [SerializeField]
    public GameObject self;

    private bool seePlayer;
    public NavMeshAgent agent;
    [SerializeField]
    GameObject deathText;



    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        Speed = maxSpeed;
        deathText.SetActive(false);
        Time.timeScale = 1;
    }


    void FixedUpdate()
    {
        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, detectionRange);

            foreach(var Hitcollider in hitColliders)
            {
                if(Hitcollider.tag == "Player")
                {
                    target = Hitcollider.gameObject;
                    seePlayer = true;
                }
            }
        }
        else
        {
            if(Physics.Raycast(transform.position, (target.transform.position - transform.position), out Hit, sightRange))
            {
                if(Hit.collider.tag != "Player")
                {
                    seePlayer = false;
                }
                else
                {
                    agent.SetDestination(target.transform.position);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject playerDeath = collision.gameObject;

        if(playerDeath.transform.tag == "Player")
        {
            deathText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    public void GoAway()
    {
        Debug.Log("GO");
        agent.speed = 0;

        StartCoroutine(Delay());
 
    }

    IEnumerator Delay()
    {
        Debug.Log("WAINTING");
        yield return new WaitForSeconds(5);
        agent.speed = 5;
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}

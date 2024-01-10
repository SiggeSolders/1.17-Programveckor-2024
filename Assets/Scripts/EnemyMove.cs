using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    private bool seePlayer;
    public NavMeshAgent agent;



    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        Speed = maxSpeed;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //float speed = 3;
        GameObject otherGameObject = collision.gameObject;
        door hitenemy = otherGameObject.GetComponent<door>();
        if (hitenemy != null)
        {
            hitenemy.TakeDamage();

        }
    }
}

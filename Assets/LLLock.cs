using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLLock : MonoBehaviour
{

    HingeJoint hinge;
    // Start is called before the first frame update
    void Start()
    {
        hinge.limits.max.Equals(0);
        hinge.limits.min.Equals(0);
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.constraints;
    }
    int hp = 1;
    
    public void TakeLock()
    {
        
        hp -= 1;
        if (hp == 0)
        {
            hinge.limits.max.Equals(-90);
            hinge.limits.min.Equals(90);
            Rigidbody rigid = GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

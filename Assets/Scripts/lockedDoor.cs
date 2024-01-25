using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //so you can only open once
    int doorHp = 1;
    
    public void unlock()
    {
        //Makes opening door possible door.
        doorHp -= 1;
        if (doorHp == 0)
        {
            HingeJoint hinge = GetComponent<HingeJoint>();
            JointLimits limits = hinge.limits;
            limits.min = -90;
            limits.max = 90;
            hinge.limits = limits;
            hinge.useLimits = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

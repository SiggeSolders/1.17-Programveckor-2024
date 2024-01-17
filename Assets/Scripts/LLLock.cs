using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int hp = 1;
    
    public void TakeLock()
    {
        
        hp -= 1;
        if (hp == 0)
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

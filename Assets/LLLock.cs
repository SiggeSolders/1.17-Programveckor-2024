using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezeRotationY;
    }
    int hp = 1;
    
    public void TakeLock()
    {
        
        hp -= 1;
        if (hp == 0)
        {
            Rigidbody rigid = GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

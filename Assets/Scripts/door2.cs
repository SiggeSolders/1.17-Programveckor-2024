using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int hp = 1;
    public void TakeDoor()
    {
        hp -= 1;
        if (hp == 0)
        {
            transform.Rotate(new Vector3(0, -90, 0));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

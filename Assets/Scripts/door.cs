using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    int hp = 1;
    public void TakeDamage()
    {
        hp -= 1;
        if (hp == 0)
        {
            transform.Rotate(new Vector3(0, -90, 0));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //3rmnkrnh2ukhrkuq
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

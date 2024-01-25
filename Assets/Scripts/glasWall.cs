using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glasWall : MonoBehaviour
{
    // Start is called before the first frame update'
    [SerializeField]
    GameObject glas_shard1;
    [SerializeField]
    GameObject glas_shard2;
    [SerializeField]
    GameObject glas_shard3;
    [SerializeField]
    GameObject glas_shard4;
    [SerializeField]
    GameObject glas_shard5;
    [SerializeField]
    GameObject glas_shard6;
    [SerializeField]
    GameObject Pipe;
    public void Destroywindow()
    {
        //destoy glas and spawn shards
        Destroy(gameObject);
        glas_shard1.SetActive(true);
        glas_shard2.SetActive(true);
        glas_shard3.SetActive(true);
        glas_shard4.SetActive(true);
        glas_shard5.SetActive(true);
        glas_shard6.SetActive(true);
        Pipe.SetActive(false);
        //Instantiate(Glas_pliter, transform.position + new Vector3(0, 0, 1), Quaternion.identity);


    }
    void Start()
    {

        glas_shard1.SetActive(false);
        glas_shard2.SetActive(false);
        glas_shard3.SetActive(false);
        glas_shard6.SetActive(false);
        glas_shard5.SetActive(false);
        glas_shard4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

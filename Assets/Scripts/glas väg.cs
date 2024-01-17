using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glasväg : MonoBehaviour
{
    // Start is called before the first frame update'
    [SerializeField]
    GameObject Glas_pliter1;
    [SerializeField]
    GameObject Glas_pliter2;
    [SerializeField]
    GameObject Glas_pliter3;
    [SerializeField]
    GameObject Glas_pliter4;
    [SerializeField]
    GameObject Glas_pliter5;
    [SerializeField]
    GameObject Glas_pliter6;
    [SerializeField]
    GameObject Pipe;
    public void Destroywindow()
    {

        Destroy(gameObject);
        Glas_pliter1.SetActive(true);
        Glas_pliter2.SetActive(true);
        Glas_pliter3.SetActive(true);
        Glas_pliter4.SetActive(true);
        Glas_pliter5.SetActive(true);
        Glas_pliter6.SetActive(true);
        Pipe.SetActive(false);
        //Instantiate(Glas_pliter, transform.position + new Vector3(0, 0, 1), Quaternion.identity);


    }
    void Start()
    {
        
        Glas_pliter1.SetActive(false);
        Glas_pliter2.SetActive(false);
        Glas_pliter3.SetActive(false);
        Glas_pliter6.SetActive(false);
        Glas_pliter5.SetActive(false);
        Glas_pliter4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

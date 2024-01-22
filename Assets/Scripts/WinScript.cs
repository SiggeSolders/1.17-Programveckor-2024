using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField]
    GameObject WinText;
    // Start is called before the first frame update
    void Start()
    {
        //Texten syns inte i början
        WinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // när något nuddar den ökar scenen med 1
    private void OnCollisionEnter(Collision collision)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

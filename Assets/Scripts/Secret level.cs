using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Secretlevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // n�r den nuddas, g�r den till hemliga niv�n.
    private void OnCollisionEnter(Collision collision)
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}

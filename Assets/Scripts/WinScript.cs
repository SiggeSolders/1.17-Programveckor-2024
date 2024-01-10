using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField]
    GameObject WinText;
    // Start is called before the first frame update
    void Start()
    {
        WinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        Time.timeScale = 0;
        WinText.SetActive(true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField]
    GameObject WinText;

    DateTime startTime;

    TextMeshProUGUI textComponent;
    public TimeSpan timeElapsed { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        //Texten syns inte i början
        WinText.SetActive(false);
        startTime = DateTime.Now;
        textComponent = WinText.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        this.timeElapsed = DateTime.Now - startTime;

    }

    // när något nuddar den ökar scenen med 1
    private void OnCollisionEnter(Collision collision)
    {
        WinText.SetActive(true);
        textComponent.text = "Din tid " + timeElapsed.ToString();
        StartCoroutine(BeforeWin());
    }
    IEnumerator BeforeWin()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

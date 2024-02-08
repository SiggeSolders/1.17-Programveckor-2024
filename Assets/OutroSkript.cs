using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroSkript : MonoBehaviour
{
    [SerializeField]
    GameObject Outro1;
    [SerializeField]
    GameObject Outro2;
    [SerializeField]
    AudioSource Skrik;
    [SerializeField]
    AudioSource Crash;
    [SerializeField]
    AudioSource Musik;
    CanvasGroup Alpha;
    // Start is called before the first frame update
    void Start()
    {
        Alpha = GetComponent<CanvasGroup>();
        Alpha.alpha = 0;
        Outro1.SetActive(false);
        Outro2.SetActive(false);
        StartCoroutine(Timer());

    }

    // Update is called once per frame
    IEnumerator Timer()
    {
        Musik.Play();
        Outro1.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        while (Alpha.alpha < 1)
        {
            Alpha.alpha += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(5);
        while (Alpha.alpha > 0)
        {
            Alpha.alpha -= Time.deltaTime;
            yield return null;
        }
        Outro1.SetActive(false);
        yield return new WaitForSeconds(5);
        Musik.Stop();
        Crash.Play();
        yield return new WaitForSeconds(1);
        Skrik.Play();

        Outro2.SetActive(true);
        while (Alpha.alpha < 1)
        {
            Alpha.alpha += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(5);
        while (Alpha.alpha > 0)
        {
            Alpha.alpha -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}

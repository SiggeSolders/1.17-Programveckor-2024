using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextSkript : MonoBehaviour
{
    [SerializeField]
    GameObject Intro1;
    [SerializeField]
    GameObject Intro2;
    [SerializeField]
    GameObject Intro3;
    [SerializeField]
    AudioSource Musik;
    CanvasGroup Alpha;
    // Start is called before the first frame update
    void Start()
    {
        Alpha = GetComponent<CanvasGroup>();
        Alpha.alpha = 0;
        Intro1.SetActive(false);
        Intro2.SetActive(false);
        Intro3.SetActive(false);
        StartCoroutine(Timer());

    }

    // Update is called once per frame
    IEnumerator Timer()
    {
        Musik.Play();
        Intro1.SetActive(true);
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
        Intro1.SetActive(false);
        Intro2.SetActive(true);
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
        Intro2.SetActive(false);
        Intro3.SetActive(true);
        while (Alpha.alpha < 1)
        {
            Alpha.alpha += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(5);
        Intro3.SetActive(false);
        while (Alpha.alpha > 0)
        {
            Alpha.alpha -= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

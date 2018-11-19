using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFadeCs : MonoBehaviour {

    public CanvasGroup can;
    public float smooth;
    public GameObject fadeCanvas;

    public static CanvasFadeCs instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        SetObj();
        FadeIn();
    }

    public void FadeIn()
    {
        SetObj();
        StopAllCoroutines();
        StartCoroutine(Fadein(can));
        Invoke("SetObj", 1.0f);
    }


    public void FadeOut()
    {
        SetObj();
        StopAllCoroutines();
        StartCoroutine(Fadeout(can));
        Invoke("SetObj", 1.0f);

    }
    // when ui goes black 
    private IEnumerator Fadein(CanvasGroup cg)
    {

        while (can.alpha >= 0)
        {
            can.alpha -= Time.deltaTime / smooth;
            yield return null;
        }
        yield return null;


    }
    //when ui does translucent 
    private IEnumerator Fadeout(CanvasGroup cg)
    {
        while (can.alpha <= 1)
        {
            can.alpha += Time.deltaTime / smooth;
            yield return null;
        }
        yield return null;
    }

    public void SetObj()
    {
        if (fadeCanvas.gameObject.activeSelf == true)
        {
            fadeCanvas.SetActive(false);
            return;
        }
        else if (fadeCanvas.gameObject.activeSelf == false)
        {
            fadeCanvas.SetActive(true);
            return;
        }
    }

}

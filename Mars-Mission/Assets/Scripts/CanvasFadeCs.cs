using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFadeCs : MonoBehaviour {

    public CanvasGroup can;
    public float smooth;


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
        FadeIn();
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(Fadein(can));
    }


    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(Fadeout(can));
    }

    private IEnumerator Fadein(CanvasGroup cg)
    {
        while (can.alpha >= 0)
        {
            can.alpha -= Time.deltaTime / smooth;
            yield return null;
        }

        yield return null;


    }
    private IEnumerator Fadeout(CanvasGroup cg)
    {

        while (can.alpha <= 1)
        {
            can.alpha += Time.deltaTime / smooth;
            yield return null;
        }
        yield return null;
    }

}

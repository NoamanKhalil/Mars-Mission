using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurazieCs : MonoBehaviour
{
    [SerializeField]
    AudioSource aud;
    bool isPressurized;
    bool isOpen;
    float timer;
	// Use this for initialization
	void Start () 
    {
        timer = 5.0f;
	} 
	// Update is called once per frame
	void Update ()
    {

        if (!isPressurized && isOpen)
        {
            //play sound here 
            //aud.Play();
            timer -= Time.deltaTime;
            if (timer<=0)
            {
                CanvasFadeCs.instance.FadeIn();
                //you died 
            }
        }
        else if (isPressurized&& isOpen)
        {
            //aud.Play();
            //play sound here again
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //door open 
            }
        }
	}


    public void SetPressure(bool press)
    {
        isPressurized = press;
    }

    void die ()
    {

    }
}

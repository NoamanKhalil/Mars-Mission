using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressurazieCs : MonoBehaviour
{
    [SerializeField]
    AudioSource aud;
    [SerializeField]
    Text [] statusText;

    bool isPressurized;
    bool isInOpen;
    bool isOutOpen;
    bool hasOxygen;
    float timer;
	// Use this for initialization
	void Start () 
    {
        timer = 5.0f;
	} 
	// Update is called once per frame
	void Update ()
    {

        if (isPressurized)
        {
            hasOxygen = true;
        }
        else
        {
            hasOxygen = false;
        }


        if (hasOxygen)
        {
            for (int i = 0; i < statusText.Length; i++)
            {
                statusText[i].text = "AtmoSphere:" + hasOxygen;
            }
        }
        else 
        {
            for (int i = 0; i < statusText.Length; i++)
            {
                statusText[i].text = "AtmoSphere:" + hasOxygen;

            }
        }


        if (isInOpen && isOutOpen)
        {
            // you dide 
            //CanvasFadeCs.instance.FadeIn();
            Debug.Log("You died");
        }


        if (!isPressurized && isInOpen)
        {
            //play sound here 
            //aud.Play();
            Debug.Log("You died");
            /*timer -= Time.deltaTime;
            if (timer<=0)
            {
                //CanvasFadeCs.instance.FadeIn();
                //Debug.Log("You died");
                //you died 
            }*/
        }
        else if (isPressurized&& isInOpen)
        {
            //aud.Play();
            //play sound here again
            /*timer -= Time.deltaTime;
            if (timer <= 0)
            {
                //door open animation 
            }*/
            Debug.Log("You can move");
        }
        if (!isPressurized && isOutOpen)
        {
            Debug.Log("You can move");
        }
        else if (isPressurized && isOutOpen)
        {
            Debug.Log("You died");
        }
	}

    // loads up atmosphere
    public void SetPressure(bool press)
    {
        isPressurized = press;
    }


    public void SetInDoor(bool door )
    {
        isInOpen = door;
    }

    public void SetOutDoor(bool door)
    {
        isOutOpen = door;
    }
    void die ()
    {

    }
}

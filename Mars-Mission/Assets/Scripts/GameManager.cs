using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }
    public Text temperatureText;
    public float temperature;
    float myTime;

    public bool isDay;

    // TODO: make a day and night system for temperature to work
    // Added UI for temperature.
    //-120 degrees C to 30 degrees C
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        myTime = 2.0f;
    }
	// Update is called once per frame
	void Update () 
    {

        myTime -= Time.deltaTime;
        if (myTime<=0)
        {
            if (isDay)
            {
                temperature = Random.Range(-50, 30);
            }
            else
            {
                temperature = Random.Range(-50, -120);
            }

            myTime = 2.0f;
        }
        //Debug.Log(myTime);

        temperatureText.text = temperature +" °C";
    }
}
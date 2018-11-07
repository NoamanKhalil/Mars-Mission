using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPcounter : MonoBehaviour {

    Text myCoounter;

    float deltaTime = 0.0f;
     void Start()
    {
        myCoounter = GetComponent<Text>();
    }
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        myCoounter.text = "" + text;
    }

}

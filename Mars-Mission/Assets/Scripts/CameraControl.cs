using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraControl : MonoBehaviour 
{
    public GameObject player;
    public float Sensitivity = 2f;
    public float Smoothness = 2f;
    public Vector2 lookAngle;

    Vector2 MouseControl;
    Vector2 Smoothing;


    public float maxClamp;
    public float minClamp;

    void LateUpdate()
    {
        // pre-processor directive for Android & iphone 
        #if UNITY_IPHONE || UNITY_ANDROID
               Vector2 nd = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal_0"),(CrossPlatformInputManager.GetAxis("Vertical_0")));
        #endif
        // pre-processor directive for windows, osx & linux 
        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
                Vector2 nd = new Vector2(Input.GetAxis("Horizontal_0")/2, (Input.GetAxis("Vertical_0")/2));
        #endif
        nd = Vector2.Scale(nd, new Vector2(Sensitivity * Smoothness, Sensitivity * Smoothness));
        Smoothing.x = Mathf.Lerp(Smoothing.x, nd.x, 1f / Smoothness);
        Smoothing.y = Mathf.Lerp(Smoothing.y, nd.y, 1f / Smoothness);
        MouseControl += Smoothing;
        MouseControl.y = Mathf.Clamp(MouseControl.y, minClamp, maxClamp);

        transform.localRotation = Quaternion.AngleAxis(-MouseControl.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(MouseControl.x, player.transform.up);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FpcontrollerCs : MonoBehaviour {


    public float runVel = 36f;
    public float jumpVel = 0.2f;

    private float forwardVel;
    private Vector3 velocity;
    private Vector3 IVeloctiy;
    private float walkVel = 8f;
    Rigidbody rb;
    [SerializeField]
    float forwardInput, straffeInput;
    private float tempStamina;
    bool isPlaying;
    bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forwardInput = straffeInput;
        isPlaying = false;
        forwardVel = walkVel;
    }

    void Update()
    {
        velocity = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal")*forwardVel, 0, CrossPlatformInputManager.GetAxis("Vertical")*forwardVel);
        velocity = transform.TransformDirection(velocity);
        velocity.y = rb.velocity.y; 
        rb.velocity = velocity;
        if (canJump & Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpVel, 0), ForceMode.Impulse);
            canJump = false;
        }
    }


    void OnCollisionStay(Collision other)
    {
        canJump = true;
    }

}

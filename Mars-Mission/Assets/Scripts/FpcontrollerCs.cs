using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class FpcontrollerCs : MonoBehaviour {


    public float oxygen;
    public Image oxygenImage;
    public bool isIndoor;

    public float stamina;
    public Image staminaImage;
    public bool canRun;

    private float oxygenUifill;
    private float staminaUiFill;

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
        if ((CrossPlatformInputManager.GetAxis("Vertical") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0)&&stamina >=1)
        {
            velocity = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal") * forwardVel/2, 0, CrossPlatformInputManager.GetAxis("Vertical") * forwardVel/2);
            velocity = transform.TransformDirection(velocity);
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
            StaminaDecrease();
        }
        else if ((CrossPlatformInputManager.GetAxis("Vertical") == 0 || CrossPlatformInputManager.GetAxis("Vertical") == 0))
        {
            if (isIndoor)
            {
                StaminaIncrease(2);
            }
            else 
            {
                StaminaIncrease(1);
            }

        }

        if (canJump & Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpVel, 0), ForceMode.Impulse);
            canJump = false;
        }
        if (!isIndoor)
        {
            DecreaseOxygen();
        }
        else
        {
            IncreaseOxygen();
        }
    }

    void StaminaDecrease()
    {
        if (stamina >= 1)
        {
            forwardVel = runVel;
            stamina-= Time.deltaTime;
            staminaUiFill = stamina / 100;
            staminaImage.fillAmount = staminaUiFill;
        }
    }

    void StaminaIncrease(float inc)
    {
        if (stamina <= 100.0f)
        {
            //Debug.Log("Stamina going up " + stamina);
            forwardVel = walkVel;
            stamina += Time.deltaTime*inc;
            staminaUiFill = stamina / 100;
            staminaImage.fillAmount = staminaUiFill;

        }
    }


    void DecreaseOxygen()
    {
        if (oxygen >= 1)
        {
            //isIndoor = true;
            forwardVel = runVel;
            oxygen-= Time.deltaTime;
            oxygenUifill = oxygen / 100;
            oxygenImage.fillAmount = oxygenUifill;
        }

    }
    void IncreaseOxygen()
    {
        /* Oxygen regen code */
        if (oxygen <= 100.0f)
        {
            //Debug.Log("Stamina going up " + stamina);
            forwardVel = walkVel;
            oxygen += Time.deltaTime;
            oxygenUifill = oxygen / 100;
            oxygenImage.fillAmount = oxygenUifill;

        }
    }

    void OnCollisionStay(Collision other)
    {
        canJump = true;
    }

}

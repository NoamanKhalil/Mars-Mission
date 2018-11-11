using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCs : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<FpcontrollerCs>().setIndoor(true);
    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<FpcontrollerCs>().setIndoor(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mission1 : MonoBehaviour
{

    public static Mission1 instance;
    public AudioSource audioQ;
    public Text missionText;
    public Text boosterText;
    public GameObject signalBooster;
    public GameObject player;
    public GameObject homeBase;
    public bool isbooster;
    float dist;
    float timerA = 2.0f;
    float timerB = 2.0f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        boosterText.text = "Activateion Status: " + isbooster;
        if (!isbooster)
        {


           

            timerA -= Time.deltaTime;
            if (timerA >= 0)
            {
                missionText.text = "Communication signal low, activate signal booster";
            }
            else
            {
                dist =Mathf.RoundToInt(Vector3.Distance(signalBooster.transform.position, player.transform.position)) ; 
                missionText.text = "Signal amplifier: " + dist + "m";
            }
        }
        else
        {
            timerB -= Time.deltaTime;
            if (timerB>=0)
            {
                missionText.text = "Mission Update:Return to base camp & activate communications";
            }
            else
            {
                dist =Mathf.RoundToInt(Vector3.Distance(homeBase.transform.position, player.transform.position));
                missionText.text = "Base camp: "+ dist+"m";
            }
        }
        
    }

    public void boosterControl(bool myBool)
    {
        isbooster = myBool;
    }
}

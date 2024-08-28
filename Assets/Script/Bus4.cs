using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bus4 : MonoBehaviour
{

    public Button Enter;
    public Button buttonFw;
    public Button buttonb;
    public Button buttonL;
    public Button buttonR;
    public Button buttonU;
    void Start()
    {
        Enter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }



    private void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.tag == "Player" && tag == "Bus4")
        {
            Enter.gameObject.SetActive(true); 
            buttonFw.gameObject.SetActive(false);
            buttonb.gameObject.SetActive(false);
            buttonL.gameObject.SetActive(false);
            buttonR.gameObject.SetActive(false);
            buttonU.gameObject.SetActive(false);
            PlayerMovement.StopMovement();

        }
    }
}

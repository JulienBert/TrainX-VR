using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script allows to say if the players is in the good position or not according to the dosemap
/// ATTENTION : not use in the multiplayer scenario
/// </summary>
public class DoseMapPosition : MonoBehaviour
{

    public Canvas goodPosition;
    public Canvas wrongPosition;
    public Canvas nextAngle;

    bool isInWrongPlace;
    public static bool isEnded;

    private void Awake()
    {
        goodPosition.GetComponent<Canvas>();
        wrongPosition.GetComponent<Canvas>();
        nextAngle.GetComponent<Canvas>();
    }

    private void Start()
    {
        isInWrongPlace = false;
        isEnded = false;
        goodPosition.gameObject.SetActive(false);
        wrongPosition.gameObject.SetActive(false);
        nextAngle.gameObject.SetActive(false);
    }
    
    private void Update()
    {

        OVRInput.Update();


        if (DoseMapLocalizer.isDoseMap && !isEnded)
        {
            
            
            if (isInWrongPlace)
            {
                goodPosition.gameObject.SetActive(false);
                wrongPosition.gameObject.SetActive(true);
                nextAngle.gameObject.SetActive(false);
                //Debug.Log("WRONG PLACE");
               
            }
            else
            {
                //Debug.Log("GOOD PLACE");
                wrongPosition.gameObject.SetActive(false);
                goodPosition.gameObject.SetActive(true);
                nextAngle.gameObject.SetActive(false);

            }

            

        }

        if (!CheckPosition.isInOperatingRoomSquare)
        {
            wrongPosition.gameObject.SetActive(false);
            goodPosition.gameObject.SetActive(false);
        }



        if (OVRInput.Get(OVRInput.Button.Two))
        {
            isEnded = true;
            nextAngle.gameObject.SetActive(true);
            wrongPosition.gameObject.SetActive(false);
            goodPosition.gameObject.SetActive(false);
            
        }




    }
/*
    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("ENTER");
        if (collision.gameObject.tag == "Player")
        {
            isInWrongPlace = true;

        }
     
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER");
        if (other.gameObject.tag == "Player")
        {
            isInWrongPlace = true;

        }
    }

    /*void OnCollisionExit(Collision collision)
    {

        Debug.Log("EXIT");
        if (collision.gameObject.tag == "Player")
        {
            isInWrongPlace = false;
        }
     
    }*/

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("EXIT");
        if (other.gameObject.tag == "Player")
        {
            isInWrongPlace = false;
        }
    }
}

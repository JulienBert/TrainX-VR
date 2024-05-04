using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Thi sscript is used to open the door 
/// ATTENTION : not use in multiplayer scenario
/// </summary>
public class WelcomeZone : MonoBehaviour
{
    public Animator animatorDoor1;
    public Animator animatorDoor2;
    public Animator animatorDoor3;
    public Animator animatorDoor4;

    //public AudioSource welcomeToTheOperatingRoom;

    public static bool isEntered;

    private void Awake()
    {
        animatorDoor1.GetComponent<Animator>();
        animatorDoor2.GetComponent<Animator>();
        animatorDoor3.GetComponent<Animator>();
        animatorDoor4.GetComponent<Animator>();

        //welcomeToTheOperatingRoom.GetComponent<AudioSource>();

        isEntered = false;
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            animatorDoor1.SetBool("isOpen", false);
            animatorDoor2.SetBool("isOpen", false);
            animatorDoor3.SetBool("isOpen", false);
            animatorDoor4.SetBool("isOpen", false);

            //welcomeToTheOperatingRoom.Play();

        }

        if (collision.gameObject.tag == "Ethan")
        {

            isEntered = true;

        }


    }
}

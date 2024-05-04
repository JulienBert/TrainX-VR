using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows the first door to be opened in order to go to the sas before the operating room
/// </summary>
public class DisableTelportZone3 : MonoBehaviour
{
    public Animator animatorDoor1;
    public Animator animatorDoor2;
    public Animator animatorDoor3;
    /*public Animator animatorDoor4;*/
    //public Animator animatorTrainer;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        animatorDoor1.GetComponent<Animator>();
        animatorDoor2.GetComponent<Animator>();
        animatorDoor3.GetComponent<Animator>();
        /*animatorDoor4.GetComponent<Animator>();*/
        //animatorTrainer.GetComponent<Animator>();
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player") //if it detects the player
        {

            meshRenderer.enabled = false;
            //animatorTrainer.SetBool("isSucceed", true);
            animatorDoor1.SetBool("isOpen", true);
            animatorDoor2.SetBool("isOpen", true);
            animatorDoor3.SetBool("isOpen", true);
            /*animatorDoor4.SetBool("isOpen", true);*/
            

        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows to open the door when the player is in the area for it
/// ATTENTION : not use in the multiplayer scene
/// </summary>
public class EnterZone : MonoBehaviour
{
    public Animator animatorDoor1;
    public Animator animatorDoor2;
    public Animator animatorDoor3;
    public Animator animatorDoor4;

    public GameObject teleportZone;

    public AudioSource goToLeadAprons;

    private void Awake()
    {
        animatorDoor1.GetComponent<Animator>();
        animatorDoor2.GetComponent<Animator>();
        animatorDoor3.GetComponent<Animator>();
        animatorDoor4.GetComponent<Animator>();

        goToLeadAprons.GetComponent<AudioSource>();

        teleportZone.GetComponent<GameObject>();
    }

    private void Start()
    {
        teleportZone.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            animatorDoor1.SetBool("isOpen", true);
            animatorDoor2.SetBool("isOpen", true);
            animatorDoor3.SetBool("isOpen", true);
            animatorDoor4.SetBool("isOpen", true);

            teleportZone.SetActive(true);

            goToLeadAprons.Play();
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script disable the green halo which was in the operating room to guide the player to go to
/// ATTENTION : no longer used in the multiplayer scenario
/// </summary>

public class DisableHaloGreen : MonoBehaviour
{
    MeshRenderer meshRenderer;

    [Header("Canvas")]
    public Canvas canvaOperatingRoom;
    public Canvas canvaWelcomeOperatingRoom;
    public Canvas canvaConfirmChoice;

    [Header("Animators")]
    public Animator animRotationCarm;
    public Animator animHandSurgeon;
    public Animator animHeadWoman;
    public Animator animJointCarm;


    public static bool isInGreenHalo;

    public static int randomInteger = 10;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        canvaOperatingRoom.GetComponent<Canvas>();
        canvaWelcomeOperatingRoom.GetComponent<Canvas>();
        canvaConfirmChoice.GetComponent<Canvas>();

        isInGreenHalo = false;
    }

    private void Update()
    {

        OVRInput.Update();
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            animJointCarm.SetBool("isRotationFinished", true);
            animRotationCarm.SetBool("isRotationFinished", true);
            animHandSurgeon.SetBool("isRotationFinished", true);
            animHeadWoman.SetBool("isRotationFinished", true);
            
            DoseMapLocalizer.isDoseMap = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            meshRenderer.enabled = false;
            canvaOperatingRoom.gameObject.SetActive(true);
            canvaWelcomeOperatingRoom.gameObject.SetActive(false);

            isInGreenHalo = true;

            animHandSurgeon.SetBool("isRotation", true);


            randomInteger = Random.Range(1, 10);


            AnimatorExecute(randomInteger);



        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(canvaOperatingRoom.gameObject);
            canvaConfirmChoice.gameObject.SetActive(true);
            
        }
    }

    public void AnimatorExecute(int randomInteger)
    {
        animHandSurgeon.SetInteger("randomInteger", randomInteger);
        animRotationCarm.SetInteger("randomInteger", randomInteger);
        animRotationCarm.SetBool("isRotationFinished", false);
        animHandSurgeon.SetBool("isRotationFinished", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// This script allows the openning of the door for the operating room
/// </summary>
public class OpenDoor : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas c_wrongAnswer;
    public Canvas c_goodAnswer;
    public Canvas c_firstquestions;

    [Header("Button Colliders")]
    public GameObject b_answer;
    public GameObject b_AButtonCollider;
    public GameObject b_BButtonCollider;
    public GameObject b_CButtonCollider;
    public GameObject b_DButtonCollider;

    
    [Header("Aniamtion")]
    public Animator animatorDoor1;
    public Animator animatorDoor2;
    public Animator animatorDoor3;
    public Animator animatorDoor4;
    public Animator animatorTrainer;


    private PhotonView pv;

    private void Start()
    {
        c_goodAnswer.gameObject.SetActive(false);
        c_wrongAnswer.gameObject.SetActive(false);
        c_firstquestions.gameObject.SetActive(true);

        b_AButtonCollider.SetActive(true);
        b_BButtonCollider.SetActive(true);
        b_CButtonCollider.SetActive(true);
        b_DButtonCollider.SetActive(true);
        b_answer.SetActive(false);

        animatorDoor1.GetComponent<Animator>();
        animatorDoor2.GetComponent<Animator>();
        animatorDoor3.GetComponent<Animator>();
        animatorDoor4.GetComponent<Animator>();
        animatorTrainer.GetComponent<Animator>();

        pv = GetComponent<PhotonView>();
    }


    /*private void Update()
    {
        if (!pv.IsMine) return;
    }*/

    /// <summary>
    /// This method detects if the hands of the player touch the answer of the question which allows him to go to the operating room then.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Hands") //if the hands of the player are detected on the answer buttons colliders
        {

            switch (name)
            {
                // Answer A
                case "OpenDoorACollider":
                    c_firstquestions.gameObject.SetActive(false);
                    b_AButtonCollider.SetActive(false);
                    Destroy(b_BButtonCollider);
                    Destroy(b_CButtonCollider);
                    Destroy(b_DButtonCollider);
                    c_wrongAnswer.gameObject.SetActive(true);
                    StartCoroutine(Delay());
                    b_answer.SetActive(true);
                    break;

                    //Answer B
                case "OpenDoorBCollider":
                    c_firstquestions.gameObject.SetActive(false);
                    b_BButtonCollider.SetActive(false);
                    Destroy(b_AButtonCollider);
                    Destroy(b_CButtonCollider);
                    Destroy(b_DButtonCollider);
                    c_goodAnswer.gameObject.SetActive(true);
                    StartCoroutine(Delay());
                    b_answer.SetActive(true);
                    break;


                    //Answer C
                case "OpenDoorCCollider":
                    c_firstquestions.gameObject.SetActive(false);
                    b_CButtonCollider.SetActive(false);
                    Destroy(b_AButtonCollider);
                    Destroy(b_BButtonCollider);
                    Destroy(b_DButtonCollider);
                    c_wrongAnswer.gameObject.SetActive(true);
                    StartCoroutine(Delay());
                    b_answer.SetActive(true);
                    break;

                    //Answer D
                case "OpenDoorDCollider":
                    c_firstquestions.gameObject.SetActive(false);
                    b_DButtonCollider.SetActive(false);
                    Destroy(b_AButtonCollider);
                    Destroy(b_BButtonCollider);
                    Destroy(b_CButtonCollider);
                    c_wrongAnswer.gameObject.SetActive(true);
                    StartCoroutine(Delay());
                    b_answer.SetActive(true);
                    break;

                    //Button to open the door when the player has the answer elements
                case "OpenDoorAnswerCollider":
                    c_wrongAnswer.gameObject.SetActive(false);
                    c_goodAnswer.gameObject.SetActive(false);
                    Destroy(b_answer);
                    StartCoroutine(Delay());
                    AnimatorExecute();
                    //pv.RPC("AnimatorExecute", RpcTarget.All, null);
                    animatorTrainer.SetBool("isSucceed", false);
                    break;

            }
        }
        

    }

    /// <summary>
    /// This method execute the animation of the door to be opened
    /// </summary>
    /*[PunRPC]*/
    public void AnimatorExecute()
    {
        animatorTrainer.SetBool("isSucceed", true);
        animatorDoor1.SetBool("isOpen", true);
        animatorDoor2.SetBool("isOpen", true);
        animatorDoor3.SetBool("isOpen", true);
        animatorDoor4.SetBool("isOpen", true);


    }

    /// <summary>
    /// This method impose a time delay
    /// </summary>
    /// <returns></returns>
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(30);
    }

}

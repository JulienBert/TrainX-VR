using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// This script is a mix of OpenDoor.cs and AnswerTrainer.cs
/// ATTENTION : not use in the scenario scene
/// </summary>
public class AnswerButtons : MonoBehaviour

{ 

  [Header ("Canvas")]
    public Canvas c_wrongAnswer;
    public Canvas c_goodAnswer;
    public Canvas c_newAngle;
    public Canvas c_upToYou;
    public Canvas c_goodAnswerNA;
    public Canvas c_wrongAnswerNA;
    public Canvas c_firstquestions;

    [Header("Button Colliders")]
    public GameObject b_answer;
    public GameObject b_answerNA;
    public GameObject b_goToNewAngle;
    public GameObject b_goToNewAngleFree;
    public GameObject b_AButtonCollider;
    public GameObject b_BButtonCollider;
    public GameObject b_CButtonCollider;
    public GameObject b_DButtonCollider;
    public GameObject b_AButtonColliderNA;
    public GameObject b_BButtonColliderNA;
    public GameObject b_CButtonColliderNA;
    public GameObject b_DButtonColliderNA;

    [Header("DoseMaps")]
    public SpriteRenderer s_doseMap_0_0;
    public SpriteRenderer s_doseMap_min30_min30;
    public SpriteRenderer s_doseMap_60_30;

    public GameObject anesthesiste;
    public Transform newPosition;
    GameObject patientTable;
    public GameObject initialPosition;

    //ANIMATION C ARM
    [Header("Aniamtion")]
    public Animator animRotationCarm;
    public Animator animJointCarm;
    public Animator animSurgeonHands;

    bool isRotation;

    private void Start()
    {
        c_goodAnswer.gameObject.SetActive(false);
        c_wrongAnswer.gameObject.SetActive(false);
        c_newAngle.gameObject.SetActive(false);
        c_upToYou.gameObject.SetActive(false);
        c_goodAnswerNA.gameObject.SetActive(false);
        c_wrongAnswerNA.gameObject.SetActive(false);
        c_firstquestions.gameObject.SetActive(true);

        b_AButtonCollider.SetActive(true);
        b_BButtonCollider.SetActive(true);
        b_CButtonCollider.SetActive(true);
        b_DButtonCollider.SetActive(true);
        b_answer.SetActive(false);
        b_answerNA.SetActive(false);
        b_goToNewAngle.SetActive(false);
        b_goToNewAngleFree.SetActive(false);
        b_AButtonColliderNA.SetActive(false);
        b_BButtonColliderNA.SetActive(false);
        b_CButtonColliderNA.SetActive(false);
        b_DButtonColliderNA.SetActive(false);

        s_doseMap_0_0.gameObject.SetActive(false);
        s_doseMap_60_30.gameObject.SetActive(false);
        s_doseMap_min30_min30.gameObject.SetActive(false);

        patientTable = GameObject.FindGameObjectWithTag("Table");

        isRotation = false;
    }

    private void Update()
    {
       /* OVRInput.Update();

        if (OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("OOOOOOOOOOOOKKKKKKKKKKKKK");
            isRotation = true;

        }
        Debug.Log("isRotation in update method");
        Debug.Log(isRotation);*/

    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Hands")
        {
            Debug.Log("NAME :");
            Debug.Log(name);
            switch (name)
            {
                // TO DO : ajouter les dose maps pour les réponses
                case "AButton Collider":
                    c_firstquestions.gameObject.SetActive(false);
                    /*b_BButtonCollider.SetActive(false);
                    b_CButtonCollider.SetActive(false);
                    b_DButtonCollider.SetActive(false);*/
                    c_wrongAnswer.gameObject.SetActive(true);
                    initDoseMap(s_doseMap_0_0);
                    StartCoroutine(Delay());
                    b_AButtonCollider.SetActive(false);
                    Destroy(b_BButtonCollider);
                    Destroy(b_CButtonCollider);
                    Destroy(b_DButtonCollider);
                    b_answer.SetActive(true);
                    
                    break;

                case "BButton Collider":
                    c_firstquestions.gameObject.SetActive(false);
                    //b_AButtonCollider.SetActive(false);
                    /*b_CButtonCollider.SetActive(false);
                    b_DButtonCollider.SetActive(false);*/
                    c_wrongAnswer.gameObject.SetActive(true);
                    initDoseMap(s_doseMap_0_0);
                    StartCoroutine(Delay());
                    b_BButtonCollider.SetActive(false);
                    Destroy(b_AButtonCollider);
                    Destroy(b_CButtonCollider);
                    Destroy(b_DButtonCollider);
                    b_answer.SetActive(true);
                    break;

                case "CButton Collider":
                    c_firstquestions.gameObject.SetActive(false);
                    /*b_AButtonCollider.SetActive(false);
                    b_BButtonCollider.SetActive(false);*/
                    //b_DButtonCollider.SetActive(false);
                    c_wrongAnswer.gameObject.SetActive(true);
                    initDoseMap(s_doseMap_0_0);
                    StartCoroutine(Delay());
                    b_CButtonCollider.SetActive(false);
                    Destroy(b_AButtonCollider);
                    Destroy(b_BButtonCollider);
                    Destroy(b_DButtonCollider);
                    b_answer.SetActive(true);
                    break;

                case "DButton Collider":
                    c_firstquestions.gameObject.SetActive(false);
                    /*b_AButtonCollider.SetActive(false);
                    b_BButtonCollider.SetActive(false);
                    b_CButtonCollider.SetActive(false);*/
                    c_goodAnswer.gameObject.SetActive(true);
                    initDoseMap(s_doseMap_0_0);
                    StartCoroutine(Delay());
                    b_DButtonCollider.SetActive(false);
                    Destroy(b_AButtonCollider);
                    Destroy(b_BButtonCollider);
                    Destroy(b_CButtonCollider);
                    b_answer.SetActive(true);
                    break;

                case "AnswerButtonCollider":
                    c_wrongAnswer.gameObject.SetActive(false);
                    //b_answer.SetActive(false);
                    Destroy(b_answer);
                    anesthesiste.transform.position = newPosition.position;
                    anesthesiste.transform.rotation = Quaternion.Euler(anesthesiste.transform.rotation.x, anesthesiste.transform.rotation.y - 180f, anesthesiste.transform.rotation.z);
                    StartCoroutine(Delay());
                   
                    s_doseMap_0_0.gameObject.SetActive(false);
                    anesthesiste.transform.position = initialPosition.transform.position;
                    anesthesiste.transform.rotation = Quaternion.Euler(initialPosition.transform.rotation.x, initialPosition.transform.rotation.y, initialPosition.transform.rotation.z);
                    StartCoroutine(Delay());
                    c_firstquestions.gameObject.SetActive(true);
                    b_AButtonColliderNA.SetActive(true);
                    b_BButtonColliderNA.SetActive(true);
                    b_CButtonColliderNA.SetActive(true);
                    b_DButtonColliderNA.SetActive(true);
                    animSurgeonHands.SetBool("isRotation", false);
                    AnimatorExecute(1);
                    //Debug.Log(isRotation_min30_min30);
                    c_newAngle.gameObject.SetActive(true);
                    b_goToNewAngle.SetActive(true);
                    StartCoroutine(Delay());
                    break;

                    
              /*  case "NewAngleButtonCollider":
                    StartCoroutine(Delay());
                    c_newAngle.gameObject.SetActive(false);
                    //b_goToNewAngle.SetActive(false);
                    Destroy(b_goToNewAngle);


                    break;*/

               case "AButton Collider NA":
                    StartCoroutine(Delay());
                    c_firstquestions.gameObject.SetActive(false);
                    b_AButtonColliderNA.SetActive(false);
                    /* b_BButtonColliderNA.SetActive(false);
                     b_CButtonColliderNA.SetActive(false);
                     b_DButtonColliderNA.SetActive(false);*/
                    Destroy(b_BButtonColliderNA);
                    Destroy(b_CButtonColliderNA);
                    Destroy(b_DButtonColliderNA);
                    c_wrongAnswerNA.gameObject.SetActive(true);
                    initDoseMap(s_doseMap_min30_min30);
                    StartCoroutine(Delay());
                    b_answerNA.SetActive(true);

                    break;

                case "BButton Collider NA":
                    c_firstquestions.gameObject.SetActive(false);
                    //b_AButtonColliderNA.SetActive(false);
                    b_BButtonColliderNA.SetActive(false);
                    /*b_CButtonColliderNA.SetActive(false);
                    b_DButtonColliderNA.SetActive(false);*/
                    Destroy(b_AButtonColliderNA);
                    Destroy(b_CButtonColliderNA);
                    Destroy(b_DButtonColliderNA);
                    c_goodAnswerNA.gameObject.SetActive(true);
                    initDoseMap(s_doseMap_min30_min30);
                    StartCoroutine(Delay());
                    b_answerNA.SetActive(true);
                    StartCoroutine(Delay());
                    break;

                case "CButton Collider NA":
                    c_firstquestions.gameObject.SetActive(false);
                    /*b_AButtonColliderNA.SetActive(false);
                    b_BButtonColliderNA.SetActive(false);*/
                    b_CButtonColliderNA.SetActive(false);
                    //b_DButtonColliderNA.SetActive(false);
                    Destroy(b_AButtonColliderNA);
                    Destroy(b_BButtonColliderNA);
                    Destroy(b_DButtonCollider);
                    c_wrongAnswerNA.gameObject.SetActive(true);
                    initDoseMap(s_doseMap_min30_min30);
                    StartCoroutine(Delay());
                    b_answerNA.SetActive(true);
                    StartCoroutine(Delay());
                    break;

                case "DButton Collider NA":
                    c_firstquestions.gameObject.SetActive(false);
                    /*b_AButtonColliderNA.SetActive(false);
                    b_BButtonColliderNA.SetActive(false);
                    b_CButtonColliderNA.SetActive(false);
                    b_DButtonColliderNA.SetActive(false);*/
                    Destroy(b_AButtonColliderNA);
                    Destroy(b_BButtonColliderNA);
                    Destroy(b_CButtonColliderNA);
                    c_wrongAnswerNA.gameObject.SetActive(true);
                    initDoseMap(s_doseMap_min30_min30);
                    //StartCoroutine(Delay());
                    b_answerNA.SetActive(true);
                    StartCoroutine(Delay());
                    break;

                case "AnswerButtonCollider NA":
                    c_wrongAnswer.gameObject.SetActive(false);
                    c_goodAnswer.gameObject.SetActive(false);
                    //b_answerNA.SetActive(false);
                    Destroy(b_answerNA);
                    anesthesiste.transform.position = newPosition.position;
                    anesthesiste.transform.rotation = Quaternion.Euler(anesthesiste.transform.rotation.x, anesthesiste.transform.rotation.y - 180f, anesthesiste.transform.rotation.z);
                    StartCoroutine(Delay());
                    c_upToYou.gameObject.SetActive(true);
                    b_goToNewAngleFree.SetActive(true);
                    animRotationCarm.SetBool("isRotationFinished", true);
                    animJointCarm.SetBool("isRotationFinished", true);
                    animSurgeonHands.SetBool("isRotationFinished", true);
                    break;



                case "NewAngleButtonCollider Free":
                    StartCoroutine(Delay());
                    c_newAngle.gameObject.SetActive(false);
                    b_goToNewAngle.SetActive(false);
                    s_doseMap_min30_min30.gameObject.SetActive(false);
                    anesthesiste.transform.position = initialPosition.transform.position;
                    anesthesiste.transform.rotation = Quaternion.Euler(initialPosition.transform.rotation.x, initialPosition.transform.rotation.y, initialPosition.transform.rotation.z);
                    c_upToYou.gameObject.SetActive(true);
                    animSurgeonHands.SetBool("isRotation", false);
                    AnimatorExecute(2);
                    break;
            }
        }

        
    }

   public void initDoseMap(SpriteRenderer doseMap)
        {
            doseMap.gameObject.SetActive(true);
            doseMap.gameObject.transform.SetPositionAndRotation(new Vector3(patientTable.transform.position.x, patientTable.transform.position.y, patientTable.transform.position.z), Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z));
            doseMap.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);
        }



    public void AnimatorExecute(int index)
    {
        animJointCarm.SetInteger("index", index);
        animRotationCarm.SetInteger("index", index);
        animSurgeonHands.SetInteger("index", index);

        animRotationCarm.SetBool("isRotationFinished", false);
        animJointCarm.SetBool("isRotationFinished", false);
        animSurgeonHands.SetBool("isRotationFinished", false);


    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(30);
        //Debug.Log("Something");
    }
}

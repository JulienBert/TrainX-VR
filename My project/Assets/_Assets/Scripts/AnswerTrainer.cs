using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// This script correspond to the action between the leraner and the trainer when the player in VR is in the operating room. It allows the action of the trainer in desktop mode to control the advance of the training.
/// </summary>
    
public class AnswerTrainer : MonoBehaviourPunCallbacks
{

    
    public Canvas[] allCanvas;
    /*allCanvas = [ c_playerview_questions_pos,    0
                    c_trainerview_questions_pos,   1
                    c_playerview_goodAnswer,       2
                    c_trainerview_goodAnswer,      3
                    c_playerview_wrongAnswer,      4
                    c_trainerview_wrongAnswerbis,  5
                    c_playerview_questions_exp,    6
                    c_trainerview_questions_exp,   7
                    c_playerview_info,             8
                    c_trainerview_infobis,         9
                    c_playerview_infoNA,           10
                    c_trainerview_infoNAbis,       11
                    c_playerview_bestway,          12
                    c_trainerview_bestwaybis,      13
                    c_playerview_uptoyou,          14
                    c_trainerview_uptoyoubis,      15
                    c_playerview_newAngle,         16
                    c_trainerview_newAnglebis]     17 */



    public SpriteRenderer[] doseMap;
    //doseMap = [p_1_0_0_100_0_0_0_world_edep.mhd_dosemapmipfilter,   0
    //p_1_-30_-30_100_0_0_0_world_edep.mhd_dosemapmipfilter,          1
    //p_1_60_0_100_0_0_0_world_edep.mhd_dosemapmipfilter,             2
    //p_1_60_30_100_0_0_0_world_edep.mhd_dosemapmipfilter,            3
    //p_1_0_30_100_0_0_0_world_edep.mhd_dosemapmipfilter,             4
    //p_1_0_-30_100_0_0_0_world_edep.mhd_dosemapmipfilter,            5
    //p_1_60_-30_100_0_0_0_world_edep.mhd_dosemapmipfilter]           6


    public GameObject anesthesiste;
    public Transform newPosition;
    GameObject patientTable;
    public GameObject initialPosition;
    public GameObject monitorPosition;

    //ANIMATION C ARM
    [Header("Animation")]
    public Animator animRotationCarm;
    public Animator animJointCarm;
    public Animator animSurgeonHands;
    public Animator animAnesthesiste;

    bool isAngle_0_0;
    bool isAngle_min30_min30;
    bool isAngle_60_30;
    bool isAngle_60_min30;
    bool isCharacterOK;
    bool isAngle_0_min30;
    bool isAngle_0_30;
    bool isAngle_60_0;
    bool isNoMoreRotation;
    bool isFirstQuestionOK;
    bool isFirstQuestionOKNA;

    private PhotonView pv;
    Vector3 doseMapPos;
    Quaternion doseMapRot;
    Vector3 doseMapScale;

    private void Start()
    {
        // Photon view to help in the synchronization
        pv = GetComponent<PhotonView>();

        // Initialisation of th canvas list
        for (int i = 0; i < allCanvas.Length; i++) allCanvas[i].gameObject.SetActive(false);
        allCanvas[0].gameObject.SetActive(true);
        allCanvas[1].gameObject.SetActive(true);

        // Reference position for the dosemap
        patientTable = GameObject.FindGameObjectWithTag("Table");

        // Initialisation of the boolean value used in the script
        isAngle_0_0 = false;
        isAngle_min30_min30 = false;
        isAngle_60_30 = false;
        isCharacterOK = false;
        isAngle_60_min30 = false;
        isAngle_0_min30 = false;
        isAngle_0_30 = false;
        isAngle_60_0 = false;
        isNoMoreRotation = false;
        isFirstQuestionOK = false;
        isFirstQuestionOKNA = false;


        // Initialisation if the dosemap list
        for (int i = 0; i < doseMap.Length; i++) doseMap[i].gameObject.SetActive(false);

        //doseMapPos = new Vector3(patientTable.transform.position.x, patientTable.transform.position.y, patientTable.transform.position.z);
        doseMapPos = new Vector3(patientTable.transform.position.x, patientTable.transform.position.y+0.02f, patientTable.transform.position.z);
        doseMapRot = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y +180.0f, patientTable.transform.rotation.z);
        doseMapScale = new Vector3(1.8f, 1.8f, 1.0f);

    }

    private void Update()
    {

        if (pv.IsMine) ProcessInput();

    }
    public void ProcessInput()
    {
        /////////////////////////////////////FIRST STEP OF THE TRAINING : SAY IF THE STAFF IS IN A GOOD POSITION//////////////////////////////////////////////
        
        //Answer A
        if (Input.GetKeyDown(KeyCode.A))
        {
            // First angle 0 0
            if (!isAngle_0_0)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); //c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 4, true); //c_playerview_wrongAnswer
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 5, true); //c_trainerview_wrongAnswer

                pv.RPC("InitDoseMap", RpcTarget.All, 0, doseMapPos, doseMapRot, doseMapScale);// dosemap 0 0
            }

            // Third angle 60 0
            else if (isFirstQuestionOKNA)
            {
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, false); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, false); //c_trainerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 10, true); //c_playerview_info_thirdangle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 11, true); //c_trainerview_info_thirdangle

                pv.RPC("InitDoseMap", RpcTarget.All, 2, doseMapPos, doseMapRot, doseMapScale); //dosemap 60 0 
                isFirstQuestionOKNA = false;
            }



            else if(isAngle_min30_min30)
           {
               pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
               pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); // c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, true); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, true); //c_trainerview_questions_exp

                isFirstQuestionOKNA = true;
           }

            

            // Second angle -30 -30

            else if (isFirstQuestionOK)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, false); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, false); //c_trainerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 8, true); //c_playerview_info
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 9, true); //c_trainerview_info

                pv.RPC("InitDoseMap", RpcTarget.All, 1, doseMapPos, doseMapRot, doseMapScale); //dose map -30 -30
                isFirstQuestionOK = false;
            }



            else
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); //c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, true); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, true); //c_trainerview_questions_exp

                isFirstQuestionOK = true;
            }



        }

        // Answer B
        if (Input.GetKeyDown(KeyCode.B))
        {

            // First angle 0 0
            if (!isAngle_0_0)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); // c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 4, true); //c_playerview_wrongAnswer
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 5, true); //c_trainerview_wrongAnswer

                pv.RPC("InitDoseMap", RpcTarget.All, 0, doseMapPos, doseMapRot, doseMapScale); //dosemap 0 0

            }

            // Third angle 60 0
            

            else if (isFirstQuestionOKNA)
            {
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, false); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, false); //c_trainerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 10, true); //c_playerview_info_NA
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 11, true); //c_trainerview_info_NA

                pv.RPC("InitDoseMap", RpcTarget.All, 2, doseMapPos, doseMapRot, doseMapScale); //dosemap 60 0
                isFirstQuestionOKNA = false;
            }

            else if (isAngle_min30_min30)
            {
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); // c_trainerview_questionsbis_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, true); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, true); //c_trainerview_questionsbis_exp

                isFirstQuestionOKNA = true;
            }
            // Second angle -30 -30
            else if (isFirstQuestionOK)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, false); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, false); //c_trainerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 8, true); //c_playerview_info
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 9, true); //c_trainerview_info

                pv.RPC("InitDoseMap", RpcTarget.All, 1, doseMapPos, doseMapRot, doseMapScale); //dosemap -30 -30
                isFirstQuestionOK = false;
            }

            else
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); //c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, true); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, true); //c_trainerview_questions_exp
                isFirstQuestionOK = true;
            }
        


        }

        // Answer C
        if (Input.GetKeyDown(KeyCode.C))
        {
            // First angle 0 0
            if (!isAngle_0_0)
            {
   
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); //c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 4, true); //c_playerview_wrongAnswer
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 5, true); //c_trainerview_wrongAnswer

                pv.RPC("InitDoseMap", RpcTarget.All, 0, doseMapPos, doseMapRot, doseMapScale); //dosemap 0 0
            }

            // Third angle 60 0
            

            else if (isFirstQuestionOKNA)
            {
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, false); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, false); //c_trainerview_questionsbis_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 10, true); //c_playerview_info_thirdangle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 11, true); //c_trainerview_info_thirdangle

                pv.RPC("InitDoseMap", RpcTarget.All, 2, doseMapPos, doseMapRot, doseMapScale); //dosemap 60 0
                isFirstQuestionOKNA = false;
            }

            else if (isAngle_min30_min30)
            {
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); // c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, true); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, true); //c_trainerview_questions_exp

                isFirstQuestionOKNA = true;
            }

            // Second angle -30 -30
            else if (isFirstQuestionOK)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, false); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, false); //c_trainerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 8, true); //c_playerview_info
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 9, true); //c_trainerview_info

                pv.RPC("InitDoseMap", RpcTarget.All, 1, doseMapPos, doseMapRot, doseMapScale);// dose map -30 -30
                isFirstQuestionOK = false;
            }

             else
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); //c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, true); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, true); //c_trainerview_questions_exp

                isFirstQuestionOK = true;
            }


        }

        // Answer D
        if (Input.GetKeyDown(KeyCode.D))
        {
            // First angle 0 0
            if (!isAngle_0_0)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); //c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 2, true); //c_playerview_goodAnswer
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 3, true); //c_trainerview_goodAnswer

                pv.RPC("InitDoseMap", RpcTarget.All, 0, doseMapPos, doseMapRot, doseMapScale); // dose map 0 0
            }

            // Third angle 60 0
            

            else if (isFirstQuestionOKNA)
            {
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, false); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, false); //c_trainerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 10, true); //c_playerview_info_thirdangle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 11, true); //c_trainerview_infobis_thirdangle

                pv.RPC("InitDoseMap", RpcTarget.All, 2, doseMapPos, doseMapRot, doseMapScale); //dosemap 60 0
                isFirstQuestionOKNA = false;
            }

            else if (isAngle_min30_min30)
            {
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); // c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, true); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, true); //c_trainerview_questions_exp

                isFirstQuestionOKNA = true;
            }
            // Second angle -30 -30
            else if (isFirstQuestionOK)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, false); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, false); //c_trainerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 8, true); //c_playerview_info
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 9, true); //c_trainerview_info

                pv.RPC("InitDoseMap", RpcTarget.All, 1, doseMapPos, doseMapRot, doseMapScale); //dose map -30 -30
                isFirstQuestionOK = false;
            }

            else
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, false); //c_playerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, false); //c_trainerview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 6, true); //c_playerview_questions_exp
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 7, true); //c_trainerview_questions_exp

                isFirstQuestionOK = true;
            }

        }

        // First validation of the trainer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Change the C-arm at the initial position 0 0
            if (isNoMoreRotation)
            {
                animRotationCarm.SetBool("isRotationFinished", true);
                animJointCarm.SetBool("isRotationFinished", true);
                animSurgeonHands.SetBool("isRotationFinished", true);
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 16, true); //c_playerview_newAngle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 17, true); //c_trainerview_newAngle
            }

            // First angle 0 0
            else if (!isAngle_0_0)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 4, false); //c_playerview_wrongAnswer
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 5, false); //c_trainerview_wrongAnswer
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 2, false); //c_playerview_goodAnswer
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 3, false); //c_trainerview_goodAnswer
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 16, true); //c_playerview_newAngle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 17, true); //c_trainerview_newAngle

                animAnesthesiste.SetBool("isFarFromPatient", true);
                anesthesiste.transform.SetPositionAndRotation(newPosition.position, Quaternion.Euler(anesthesiste.transform.rotation.x, anesthesiste.transform.rotation.y - 180f, anesthesiste.transform.rotation.z));
                isAngle_0_0 = true;

            }

            /////////////////////////////////////////SECOND STEP : FIND THE BEST WAY TO GO NEXT TO THE PATIENT///////////////////////////////////////////////

            //Fifth angle 60 30
            else if (isAngle_60_30)
            {
                
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 12, false); //c_playerview_bestway
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 13, false); //c_trainerview_bestway
                
                pv.RPC("InitDoseMap", RpcTarget.All, 3, doseMapPos, doseMapRot, doseMapScale);

                
                isNoMoreRotation = true;

            }

            // Sixth angle 0 30
            else if (isAngle_0_30)
            {
                
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 12, false); //c_playerview_bestway
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 13, false); //c_trainerview_bestway

                pv.RPC("InitDoseMap", RpcTarget.All, 4, doseMapPos, doseMapRot, doseMapScale);

                isNoMoreRotation = true;

            }

            // Fourth angle 0 -30
            else if (isAngle_0_min30)
            {
                
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 12, false); //c_playerview_bestway
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 13, false); //c_trainerview_bestway

                pv.RPC("InitDoseMap", RpcTarget.All, 5, doseMapPos, doseMapRot, doseMapScale);

                isNoMoreRotation = true;

            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Third angle 60 0
            else if (isAngle_min30_min30)
            {

  
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 10, false); //c_playerview_info_NA
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 11, false); //c_trainerview_info_NA


               isNoMoreRotation = true;
                
            }

            // Second angle -30 -30
            else
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 8, false); //c_playerview_info
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 9, false); //c_trainerview_info

                animAnesthesiste.SetBool("isFarFromPatient", true);
                anesthesiste.transform.SetPositionAndRotation(newPosition.position, Quaternion.Euler(anesthesiste.transform.rotation.x, anesthesiste.transform.rotation.y - 180f, anesthesiste.transform.rotation.z));

                isAngle_min30_min30 = true;
                isNoMoreRotation = true;
            }

            

        }

        // Second validtion for the trainer to go to the next step
        if (Input.GetKeyDown(KeyCode.Return))
        {

            //Second angle -30 -30
            if (!isAngle_min30_min30)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 16, false); //c_playerview_newAngle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 17, false); //c_trainerview_newAngle
                pv.RPC("DoseMapDisappear", RpcTarget.All, 0); // dosemap 0 0
                
                
                anesthesiste.transform.SetPositionAndRotation(initialPosition.transform.position, Quaternion.Euler(initialPosition.transform.rotation.x, initialPosition.transform.rotation.y, initialPosition.transform.rotation.z));
                animAnesthesiste.SetBool("isFarFromPatient", false);

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, true); //c_playeview_questions_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, true); //c_trainerview_questions_pos

                animSurgeonHands.SetBool("isRotation", false);
                AnimatorExecute(1);
                isNoMoreRotation = false;

            }
            /////////////////////////////////LAST STEP : MOVE IN THE ROOM///////////////////////////////////////////////////

            // Last angle 60 -30
            else if (isAngle_0_min30)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 16, false); //c_playerview_newAngle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 17, false); //c_trainerview_newAngle

                pv.RPC("DoseMapDisappear", RpcTarget.All, 5); // dosemap 0 -30


                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 14, true); //c_playerview_upToYou
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 15, true); //c_trainerview_upToYou

                animSurgeonHands.SetBool("isRotation", false);
                AnimatorExecute(6);
                isNoMoreRotation = false;
                isAngle_60_min30 = true;
                isAngle_0_min30 = false;
            }

            // Last angle 60 -30
            else if (isAngle_60_min30)
            {
            

                pv.RPC("DoseMapDisappear", RpcTarget.All, 0); // dosemap 0 0
                pv.RPC("DoseMapDisappear", RpcTarget.All, 1); // dosemap -30 -30
                pv.RPC("DoseMapDisappear", RpcTarget.All, 2); //dosemap 60 0
                pv.RPC("DoseMapDisappear", RpcTarget.All, 3); //dosemap 60 30
                isCharacterOK = true;
                isNoMoreRotation = false;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Fifth angle 0 30
            else if(isAngle_60_30)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 16, false); //c_playerview_newAngle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 17, false); //c_trainerview_newAngle
                pv.RPC("DoseMapDisappear", RpcTarget.All, 3); // dosemap 60 30
           
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 12, true); //c_playerview_bestway
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 13, true); //c_trainerview_bestway

                animSurgeonHands.SetBool("isRotation", false);
                AnimatorExecute(4);
                isNoMoreRotation = false;
                isAngle_0_30 = true;
                isAngle_60_30 = false;
              
            }

            //Sixth angle 0 -30
            else if (isAngle_0_30)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 16, false); //c_playerview_newAngle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 17, false); //c_trainerview_newAngle
                pv.RPC("DoseMapDisappear", RpcTarget.All, 4); // dosemap 0 30

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 12, true); //c_playerview_bestway
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 13, true); //c_trainerview_bestway

                animSurgeonHands.SetBool("isRotation", false);
                AnimatorExecute(5);
                isNoMoreRotation = false;
                isAngle_0_min30 = true;
                isAngle_0_30 = false;
            }

            //Fourth angle 60 30
            else if (isAngle_60_0)
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 16, false); //c_playerview_newAngle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 17, false); //c_trainerview_newAngle
                pv.RPC("DoseMapDisappear", RpcTarget.All, 2); // dosemap 60 0


                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 12, true); //c_playerview_bestway
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 13, true); //c_trainerview_bestway

                animSurgeonHands.SetBool("isRotation", false);
                AnimatorExecute(3);
                isNoMoreRotation = false;
                isAngle_60_30 = true;
            }

            //Third angle 60 0
            else
            {

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 16, false); //c_playerview_newAngle
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 17, false); //c_trainerview_newAngle
                
                pv.RPC("DoseMapDisappear", RpcTarget.All, 1); // dosemap -30 -30

                anesthesiste.transform.SetPositionAndRotation(monitorPosition.transform.position, Quaternion.Euler(monitorPosition.transform.rotation.x, monitorPosition.transform.rotation.y, monitorPosition.transform.rotation.z));
                animAnesthesiste.SetBool("isFarFromPatient", true);

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 0, true); //c_playerview_question_pos
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 1, true); //c_trainerview_quetions_pos

                animSurgeonHands.SetBool("isRotation", false);
                AnimatorExecute(2);
                isNoMoreRotation = false;
                isAngle_60_0 = true;
            }

            if (isCharacterOK)
            {
                pv.RPC("InitDoseMap", RpcTarget.All, 6, doseMapPos, doseMapRot, doseMapScale); //dosemap 60 -30

                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 14, false); //c_playerview_upToYou
                pv.RPC("CanvasAppearOrNot", RpcTarget.All, 15, false); //c_trainerview_upToYou
            }

        }
    }

    /// <summary>
    /// This method allow the synchronisation of the dosemap apparition
    /// </summary>
    /// <param name="index"></param> : number of the dosemap
    /// <param name="position"></param> : dosemap position in the scene 
    /// <param name="rotation"></param> : dosemap rotation in the scene
    /// <param name="scale"></param> : dosemap scale
    /// <param name="info"></param> : not useful here
    [PunRPC]
    public void InitDoseMap(int index, Vector3 position, Quaternion rotation, Vector3 scale, PhotonMessageInfo info)
    {
    
        doseMap[index].gameObject.SetActive(true);
        doseMap[index].gameObject.transform.SetPositionAndRotation(position, rotation);
        doseMap[index].gameObject.transform.localScale = scale;
        
    }

    /// <summary>
    /// This method allow the synchronisation of the dosemap disappear
    /// </summary>
    /// <param name="index"></param> : number of the dosemap
    /// <param name="info"></param> : not useful here
    [PunRPC]
    public void DoseMapDisappear(int index, PhotonMessageInfo info)
    {
        doseMap[index].gameObject.SetActive(false);
    }

    /// <summary>
    /// This method allow the synchronisation of the canvas apparition for the questions
    /// </summary>
    /// <param name="index"></param> : number of the canvas
    /// <param name="isAppear"></param> : boolean value to notice if it is already appeared in the scene
    /// <param name="info"></param> : not useful here
    [PunRPC]
    public void CanvasAppearOrNot(int index, bool isAppear, PhotonMessageInfo info)
    {
        if(isAppear) allCanvas[index].gameObject.SetActive(true);
        
        else allCanvas[index].gameObject.SetActive(false);

    }

    /// <summary>
    /// This method allows the execution of the animation of th surgeon and the c-arm
    /// </summary>
    /// <param name="index"></param> : number of rotation
    public void AnimatorExecute(int index)
    {

        animSurgeonHands.SetInteger("index", index);
        animJointCarm.SetInteger("index", index);
        animRotationCarm.SetInteger("index", index);
        

        animRotationCarm.SetBool("isRotationFinished", false);
        animJointCarm.SetBool("isRotationFinished", false);
        animSurgeonHands.SetBool("isRotationFinished", false);
        

    }




}

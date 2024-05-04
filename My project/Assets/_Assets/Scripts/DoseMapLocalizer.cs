using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script allows the appearition of the dosemap
/// ATTENTION : not use in the multiplayer scenario
/// </summary>
public class DoseMapLocalizer : MonoBehaviour
{

    [Header("DoseMap")]
    public SpriteRenderer m_spriteRenderer_0_0;
    public SpriteRenderer m_spriteRenderer_min30_0;
    public SpriteRenderer m_spriteRenderer_90_0;
    public SpriteRenderer m_spriteRenderer_0_30;
    public SpriteRenderer m_spriteRenderer_0_min30;
    public SpriteRenderer m_spriteRenderer_min30_min30;
    public SpriteRenderer m_spriteRenderer_30_min30;
    public SpriteRenderer m_spriteRenderer_60_min30;
    public SpriteRenderer m_spriteRenderer_60_0;
    public SpriteRenderer m_spriteRenderer_60_30;
    //public SpriteRenderer m_spriteRenderer_vertical;
    //public SpriteRenderer m_spriteRenderer_vertical2;

    GameObject patientTable;
    GameObject carm;
    
    [Header("Canvas to confirm player placement")]
    //public Canvas confirmChoice;

    [Space]
    public static bool isDoseMap;

    [Header("Colliders to locate the wrong place")]
    public GameObject collider_0_0;
    public GameObject collider_min30_0;
    public GameObject collider_90_0;
    public GameObject collider_0_30;
    public GameObject collider_0_min30;
    public GameObject collider_min30_min30;
    public GameObject collider_30_min30;
    public GameObject collider_60_min30;
    public GameObject collider_60_0;
    public GameObject collider_60_30;


    [Header("Animators")]
    public Animator animRotationCarm;
    public Animator animHandSurgeon;
    public Animator animHeadWoman;
    public Animator animJointCarm;


    private void Start()
    {

        patientTable = GameObject.FindGameObjectWithTag("Table");
        carm = GameObject.FindGameObjectWithTag("Carm");
        //confirmChoice.GetComponent<Canvas>();

        isDoseMap = false;

        InitDoseMap();
      
    }

    private void Update()
    {
        

        OVRInput.Update();
        
        if (CheckPosition.isInOperatingRoomSquare && OVRInput.Get(OVRInput.Button.One) && DisableHaloGreen.isInGreenHalo)
        {
            DoseMapGenerator();
            //confirmChoice.gameObject.SetActive(false);
            isDoseMap = true;

        }

        if (CheckPosition.isInOperatingRoomSquare && OVRInput.Get(OVRInput.Button.Two) && DisableHaloGreen.isInGreenHalo)
        {
            InitDoseMap();
        }

        if (CheckPosition.isInOperatingRoomSquare && OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && DisableHaloGreen.isInGreenHalo)
        {
            
            int randomIntegerbis = DisableHaloGreen.randomInteger;
            int randomIntegerter = Random.Range(0, 10);

            if (randomIntegerbis == randomIntegerter)
            {
                randomIntegerter++;
                if (randomIntegerbis==9)
                {
                    randomIntegerter = 1;
                }
            }
            

            AnimatorExecute(randomIntegerter);
     
            DoseMapPosition.isEnded = false;
            //confirmChoice.gameObject.SetActive(true);
        }

     
    }

    void DoseMapGenerator()
    {
        
        //Plan Y

        float diffQuat0_0 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(0f, -0.7f, -0.7f, 0f)));
        float diffQuatmin30_0 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(-0.2f, -0.7f, -0.7f, -0.2f)));
        float diffQuat90_0 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(0.5f, -0.5f, -0.5f, 0.5f)));
        float diffQuat0_30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(0f, -0.9f, -0.5f, 0f)));
        float diffQuat0_min30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(0f, -0.5f, -0.9f, 0f)));
        float diffQuatmin30_min30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(-0.1f, -0.8f, -0.6f, -0.2f)));
        float diffQuat30_min30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(0.2f, -0.6f, -0.8f, 0.1f)));
        float diffQuat60_min30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(0.4f, -0.5f, -0.8f, 0.3f)));
        float diffQuat60_0 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(0.4f, -0.6f, -0.6f, 0.4f)));
        float diffQuat60_30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, new Quaternion(0.3f, -0.8f, -0.5f, 0.4f)));

        float diffEuler0_0 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f)));
        float diffEulermin30_0 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(-119.98f, 90f, -90f)));
        float diffEuler90_0 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(0.02f, 90f, -90f)));
        float diffEuler0_30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(-59.98f, 0f, 0f)));
        float diffEuler0_min30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(-119.98f, 0f, 0f)));
        float diffEulermin30_min30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(-119.98f, 110f, -120f)));
        float diffEuler30_min30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(-59.98f, 110f, -120f)));
        float diffEuler60_min30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(-29.98f, 110f, -120f)));
        float diffEuler60_0 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(-29.98f, 90f, -90f)));
        float diffEuler60_30 = Mathf.Abs(Quaternion.Dot(carm.transform.rotation, Quaternion.Euler(-29.98f, 70f, -60f)));

        float[] diffQuat = new float[10];
        diffQuat[0] = diffQuat0_0;
        diffQuat[1] = diffQuatmin30_0;
        diffQuat[2] = diffQuat90_0;
        diffQuat[3] = diffQuat0_30;
        diffQuat[4] = diffQuat0_min30;
        diffQuat[5] = diffQuatmin30_min30;
        diffQuat[6] = diffQuat30_min30;
        diffQuat[7] = diffQuat60_min30;
        diffQuat[8] = diffQuat60_0;
        diffQuat[9] = diffQuat60_30;

        float[] diffEuler = new float[10];
        diffEuler[0] = diffEuler0_0;
        diffEuler[1] = diffEulermin30_0;
        diffEuler[2] = diffEuler90_0;
        diffEuler[3] = diffEuler0_30;
        diffEuler[4] = diffEuler0_min30;
        diffEuler[5] = diffEulermin30_min30;
        diffEuler[6] = diffEuler30_min30;
        diffEuler[7] = diffEuler60_min30;
        diffEuler[8] = diffEuler60_0;
        diffEuler[9] = diffEuler60_30;

        float[] diffMin;
        int indexMin = 0;
        float tamp = 5;
        int tampIndex = 0;

        diffMin = System.Array.FindAll<float>(diffQuat, e => e >= 1);
        if (diffMin.Length > 1)
        {
            for (int i = 0; i < diffMin.Length; i++)
            {
                indexMin = System.Array.FindIndex<float>(diffQuat, e => e == diffMin[i]);
                if (tamp > diffEuler[indexMin])
                {
                    tamp = diffEuler[indexMin];
                    tampIndex = indexMin;
                }
            }

            indexMin = tampIndex;
 
        }

        else if (diffMin.Length == 0)
        {
            for (int i = 0; i < diffEuler.Length; i++)
            {
                if (tamp > diffEuler[i])
                {
                    tamp = diffEuler[i];
                    tampIndex = i;

                }
            }

            indexMin = tampIndex;
        }
        else indexMin = System.Array.FindIndex<float>(diffQuat, e => e == diffMin[0]);
        
        switch (indexMin)
        {
            case 0:
                Debug.Log("IF 0 0");
                m_spriteRenderer_0_0.gameObject.SetActive(true);
                collider_0_0.SetActive(true);
                m_spriteRenderer_0_0.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_0_0.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z); 
                m_spriteRenderer_0_0.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);

                break;

            case 1:
                Debug.Log("IF -30 0");
                m_spriteRenderer_min30_0.gameObject.SetActive(true);
                collider_min30_0.SetActive(true);
                m_spriteRenderer_min30_0.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_min30_0.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z); 
                m_spriteRenderer_min30_0.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);

                break;

            case 2:
                Debug.Log("IF 90 0");
                m_spriteRenderer_90_0.gameObject.SetActive(true);
                collider_90_0.SetActive(true);
                m_spriteRenderer_90_0.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_90_0.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z); 
                m_spriteRenderer_90_0.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);


                break;

            case 3:
                Debug.Log("IF 0 30");
                m_spriteRenderer_0_30.gameObject.SetActive(true);
                collider_0_30.SetActive(true);
                m_spriteRenderer_0_30.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_0_30.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z);
                m_spriteRenderer_0_30.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);
                break;


            case 4:
                Debug.Log("IF 0 -30");
                m_spriteRenderer_0_min30.gameObject.SetActive(true);
                collider_0_min30.SetActive(true);
                m_spriteRenderer_0_min30.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_0_min30.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z);
                m_spriteRenderer_0_min30.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);

                break;

            case 5:
                Debug.Log("IF -30 -30");
                m_spriteRenderer_min30_min30.gameObject.SetActive(true);
                collider_min30_min30.SetActive(true);
                m_spriteRenderer_min30_min30.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_min30_min30.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z);
                m_spriteRenderer_min30_min30.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);

                break;


            case 6:
                Debug.Log("IF 30 -30");
                m_spriteRenderer_30_min30.gameObject.SetActive(true);
                collider_30_min30.SetActive(true);
                m_spriteRenderer_30_min30.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_30_min30.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z);
                m_spriteRenderer_30_min30.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);

                break;



            case 7:
                Debug.Log("IF 60 -30");
                m_spriteRenderer_60_min30.gameObject.SetActive(true);
                collider_60_min30.SetActive(true);
                m_spriteRenderer_60_min30.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_60_min30.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z);
                m_spriteRenderer_60_min30.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);

                break;


            case 8:
                Debug.Log("IF 60 0");
                m_spriteRenderer_60_0.gameObject.SetActive(true);
                collider_60_0.SetActive(true);
                m_spriteRenderer_60_0.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_60_0.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z);
                m_spriteRenderer_60_0.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);


                break;


            case 9:
                Debug.Log("IF 60 30");
                m_spriteRenderer_60_30.gameObject.SetActive(true);
                collider_60_30.SetActive(true);
                m_spriteRenderer_60_30.gameObject.transform.position = new Vector3(patientTable.gameObject.transform.position.x, patientTable.gameObject.transform.position.y, patientTable.gameObject.transform.position.z);
                m_spriteRenderer_60_30.gameObject.transform.rotation = Quaternion.Euler(patientTable.transform.rotation.x + 90.0f, patientTable.transform.rotation.y, patientTable.transform.rotation.z);
                m_spriteRenderer_60_30.gameObject.transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);


                break;
        }
    }


    void InitDoseMap()
    {
        m_spriteRenderer_0_0.gameObject.SetActive(false);
        m_spriteRenderer_min30_0.gameObject.SetActive(false);
        m_spriteRenderer_90_0.gameObject.SetActive(false);
        m_spriteRenderer_0_30.gameObject.SetActive(false);
        m_spriteRenderer_0_min30.gameObject.SetActive(false);
        m_spriteRenderer_min30_min30.gameObject.SetActive(false);
        m_spriteRenderer_30_min30.gameObject.SetActive(false);
        m_spriteRenderer_60_min30.gameObject.SetActive(false);
        m_spriteRenderer_60_0.gameObject.SetActive(false);
        m_spriteRenderer_60_30.gameObject.SetActive(false);

        collider_0_0.SetActive(false);
        collider_min30_0.SetActive(false);
        collider_90_0.SetActive(false);
        collider_0_30.SetActive(false);
        collider_0_min30.SetActive(false);
        collider_min30_min30.SetActive(false);
        collider_30_min30.SetActive(false);
        collider_60_min30.SetActive(false);
        collider_60_0.SetActive(false);
        collider_60_30.SetActive(false);

    }

    public void AnimatorExecute(int randomInteger)
    {
        animHandSurgeon.SetBool("isRotation", true);
        animHandSurgeon.SetInteger("randomInteger", randomInteger);
        animJointCarm.SetInteger("randomInteger", randomInteger);
        animRotationCarm.SetInteger("randomInteger", randomInteger);
        animHeadWoman.SetInteger("randomInteger", randomInteger);
        
        animRotationCarm.SetBool("isRotationFinished", false);
        animJointCarm.SetBool("isRotationFinished", false);
        animHandSurgeon.SetBool("isRotationFinished", false);
        animHeadWoman.SetBool("isRotationFinished", false);
        
    }

}
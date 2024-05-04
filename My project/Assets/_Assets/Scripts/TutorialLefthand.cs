using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows the tutorial part for the teleportation with the left hand
/// ATTENTION : not use in the multiplayer scene
/// </summary>
public class TutorialLefthand : MonoBehaviour
{
    public GameObject teleportZone1;
    public GameObject teleportZone2;
    public GameObject teleportZone3;

    //public bool isTeleporting2OK;

    //TutorialRightHand rightHandLink;


    /*private void Start()
    {
        isTeleporting2OK = false;
    }*/
    public void DisableGameObject()
    {
        if (teleportZone1.active)
        {
            teleportZone1.SetActive(false);
            teleportZone2.SetActive(true);
        }
            
        
        if (!teleportZone1.active)
            teleportZone2.SetActive(false);

        if (!teleportZone2.active)
            teleportZone3.SetActive(false);
    }
}

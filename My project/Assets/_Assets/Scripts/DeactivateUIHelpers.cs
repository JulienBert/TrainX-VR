using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to desactivate the laser to interact with UI objects when we don't need it
/// ATTENTION : this script is nor used in the multiplayer scenario
/// </summary>
public class DeactivateUIHelpers : MonoBehaviour
{


    public GameObject laserUIHelpers;
    public GameObject sphereUIHelpers;
    public GameObject player;


    private void Update()
    {
        if (GetPlayerInsideArea(GameObject.Find("WelcomeZone").GetComponent<SphereCollider>().radius))
            {

            laserUIHelpers.SetActive(true);
            sphereUIHelpers.SetActive(true);
        }

        else
        {
            laserUIHelpers.SetActive(false);
            sphereUIHelpers.SetActive(false);
        }
    }

    bool GetPlayerInsideArea(float distance)
    {

        if ((Vector3.Distance(player.transform.position,GameObject.Find("WelcomeZone").transform.position)<distance) || (Vector3.Distance(player.transform.position, GameObject.Find("WelcomeZone").transform.position) == distance))
        {
            return true;
        }
        return false;
    }

}

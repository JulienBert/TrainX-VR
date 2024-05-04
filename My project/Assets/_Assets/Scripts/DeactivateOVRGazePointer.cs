using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script allows the activation of the gaze pointer when we use it in the interaction of the scene
/// ATTENTION : This script was used for the first VR scenario - not used for multiplayer version
/// </summary>
public class DeactivateOVRGazePointer : MonoBehaviour
{
    public GameObject gazeIcon;
    public GameObject player;


    private void Update()
    {
        if (GetPlayerInsideArea(GameObject.Find("WelcomeZone").GetComponent<SphereCollider>().radius))
        {

            gazeIcon.SetActive(true);
  
        }

        else
        {
            gazeIcon.SetActive(false);
     
        }
    }

    bool GetPlayerInsideArea(float distance)
    {

        if ((Vector3.Distance(player.transform.position, GameObject.Find("WelcomeZone").transform.position) < distance) || (Vector3.Distance(player.transform.position, GameObject.Find("WelcomeZone").transform.position) == distance))
        {
            return true;
        }
        return false;
    }
}

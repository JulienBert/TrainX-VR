using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

/// <summary>
/// This script checks is the player in in the area of the game of the operating room
/// ATTENTION : not used in the multiplayer scene
/// </summary>
public class CheckPosition : MonoBehaviour
{
    public static bool isInOperatingRoomSquare = false;

 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInOperatingRoomSquare = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInOperatingRoomSquare = false;
        }
    }


   
    
}

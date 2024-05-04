using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// The script allows to give gravity for objects the player hits with the right hand
/// ATTENTION : not use in the multiplayer scene
/// </summary>
public class TutorialRightHand : MonoBehaviour
{

    public Rigidbody cube;
    public Rigidbody cube1;
    public Rigidbody cube2;
    public Rigidbody cube3;
    public Rigidbody cube4;

    public void EnableGravity()
    {
        cube.useGravity = true;
        cube2.useGravity = true;
        cube3.useGravity = true;
        cube4.useGravity = true;
        cube1.useGravity = true;
    }


}

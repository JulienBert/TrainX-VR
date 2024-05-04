using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Track the hand for the input with OVR set up
/// ATTENTION : not use ine the multiplayer scenario
/// </summary>
public class HandTrackingUI : MonoBehaviour
{
    public OVRHand hand;
    public OVRInputModule inputModule;

    private void Start()
    {
        inputModule.rayTransform = hand.PointerPose;
    }
}

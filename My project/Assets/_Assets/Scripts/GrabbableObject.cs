using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


/// <summary>
/// This script allows to disappear objects in the tutorial and canvas to go to the next step
/// ATTENTION : not used in the multiplayer scenario
/// </summary>
public class GrabbableObject : MonoBehaviour
{

    public Canvas disableUI;
    public Canvas enableUI;
    public Canvas welcomeUI;

    public GameObject zoneTeleportationTuto;
    

    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        disableUI.GetComponent<Canvas>();
        enableUI.GetComponent<Canvas>();
        welcomeUI.GetComponent<Canvas>();

        zoneTeleportationTuto.GetComponent<GameObject>();
        grabInteractable.onActivate.AddListener(SetDisable);

    }

    private void OnDestroy()
    {
        grabInteractable.onActivate.RemoveListener(SetDisable);
    }


    
    private void SetDisable(XRBaseInteractor interactor)
    {
        meshRenderer.enabled = false;
        disableUI.enabled = false;
        enableUI.gameObject.SetActive(true);
        welcomeUI.enabled = false;
        zoneTeleportationTuto.SetActive(true);

    }
}

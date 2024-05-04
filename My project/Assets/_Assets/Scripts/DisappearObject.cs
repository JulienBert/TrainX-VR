using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script allows the teleportation objects to disappear whe the player hits it and lauch the correspondant audio
/// </summary>
public class DisappearObject : MonoBehaviour
{

    MeshRenderer meshrenderer;
    public GameObject teleportStep;
    public GameObject teleportStep2;

    public AudioSource goToPassiveDosimeter;
    public AudioSource goToActiveDosimeter;
    public AudioSource goToOperatingRoom;
    // Start is called before the first frame update
    void Start()
    {
        meshrenderer = GetComponent<MeshRenderer>();

        teleportStep.SetActive(false);
        teleportStep2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hands")
        {
            meshrenderer.gameObject.SetActive(false);

            switch (meshrenderer.gameObject.tag)
            {
                case "LeadAprons":
                    teleportStep.SetActive(true);
                    goToPassiveDosimeter.Play();
                    break;

                case "PassiveDosimeters":
                    goToActiveDosimeter.Play();
                    break;

                case "ActiveDosimeters":
                    teleportStep2.SetActive(true);
                    goToOperatingRoom.Play();
                    break;

            }
        }
    }
}
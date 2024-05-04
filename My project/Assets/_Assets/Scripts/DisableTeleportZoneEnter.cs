using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script allows the next step to be appeared in teleportation
/// </summary>
public class DisableTeleportZoneEnter : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public GameObject nextTeleportZone;
    public GameObject trainer;
    public Transform newPosition;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        nextTeleportZone.GetComponent<GameObject>();
    }

    private void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            meshRenderer.enabled = false;
            nextTeleportZone.SetActive(true);
            if (meshRenderer.gameObject.name == "TeleportStep (2)")
            {
                trainer.transform.SetPositionAndRotation(newPosition.position, Quaternion.Euler(trainer.transform.rotation.x, trainer.transform.rotation.y - 180f, trainer.transform.rotation.z)) ;
                
            }

        }


    }
}

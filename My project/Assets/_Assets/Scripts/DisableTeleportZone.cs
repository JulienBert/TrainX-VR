using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script allows objects to be disabled when the player hits it
/// </summary>
public class DisableTeleportZone : MonoBehaviour
{

    MeshRenderer meshRenderer;
    
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            meshRenderer.enabled = false;
            

        }

        
    }
}

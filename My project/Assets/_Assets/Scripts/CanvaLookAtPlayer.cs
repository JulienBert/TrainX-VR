using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaLookAtPlayer : MonoBehaviour
{
    GameObject player;
    GameObject head;

    public GameObject CameraPlayer;
    //Vector3 playerPos;
    RectTransform rt;
    RectTransform canvasRT;
    Vector3 playerScreenPos;
    Camera cam;
    //public Transform leader;
    public float followSharpness = 1f;
    private Vector3 OffSetVector;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        head = GameObject.FindGameObjectWithTag("Head");

        //cam = GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //playerPos = player.transform.position;
       /* rt = GetComponent<RectTransform>();
        canvasRT = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        playerScreenPos = cam.WorldToViewportPoint(player.transform.position);
        Debug.Log("OOOOOKKKK");
        rt.anchorMax = playerScreenPos;
        rt.anchorMin = playerScreenPos;*/
    }

    // Update is called once per frame
    /* void Update()
     {
         this.transform.position = GetComponent<Camera>().WorldToViewportPoint(player.transform.position);
         transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
         this.transform.LookAt(player.transform);

         *//*playerScreenPos = GetComponent<Camera>().WorldToViewportPoint(player.transform.position);
         Debug.Log("player screen pos :");
         Debug.Log(playerScreenPos);
         rt.anchorMax = playerScreenPos;
         rt.anchorMin = playerScreenPos;*//*
     }*/

   

    void LateUpdate()
    {
        OffSetVector = new Vector3(/*head*/CameraPlayer.transform.position.x, /*head*/CameraPlayer.transform.position.y, /*head*/CameraPlayer.transform.position.z+0.8f);
        transform.position += (OffSetVector - transform.position) * followSharpness;
        //transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}

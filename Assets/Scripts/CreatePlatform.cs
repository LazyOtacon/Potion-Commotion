using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{

    private Vector3 PlatLoc;
    private bool isGrounded = false;
    private GameObject platformFinder;
    public GameObject preview;
    public GameObject platformPrefab;
    public bool canplatform = false;
    public AudioClip platformsound;





    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;


    public float CastDelay = 2;  // Allow 1 platoform every 2 seconds
    private float timestamp;



    // Update is called once per frame
    void Update()
    {
        isGrounded = GroundCheck();


        if (PlatformPage.allowPlatform == true)
        {
            canplatform = true;
        }

        if(canplatform == true)
        {
        PlatLoc = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        preview.transform.position = new Vector2(PlatLoc.x, PlatLoc.y);
        }




        if (Time.time >= timestamp && Input.GetKeyDown(KeyCode.Q) && isGrounded == true)
        {
            placePlatform(PlatLoc);
            platformFinder = GameObject.FindGameObjectWithTag("Platform");
            Object.Destroy(platformFinder);
            timestamp = Time.time + CastDelay;
            GetComponent<AudioSource>().PlayOneShot(platformsound);
        }

    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
    }

    void placePlatform(Vector2 postion)
    {
        Instantiate(platformPrefab).transform.position = preview.transform.position;
    }



}

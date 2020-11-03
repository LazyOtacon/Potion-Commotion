using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{

    private Vector3 PlatLoc;
    private GameObject platformFinder;
    public GameObject preview;
    public GameObject platformPrefab;

    public float CastDelay = 2;  // Allow 1 platoform every 2 seconds
    private float timestamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlatLoc = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        preview.transform.position = new Vector2(PlatLoc.x, PlatLoc.y);


        if (Time.time >= timestamp && Input.GetKeyDown(KeyCode.Q))
        {
            placePlatform(PlatLoc);
            platformFinder = GameObject.FindGameObjectWithTag("Platform");
            Object.Destroy(platformFinder);
            timestamp = Time.time + CastDelay;
        }

    }


    void placePlatform(Vector2 postion)
    {
        Instantiate(platformPrefab).transform.position = preview.transform.position;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWispAI : MonoBehaviour
{
    public bool FaceRight = false;
    public Transform firePoint;
    public GameObject FirePrefab;
    public float FireForce = 15f;
    public float ShotDelay = 1.5f;
    private float timestamp;

    // Start is called before the first frame update
    void Start()
    {
        if (FaceRight == true)
        {
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timestamp)
        {
            Shoot();
            timestamp = Time.time + ShotDelay;
        }
    }

        void Shoot()
        {
            GameObject ice = Instantiate(FirePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = ice.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * FireForce, ForceMode2D.Impulse);
        }


}

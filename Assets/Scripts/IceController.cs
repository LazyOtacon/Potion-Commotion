using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject IcePrefab;
    public Animator Player;

    public float IceForce = 20f;
    public float ShotDelay = 0.3333f;  // Allow 3 shots per second
    private float timestamp;

    // Start is called before the first frame update
    void Update()
    {
        if (Time.time >= timestamp && Input.GetButtonDown("Fire1"))
        {
            Shoot();
            timestamp = Time.time + ShotDelay;
            Player.Play("Attack");
        }

    }

    void Shoot()
    {
        GameObject ice = Instantiate(IcePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = ice.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * IceForce, ForceMode2D.Impulse);
    }
}
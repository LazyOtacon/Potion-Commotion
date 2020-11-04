using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);
    //}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Confiner" && other.tag != "Boundry" && other.tag != "EnemyBullet")
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Boundry")
        {
            Destroy(gameObject);
        }
    }
}

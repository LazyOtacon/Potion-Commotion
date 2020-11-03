using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithIce : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ice"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

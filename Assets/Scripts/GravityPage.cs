using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPage : MonoBehaviour
{
    public AudioClip PageSound;
    public static bool allowGravity = false;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            allowGravity = true;
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(PageSound, this.gameObject.transform.position);
        }
    }
}

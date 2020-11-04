using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPage : MonoBehaviour
{
    public AudioClip PageSound;
    public static bool allowPlatform = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            allowPlatform = true;
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(PageSound, this.gameObject.transform.position);
        }
    }
}

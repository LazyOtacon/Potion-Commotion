﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithIce : MonoBehaviour
{
    [SerializeField] public float HitPoints = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("Ice"))
        {
            Destroy(other.gameObject);
            //Destroy(gameObject);
            HitPoints -= 1;
        }

        if (HitPoints <= 0)
        {
            Destroy(gameObject);
        }

    }
}

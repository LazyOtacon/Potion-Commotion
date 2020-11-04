using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepUpRight : MonoBehaviour
{

    private Quaternion iniRot;
    void Start()
    {
        iniRot = Quaternion.Euler(0, 0, 0);
        //iniRot = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = iniRot;
    }
}

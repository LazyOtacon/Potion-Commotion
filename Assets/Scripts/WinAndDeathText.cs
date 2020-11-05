using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAndDeathText : MonoBehaviour
{
    public static bool IsWin = false;
    public static bool IsDeath = false;

    public GameObject WinText;
    public GameObject DeathText;

    // Update is called once per frame
    void Update()
    {
        if (IsDeath == true)
        {
            DeathText.gameObject.SetActive(true);
        }

        if (IsWin == true)
        {
            WinText.gameObject.SetActive(true);
        }
    }


}

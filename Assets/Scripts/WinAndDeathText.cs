﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinAndDeathText : MonoBehaviour
{
    public static bool IsWin = false;
    public static bool IsDeath = false;
    private bool CanRespawn = false;

    public GameObject WinText;
    public GameObject DeathText;

    // Update is called once per frame
    void Update()
    {
        if (IsDeath == true)
        {
            DeathText.gameObject.SetActive(true);
            CanRespawn = true;
        }

        if (IsWin == true)
        {
            WinText.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && CanRespawn == true)
        {
            DeathText.gameObject.SetActive(false);
            IsDeath = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartLevel : MonoBehaviour
{
    private bool CanRespawn = false;

    // Update is called once per frame
    void Update()
    {
        if (WinAndDeathText.IsDeath == true)
        {
            CanRespawn = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && CanRespawn == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}

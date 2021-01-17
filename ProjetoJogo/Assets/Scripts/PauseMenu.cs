using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPause : MonoBehaviour
{
    public static bool GameCurrentlyPaused = false;

    public GameObject menuPauseUI;
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightAlt)||Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if(GameCurrentlyPaused)
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
        menuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameCurrentlyPaused = false;
    }

    public void Pause ()
    {
        menuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameCurrentlyPaused = true;
    }
}

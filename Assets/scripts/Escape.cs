using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public static bool Pause = false;
    public GameObject pauseMenuUI;
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause)
                Resume();
            else          
                Paused();
            
        }
        
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Pause = false;
    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Pause = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}

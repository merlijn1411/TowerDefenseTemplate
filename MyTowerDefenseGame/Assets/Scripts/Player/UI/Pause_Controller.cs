using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause_Controller : MonoBehaviour
{
    public Canvas _PauseScreen;
    public static bool GameisPaused = false;
    void Start()
    {
        Resume();    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        _PauseScreen.enabled = true;
        GameisPaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        _PauseScreen.enabled = false;
        GameisPaused = false;
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

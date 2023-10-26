using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public Canvas MenuCanvas;
    public Canvas OptionCanvas;
    void Start()
    {
        MenuCanvas.enabled = true;
        OptionCanvas.enabled = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Option()
    {
        MenuCanvas.enabled = false;
        OptionCanvas.enabled = true;
    }
    public void Back()
    {
        OptionCanvas.enabled = false;
        MenuCanvas.enabled = true;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}

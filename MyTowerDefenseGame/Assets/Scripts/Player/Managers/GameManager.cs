using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas LoseScreen;

    private void Start()
    {
        LoseScreen.enabled = false;
    }
    void Update()
    {
        if (PlayerStats.lives <= 0)
        {
            EndGameLose();
        }
    }
    void EndGameLose()
    {
        Time.timeScale = 0f;
        LoseScreen.enabled = true;
    }
    
}

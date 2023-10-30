using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
        gameEnded = true;
    }
    
}

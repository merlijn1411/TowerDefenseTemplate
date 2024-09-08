using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameSate gameState = GameSate.NotSet;
    
    public static GameManager Instance { get; private set; }
    
    public event EventHandler <GameSate> GameStateChangedEvent;

    private void Awake() 
    { 
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this;
    }

    public void InMainMenu()
    {
        gameState = GameSate.MainMenu;
        GameStateChangedEvent?.Invoke(this, gameState);
    }
    
    public void PlayGame()
    {
        gameState = GameSate.Playing;
        GameStateChangedEvent?.Invoke(this,gameState);
    }
    
    public void PauseGame()
    {
        gameState = GameSate.Paused;
        GameStateChangedEvent?.Invoke(this,gameState);
    }
}

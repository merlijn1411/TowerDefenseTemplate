using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameSate gameState = GameSate.NotSet;
    
    public static GameManager Instance { get; private set; }
    
    public event EventHandler <GameSate> GameStateChangedEvent;

    private void Awake() 
    { 
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this;

        gameState = GameSate.Playing;
    }

    public void ChangeGameState(string stateIndex)
    {
        // gameState = stateIndex switch
        // {
        //     "Playing" => GameSate.Playing, 
        //     "Pausing" => GameSate.Paused,
        //     "GoToMenu" => GameSate.MainMenu,
        //     _ => gameState
        // };

        switch (stateIndex)
        {
            case "Playing":
                gameState = GameSate.Playing;
                Time.timeScale = 1f;
                break;
            case "Pausing":
                gameState = GameSate.Paused;
                Time.timeScale = 0f;
                break;
            case "GoToMenu":
                gameState = GameSate.MainMenu;
                Time.timeScale = 1f;
                break;
        }

        GameStateChangedEvent?.Invoke(Instance, gameState);
    }
    
    
}

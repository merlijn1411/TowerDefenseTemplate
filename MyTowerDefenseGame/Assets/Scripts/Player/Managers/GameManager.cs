using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Canvas LoseScreen;

    private void Start()
    {
        LoseScreen.enabled = false;
    }
    private void Update()
    {
        if (PlayerStats.Main.Lives <= 0)
        {
            EndGameLose();
        }
    }
    public void EndGameLose()
    {
        Time.timeScale = 0f;
        LoseScreen.enabled = true;
    }
    
}

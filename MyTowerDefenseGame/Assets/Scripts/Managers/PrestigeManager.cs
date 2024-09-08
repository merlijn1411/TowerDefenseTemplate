using UnityEngine;

public class PrestigeManager : MonoBehaviour
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
    private void EndGameLose()
    {
        Time.timeScale = 0f;
        LoseScreen.enabled = true;
    }
    
}

using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseInput : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    [SerializeField] private KeyCode keyCode;
    
    private void Update()
    {
        if (!Input.GetKeyDown(keyCode)) return;
        if (GameManager.Instance.gameState == GameSate.Playing)
            PauseController();
        else
            Resume();
    }

    public void Resume()
    {
        GameManager.Instance.ChangeGameState("Playing");
        pauseScreen.SetActive(false);
    }
    
    private void PauseController()
    {
        GameManager.Instance.ChangeGameState("Pausing");
        pauseScreen.SetActive(true);
    }
    public void Restart()
    {
        GameManager.Instance.ChangeGameState("Playing");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        GameManager.Instance.ChangeGameState("GoToMenu");
        SceneManager.LoadScene("Menu");
    }
}

using UnityEngine.SceneManagement;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private GameSate _gameSate;
    private void Start()
    {
        ResumeGame();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    
    private void PauseGame()
    {
        if (_gameSate == GameSate.Playing)
            GameManager.Instance.PauseGame();
        else
            GameManager.Instance.PlayGame();
        
        pauseScreen.SetActive(!pauseScreen.activeSelf);
        
        Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
    }
    public void ResumeGame()
    {
        GameManager.Instance.PlayGame();
    }
    public void Restart()
    {
        GameManager.Instance.PlayGame();
        SceneManager.LoadScene("Level 1");
    }

    public void BackToMenu()
    {
        GameManager.Instance.InMainMenu();
        SceneManager.LoadScene("Menu");
    }
}

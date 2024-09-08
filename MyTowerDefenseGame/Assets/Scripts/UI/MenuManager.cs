using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject[] pages; 
    private int currentPageIndex = 1; 

    void Start()
    {
        for (int i = 1; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
    }

    public void NextPage()
    {
        pages[currentPageIndex].SetActive(false);

        currentPageIndex = (currentPageIndex + 1) % pages.Length;

        pages[currentPageIndex].SetActive(true);
    }

    public void PreviousPage()
    {
       pages[currentPageIndex].SetActive(false);

       currentPageIndex = (currentPageIndex - 1 + pages.Length) % pages.Length;

       pages[currentPageIndex].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
using UnityEngine;

public class PrestigeManager : MonoBehaviour
{
     [SerializeField] private GameObject prestigeScreen;
     [SerializeField] private GameObject[] prestigeTextImage;

    public void PrestigeRate(bool won)
    {
        Time.timeScale = 0f;
        prestigeScreen.SetActive(true);

        if (won)
            prestigeTextImage[0].SetActive(true);
        else
            prestigeTextImage[1].SetActive(true);
        
    }
    
}

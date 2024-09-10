using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Main;
    
    public int Money = 400;
    public int Lives = 20;

    public UnityEvent OnNoLivesLeft;

    public void Start()
    {
        Main = this;
    }

    private void Update()
    {
        if (Lives <= 0)
            OnNoLivesLeft.Invoke();
        
    }
}

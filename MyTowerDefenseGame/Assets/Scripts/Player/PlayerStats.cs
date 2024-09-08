using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Main;
    
    public int Money = 400;
    public int Lives = 20;

    public void Start()
    {
        Main = this;
    }
}

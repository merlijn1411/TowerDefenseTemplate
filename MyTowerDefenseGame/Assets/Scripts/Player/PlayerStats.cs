using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int lives;
    public int startLives = 20;

    void Start()
    {
        Money = startMoney;
        lives = startLives;

    }
}

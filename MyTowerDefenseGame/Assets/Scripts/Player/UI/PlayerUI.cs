using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI: MonoBehaviour
{
    public Text livesText;
    public Text CoinsText;


    public void Update()
    {
        livesText.text = PlayerStats.lives.ToString();
        CoinsText.text = PlayerStats.Money.ToString();

    }
}

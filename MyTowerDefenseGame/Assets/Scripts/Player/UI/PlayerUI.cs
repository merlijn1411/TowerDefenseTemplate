using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Recorder;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI: MonoBehaviour
{
    public Text livesText;
    public Text CoinsText;


    void Update()
    {
        livesText.text = PlayerStats.lives.ToString();
        CoinsText.text = PlayerStats.Money.ToString();

    }
}

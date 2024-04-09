using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveCountDown : MonoBehaviour
{
    [SerializeField] private Image fillCircle;
    [SerializeField] private float maxTimer = 15;
    
    void Update()
    {
        WaveSpawner2.waveTimer -= Time.deltaTime;
        fillCircle.fillAmount = WaveSpawner2.waveTimer / maxTimer;
    }
}

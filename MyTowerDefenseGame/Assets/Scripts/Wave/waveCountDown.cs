using UnityEngine;
using UnityEngine.UI;

public class waveCountDown : MonoBehaviour
{
    [SerializeField] private WaveSpawner2 waveSpawner2;
    [SerializeField] private Image fillCircle;
    [SerializeField] private float maxTimer = 15;
    
    void Update()
    {
        waveSpawner2.waveDelay -= Time.deltaTime;
        fillCircle.fillAmount = waveSpawner2.waveDelay / maxTimer;
    }
}

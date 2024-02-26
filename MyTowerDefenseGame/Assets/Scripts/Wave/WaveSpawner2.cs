using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WaveSpawner2 : MonoBehaviour
{
    public Wave[] waves;
    public Transform spawnPoint;

    private Wave currentWave;
    private int currentWaveNumber = 0;

    private bool canSpawn = false;
    private float nextSpawnTime;

    public float waveDelay = 15 ;
    public static float waveTimer;
    private int maxWave;

    public Canvas winScreen;
    public Text waveNumberT;

    public GameObject startButton;

    public void Start()
    {
        winScreen.enabled = false;
        startButton.SetActive(true);
        waveNumberT.text = currentWaveNumber + "/" + maxWave.ToString();

        waveTimer = waveDelay;
        maxWave = waves.Length; 
    }

    public void Update()
    {
        if (currentWaveNumber < waves.Length + 1)
        {
            if (waveDelay > 0)
            {
                waveDelay -= Time.deltaTime;
            }
            
            if (!canSpawn && waveDelay <= 0)
            {
                StartNextWave();
            }
            else if (canSpawn)
            {
                
                if (currentWave.NumberEnemies > 0)
                {
                    SpawnWave();
                }
                else
                {
                    canSpawn = false; 
                }
            }
        }
        
        waveNumberT.text = currentWaveNumber + "/" + maxWave.ToString();
        
        if (currentWaveNumber == maxWave && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StopWaves();
        }
    }

    public void StartNextWave()
    {
        if (currentWaveNumber < waves.Length)
        {
            startButton.SetActive(false);
            currentWave = waves[currentWaveNumber];
            StopTimer();
            canSpawn = true; 
            currentWaveNumber++;
        }
        maxWave = waves.Length; 
    }


    public void SpawnWave()
    {
        if (canSpawn && Time.time >= nextSpawnTime && currentWave.NumberEnemies > 0)
        {
            GameObject prefabToSpawn = currentWave.EnemyPrefabs[Random.Range(0, currentWave.EnemyPrefabs.Length)];
            Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
            currentWave.NumberEnemies--; 
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        
            if (currentWave.NumberEnemies == 0)
            {
                startButton.SetActive(true);
                canSpawn = false;
                ResetTimer();
            }
        }
    }

    public void StopWaves()
    {
        winScreen.enabled = true;
    }
    public void ResetTimer()
    {
        waveDelay = 30;
    }

    public void StopTimer()
    {
        waveDelay = 0;
    }
}

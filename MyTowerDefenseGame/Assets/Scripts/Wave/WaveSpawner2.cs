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
    public Transform spawnpoint;

    private Wave currentWave;
    private int currentWaveNumber = 0;

    private bool canSpawn = false;
    private float nextSpawnTime;

    public float waveDelay = 30 ;
    private int MaxWave;

    public Canvas WinScreen;
    public Text WaveNumberT;

    public GameObject StartWave;

    public void Start()
    {
        WinScreen.enabled = false;
        StartWave.SetActive(true);
        WaveNumberT.text = currentWaveNumber + "/" + MaxWave.ToString();
        
        MaxWave = waves.Length; 
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
        
        if (currentWaveNumber == waves.Length - 1)
        {
            waveDelay = 0f;
        }
        
        WaveNumberT.text = currentWaveNumber + "/" + MaxWave.ToString();
        
        if (currentWaveNumber == MaxWave && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StopWaves();
        }
    }

    public void StartNextWave()
    {
        if (currentWaveNumber < waves.Length)
        {
            StartWave.SetActive(false);
            currentWave = waves[currentWaveNumber];
            canSpawn = true; 
            ResetTimer();
            currentWaveNumber++;
        }
        MaxWave = waves.Length; 
    }


    public void SpawnWave()
    {
        if (canSpawn && Time.time >= nextSpawnTime && currentWave.NumberEnemies > 0)
        {
            GameObject prefabToSpawn = currentWave.EnemyPrefabs[Random.Range(0, currentWave.EnemyPrefabs.Length)];
            Instantiate(prefabToSpawn, spawnpoint.position, Quaternion.identity);
            currentWave.NumberEnemies--; 
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        
            if (currentWave.NumberEnemies == 0)
            {
                StartWave.SetActive(true);
                canSpawn = false;
            }
        }
    }

    public void StopWaves()
    {
        WinScreen.enabled = true;
    }
    public void ResetTimer()
    {
        waveDelay = 30;
    }
}

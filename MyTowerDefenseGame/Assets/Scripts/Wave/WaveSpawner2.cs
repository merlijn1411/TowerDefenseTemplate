using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner2 : MonoBehaviour
{
    public Wave[] waves;
    public Transform spawnpoint;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn = false;
    private float nextSpawnTime;

    public float waveDelay;
    public float MaxWave;

    public Canvas WinScreen;
    public Text WaveNumberT;
    

    void Start()
    {
        WinScreen.enabled = false;
        currentWaveNumber = 0;
        StartNextWave();

        WaveNumberT.text = currentWaveNumber + "/" + MaxWave.ToString();
    }

    void Update()
    {
        if (currentWaveNumber < waves.Length)
        {
            currentWave = waves[currentWaveNumber];
            SpawnWave();
        }

        waveDelay -= Time.deltaTime;
        if (waveDelay <= 0)
        {
            StartNextWave();
            WaveNumberT.text = currentWaveNumber + "/" + MaxWave.ToString();
            ResetTimer();
        }

        int AllEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (AllEnemies <= 0 && currentWaveNumber == MaxWave)
        {
            EndWaves();
        }
    }

    void StartNextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber < waves.Length)
        {
            currentWave = waves[currentWaveNumber];
            canSpawn = true;
        }
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
                canSpawn = false;
            }
        }
    }

    public void EndWaves()
    {
        WinScreen.enabled = true;
    }
    public void ResetTimer()
    {
        waveDelay = 30;
    }
}

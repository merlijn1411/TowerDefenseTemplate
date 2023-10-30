using System.Collections;
using System.Collections.Generic;
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
    public int MaxWave;

    public Canvas WinScreen;

    void Start()
    {
        WinScreen.enabled = false;
        currentWaveNumber = -1; 
        StartNextWave();
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
            ResetTimer();
        }

        int AllEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (waves.Length <= MaxWave && AllEnemies <= 0)
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

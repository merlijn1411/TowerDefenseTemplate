using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner2 : MonoBehaviour
{
    public Wave[] waves;
    public Transform spawnpoint;

    private Wave currentWave;
    private int currentWaveNumber;

    private bool canSpawn = false;
    private bool startSpawn = false;
    private bool canAnimateWave = false;
    private float nextSpawnTime;
    private float nextWaveStartTime;

    public float waveDelay;

    void Start()
    {
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

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (totalEnemies.Length == 0 && startSpawn && currentWaveNumber < waves.Length)
        {
            if (canAnimateWave)
            {
                canAnimateWave = false;
            }
            else if (Time.time >= nextWaveStartTime)
            {
                StartNextWave(); 
            }
        }
    }

    void StartNextWave()
    {
        currentWaveNumber++;
        if (currentWaveNumber < waves.Length)
        {
            currentWave = waves[currentWaveNumber];
            nextWaveStartTime = Time.time + waveDelay; 
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
                canAnimateWave = true;
            }
        }
    }
}

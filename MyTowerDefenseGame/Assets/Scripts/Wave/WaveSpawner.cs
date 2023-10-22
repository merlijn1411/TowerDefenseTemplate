using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private int BaseEnemies;
    [SerializeField] private float enemiesPerSecond;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    private int currentWave = 1;
    private float TimeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private void Awake()
    {   
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
       StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return;

        TimeSinceLastSpawn += Time.deltaTime;    
        
        if(TimeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            TimeSinceLastSpawn = 0f;
        }

        if(enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        Destroy(gameObject);
    } 

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        
    }

    private void EndWave()
    {
        isSpawning = false;
        TimeSinceLastSpawn = 0f;
        StartCoroutine(StartWave());
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, Waypoint.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(BaseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }
}


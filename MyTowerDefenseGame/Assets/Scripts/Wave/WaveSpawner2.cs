using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner2 : MonoBehaviour
{
    [SerializeField]private Wave[] waves;
    [SerializeField]private Transform spawnPoint;

    private Wave currentWave;
    private int currentWaveNumber = 0;
    private int maxWave;
    
    private bool canSpawn = false;
    private float nextSpawnTime;

    public float waveDelay;
    

    [SerializeField]private Canvas winScreen;
    [SerializeField]private Text waveNumberT;

    [SerializeField]private GameObject startButton;

    public void Start()
    {
        winScreen.enabled = false;
        startButton.SetActive(true);
        waveNumberT.text = currentWaveNumber + "/" + maxWave.ToString();
        
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
                if (AnyEnemyLeftToSpawn())
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
            StopWaves();

        if (currentWaveNumber == maxWave)
            startButton.SetActive(false);
        
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
        if (canSpawn && Time.time >= nextSpawnTime && AnyEnemyLeftToSpawn())
        {
            for (int i = 0; i < currentWave.enemyWaveData.Length; i++)
            {
                var enemyData = currentWave.enemyWaveData[i];
                if (enemyData.numberOfEnemies > 0)
                {
                    GameObject prefabToSpawn = enemyData.enemyPrefab;
                    Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
                    currentWave.enemyWaveData[i].numberOfEnemies--; 
                    
                    nextSpawnTime = Time.time + currentWave.spawnInterval;
                    break; 
                }
            }
            
            if (!AnyEnemyLeftToSpawn())
            {
                canSpawn = false;
                startButton.SetActive(true);
                ResetTimer();
            }
        }
    }
    
    private bool AnyEnemyLeftToSpawn()
    {
        foreach (var enemyData in currentWave.enemyWaveData)
        {
            if (enemyData.numberOfEnemies > 0)
            {
                return true;
            }
        }
        return false;
    }

    private void StopWaves()
    {
        winScreen.enabled = true;
    }
    private void ResetTimer()
    {
        waveDelay = 15;
    }

    private void StopTimer()
    {
        waveDelay = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{
    public string waveName;
    public EnemyWaveData[] enemyWaveData;
    public float spawnInterval;

    [System.Serializable]
    public struct EnemyWaveData
    {
        public GameObject enemyPrefab;
        public int numberOfEnemies;
    }
}

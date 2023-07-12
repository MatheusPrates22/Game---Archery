using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave01 : WaveBase
{
    // [SerializeField] private int count = 5;
    // [SerializeField] private GameObject enemyGOPrefab;


    public override void StartWave() {
        EnemiesManager.SpawnWave(enemiesPrefabList, enemiesTimeSpawnList);
    }
}

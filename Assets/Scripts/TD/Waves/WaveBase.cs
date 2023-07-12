using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveBase : MonoBehaviour
{
    [SerializeField] protected List<GameObject> enemiesPrefabList;
    [SerializeField] protected List<float> enemiesTimeSpawnList;


    private void Awake() {
        // enemiesTimeSpawnList = new List<GameObject>();
    }
    
    private void Start() {
    }

    public abstract void StartWave();

    // private IEnumerator SpawnWaveCoroutine(int enemiesCount){
    //     for(int i = 0; i < enemiesCount; i++){
    //         CircleEnemy enemy = EnemiesManager.SpawnEnemy(enemiesPrefabList[enemiesCount], transform);
    //         enemy.SetPath(EnemiesManager.GetPathTransform());
    //         yield return new WaitForSeconds(enemiesTimeSpawnList[enemiesCount]);
    //     }
    // }

    // public void SpawnWave(int enemiesCount){
    //     StartCoroutine(SpawnWaveCoroutine(enemiesCount));
    // }
}

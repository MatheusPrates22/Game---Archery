using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager Instance;

    [SerializeField] private List<Transform> pathTransform;
    [SerializeField] private List<WaveBase> waves;

    [SerializeField] private GameObject enemyGOPrefabTest;
    [SerializeField] private Vector3 initialPositionTest;

    // [SerializeField] private Transform enemyParentTransform;
    // [SerializeField] private float speed = 2;
    // [SerializeField] private int count = 5;
    // [SerializeField] private float time = 0.5f;


    private List<GameObject> enemiesList;

    private void Awake() {
        if (enemiesList == null) Instance = this;
        enemiesList = new List<GameObject>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            waves[0].StartWave();
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            CircleEnemy enemy = SpawnEnemy(enemyGOPrefabTest, initialPositionTest);
        }
    }

    public static CircleEnemy SpawnEnemy(GameObject enemyPrefab)
    {
        return SpawnEnemy(enemyPrefab, Instance.pathTransform[0].position);
    }
    public static CircleEnemy SpawnEnemy(GameObject enemyPrefab, Vector3 initialPosition)
    {
        GameObject newEnemyGO = Instantiate(enemyPrefab, initialPosition, Quaternion.identity, Instance.waves[0].transform);
        CircleEnemy enemy = newEnemyGO.GetComponent<CircleEnemy>();
        // enemy.SetPath(Instance.pathTransform);
        return enemy;
    }

    public static List<Transform> GetPathTransform(){
        return Instance.pathTransform;
    }
    
    private static IEnumerator SpawnWaveCoroutine(List<GameObject> enemiesPrefabs, List<float> enemiesTimeSpawn){
        for(int i = 0; i < enemiesPrefabs.Count; i++){
            CircleEnemy enemy = SpawnEnemy(enemiesPrefabs[i]);
            SetDefaultPath(enemy);
            yield return new WaitForSeconds(enemiesTimeSpawn[i]);
        }
    }

    public static void SpawnWave(List<GameObject> enemiesPrefabs, List<float> enemiesTimeSpawn){
        Instance.StartCoroutine(SpawnWaveCoroutine(enemiesPrefabs, enemiesTimeSpawn));
    }

    public static void SetDefaultPath(CircleEnemy enemy){
        enemy.SetPath(Instance.pathTransform);
    }

    
}

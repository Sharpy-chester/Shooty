using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] float timeBetweenSpawns;
    float timeSinceLastSpawn;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnRadius;
    [Range(0.7f, 1f)]
    [SerializeField] float timerScaling;
    [SerializeField] float minTimeBetweenSpawns;
    

    void Awake()
    {
        
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > timeBetweenSpawns)
        {
            Vector2 spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(spawnPos.x, 0, spawnPos.y), Quaternion.identity);
            timeSinceLastSpawn = 0;
            if (timeBetweenSpawns > minTimeBetweenSpawns)
            {
                timeBetweenSpawns = timeBetweenSpawns * timerScaling;
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maxSpawnTime;

    private float _timeUntilSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 6f), 0);
            GameObject spawnedEnemy = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPosition, Quaternion.identity);
            if (Random.Range(0f, 1f) < 0.5f)
            {
                FlipEnemy(spawnedEnemy);
            }
            SetTimeUntilSpawn();
        }
    }
    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(minimumSpawnTime, maxSpawnTime);


    }
    private void FlipEnemy(GameObject enemy)
    {
    Vector3 scale = enemy.transform.localScale;
    scale.x *= -1;
    enemy.transform.localScale = scale;
    }
}

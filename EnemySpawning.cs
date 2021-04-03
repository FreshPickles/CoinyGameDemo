using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    public GameObject enemy;
    public BoxCollider2D spawnCollider;
    public BoxCollider2D targetCollider;
    int enemiesPerWave;

    bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make sure we spawn at certain intervals
        if(!isSpawning)
        {
            float timer = Random.Range(1.0f, 6.0f);
            Invoke("SpawnEnemies", timer);
            isSpawning = true;
        }
    }

    private void SpawnEnemies()
    {
        // setting our number of enemies at one time
        enemiesPerWave = Random.Range(2, 5);
        
        // loop through and find the position of each enemy to spawn at
        for(int i = 0; i < enemiesPerWave; i++)
        {
            // getting a random position in our spawn collider
            Vector3 spawnPoint = RandomPointInBounds(spawnCollider.bounds);
            GameObject spawnedEnemy = Instantiate(enemy, spawnPoint, Quaternion.identity);
            spawnedEnemy.transform.localScale = Random.Range(0.1f, 0.4f) * Vector3.one;     // resizing the enemy to be random

            // setting our target so the enemy moves there
            Vector3 targetPoint = RandomPointInBounds(targetCollider.bounds);
            spawnedEnemy.GetComponent<EnemyHandler>().target = targetPoint;
        }
        isSpawning = false;
    }

    // get a random point in bounds
    private Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 4f);
    }
}

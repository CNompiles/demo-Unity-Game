using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // ο εχθρός prefab
    public Transform spawnPoint;        // σημείο spawn
    public float delayBetweenSpawns = 2f; // καθυστέρηση πριν εμφανιστεί ο επόμενος

    private GameObject currentEnemy;

    void Start()
    {
        StartCoroutine(SpawnEnemiesOneByOne());
    }

    IEnumerator SpawnEnemiesOneByOne()
    {
        while (true)
        {
            if (currentEnemy == null)
            {
                yield return new WaitForSeconds(delayBetweenSpawns);
                currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }

            yield return null;
        }
    }
}
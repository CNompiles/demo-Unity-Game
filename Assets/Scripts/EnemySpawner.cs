using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;     // � ������ prefab
    public Transform spawnPoint;       // ������ spawn
    public float delayBetweenSpawns = 2f; // ����������� ���� ���������� � ��������

    private GameObject currentEnemy;

    public static EnemySpawner Instance { get; private set; } 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void SpawnEnemyAt(Transform point)
    { 
        spawnPoint = point;

        currentEnemy = null;
    }

    void Start()
    {
        StartCoroutine(SpawnEnemiesOneByOne());
    }

    IEnumerator SpawnEnemiesOneByOne()
    {
        while (true)
        {
            // �� ��� ������� ������ ��� �����
            if (currentEnemy == null)
            {
                yield return new WaitForSeconds(delayBetweenSpawns);

                // spawn ���� ������
                currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }

            yield return null; // ��������� �� ������� frame
        }
    }
}
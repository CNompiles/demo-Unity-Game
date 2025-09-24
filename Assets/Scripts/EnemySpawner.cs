using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // � ������ prefab
    public Transform spawnPoint;        // ������ spawn
    public float delayBetweenSpawns = 2f; // ����������� ���� ���������� � ��������

    private GameObject currentEnemy;

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
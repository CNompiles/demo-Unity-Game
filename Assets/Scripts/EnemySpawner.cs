using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // � ������ prefab
    public Transform spawnPoint;        // ������ spawn
    public float respawnDelay = 2f; // ����������� ���� ���������� � ��������

    private GameObject currentEnemy;

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // ������� ��� �� ����� ���� ��������
        EnemyHealth health = currentEnemy.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.OnDeath += HandleEnemyDeath;
        }
    }

    void HandleEnemyDeath()
    {
        StartCoroutine(RespawnAfterDelay());
    }

    IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        SpawnEnemy();
    }
}
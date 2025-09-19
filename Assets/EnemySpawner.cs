using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;    

    [Header("Spawner")]
    public GameObject enemyPrefab;         
    public Transform[] spawnPoints;        
    public float spawnDelay = 5f;

    void Awake()
    {
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
       
        foreach (Transform p in spawnPoints)
        {
            SpawnImmediate(p);
        }
    }

    
    public void SpawnEnemyAt(Transform spawnPoint)
    {
        StartCoroutine(Respawn(spawnPoint));
    }

   
    public GameObject SpawnImmediate(Transform spawnPoint)
    {
        GameObject go = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
       
        EnemyHealth eh = go.GetComponent<EnemyHealth>();
        if (eh != null)
            eh.spawnPoint = spawnPoint;
        return go;
    }

    private IEnumerator Respawn(Transform spawnPoint)
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnImmediate(spawnPoint);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceSlug : MonoBehaviour
{
    public float damage = 5f; // Μικροτερο damage 
    public float slowDuration = 3f; // Διαρκεια cold
   

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyhealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyhealth != null)
            {
                enemyhealth.TakeDamage(damage);
            }

                EnemyAI ai = collision.gameObject.GetComponent<EnemyAI>();
                if (ai != null)
                {
                    StartCoroutine(ApplySlow(ai));
                }
            
            Destroy(gameObject);
        }
       
    }

    private IEnumerator ApplySlow(EnemyAI ai)
    {
        NavMeshAgent agent = ai.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            float originalSpeed = agent.speed;
            agent.speed = originalSpeed * 0.1f; // 50% speed για slow
            yield return new WaitForSeconds(slowDuration);
            agent.speed = originalSpeed;
        }  
    }
}
   
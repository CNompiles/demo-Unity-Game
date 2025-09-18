using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceSlug : MonoBehaviour
{
    public float damage = 5f; // Μικροτερο damage 
    public float slowDuration = 3f; // Διαρκεια cold
    public float slowFactor = 0.5f; // Πόσο κόβει την ταχύτητα


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
        NavMeshAgent agent = ai.GetAgent();
        if (agent != null)
        {
            agent.speed = ai.defaultSpeed * slowFactor; //Μειωνουμε την ταχυτητα 

            yield return new WaitForSeconds(slowDuration);

            agent.speed = ai.defaultSpeed; // επαναφερουμε την ταχυτητα 
        }  
    }
}
   
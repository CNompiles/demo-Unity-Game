using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlug : MonoBehaviour
{
    public float damage = 5f; // Μικροτερο damage 
    public float slowDuration = 3f; // Διαρκεια cold

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyhealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);

                EnemyAI ai = collision.gameObject.GetComponent<EnemyAI>();
                if (ai != null)
                {
                    StartCoroutine(ApplySlow(ai));
                }
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3f);
        }
    }

    private System.Collections.IEnumerator ApplySlow(EnemyAI ai)
    {
        float originalSpeed = ai.speed;
        ai.speed = originalSpeed * 0.5f; // 50% speed για slow
        yield return new WaitForSeconds(slowDuration);
        ai.speed = originalSpeed;
            
    }
}
   
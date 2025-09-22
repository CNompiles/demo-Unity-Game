using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : MonoBehaviour
{
    public float damage = 10f; //Ποση ζημια κανει το slug
    public float lifeTime = 3f; //Ποσα sec να ζει  

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // του αφαιρεί ζωή
            
            Destroy(gameObject);
        }
    }
}

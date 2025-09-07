using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Slug : MonoBehaviour
{
    public int damage = 1; // Πόση ζημιά κάνει το slug

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeHit(damage); // Στέλνουμε damage στον Enemy
            }

            Destroy(gameObject); // Το slug εξαφανίζεται μετά τη σύγκρουση
        }
    }
}

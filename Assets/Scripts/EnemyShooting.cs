using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    public void TryShoot(Vector3 targetPos)
    {
        if (Time.time >= nextFireTime)
        {
            Shoot(targetPos);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(10f);
            }
        }
    }
    void Shoot(Vector3 targetPos)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 dir = (targetPos - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = dir * bulletSpeed;
    }
}
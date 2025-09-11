using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3; // ���� ��� ���� � ������
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // ��������� �� ��� ���� ����
    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); // ������������
    }
}


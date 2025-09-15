using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("UI")]
    public Slider healthSlider;
    public float sliderSpeed = 5f; // ταχυτητα μπαρας

    private float displayedHealth; // η τιμη στην μπαρα 

    void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            displayedHealth = currentHealth;
            healthSlider.value = displayedHealth;
        }
    }

    void Update()
    {
        if (healthSlider != null) 
            displayedHealth = Mathf.Lerp(displayedHealth, currentHealth, Time.deltaTime * sliderSpeed);
            healthSlider.value = displayedHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0f);

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (currentHealth <= 0f)
            Die();
    }

    void Die()
    {
        // animation / particles / score 
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("UI")]
    public Slider healthSlider;
    public float sliderSpeed = 5f; // ταχυτητα αλλαγης στο UI
    private float displayedHealth;

    [Header("Respawn")]
    public float respawnDelay = 3f;
    public Transform respawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider != null )
        {
            healthSlider.maxValue = maxHealth;
            displayedHealth = currentHealth;
            healthSlider.value = displayedHealth;
        }
    }

    void Update()
    {
        if ( healthSlider != null )
        { displayedHealth = Mathf.Lerp(displayedHealth, currentHealth, Time.deltaTime * sliderSpeed);
        healthSlider.value = displayedHealth;
        }
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
        Debug.Log("Player Died!");

        gameObject.SetActive(false);
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        // επαναφορά ζωής
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            displayedHealth = currentHealth;
            healthSlider.value = displayedHealth;
        }

        // μετακίνηση στο respawn point
        if (respawnPoint != null)
            transform.position = respawnPoint.position;

        // ενεργοποίηση πάλι του player
        gameObject.SetActive(true);
        Debug.Log("Player Respawned!");
    }
}

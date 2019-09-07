using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    // UI elements
    public Slider healthFill;

    // Public variables
    public float currentHealth;             // Current health
    public float maxHealth;                 // Max health
    public float damageCollision;           // Damage taken when colliding with an enemy

    // Should trigger when something stays within the collider
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy") // checks if other is enemy
        {
            ChangeHealth(-damageCollision * Time.deltaTime);
            Debug.Log("Triggered TEST");
        }
    }

    // Updates health
    public void ChangeHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    
    // Detah have been reached
    void Die()
    {
        SceneManager.LoadScene("YouDied");  // Changes scene to the death scene
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthValue : MonoBehaviour
{
    // UI elements
    public Transform healthBar;
    public Slider healthFill;

    // Public variables
    public float currentHealth;             // Current health
    public float maxHealth;                 // Max health
    public float healthBarYOffset = 0.0f;   // Health bar Y offset

    public void ChangeHealth(int amount) {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth;
    }

    // updates the health bar's position
    private void PositionHealthBar() {
        Vector3 currentPos = transform.position;
        healthBar.position = new Vector3(currentPos.x, currentPos.y + healthBarYOffset, currentPos.z);

        healthBar.LookAt(Camera.main.transform);
    }

    // Update is called once per frame
    void Update()
    {
        PositionHealthBar();
    }
}

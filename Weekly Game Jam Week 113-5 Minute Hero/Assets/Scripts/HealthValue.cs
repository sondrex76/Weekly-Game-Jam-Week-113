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

    Image sliderImage;      // Image
    Image innerSliderImage; // Inner image

    // Runs at start
    private void Start()
    {
        // Gets the parts of sliderImage
        sliderImage = gameObject.transform.Find("HealthBar").Find("HealthBarBacking").GetComponent<Image>();
        innerSliderImage = gameObject.transform.Find("HealthBar").Find("HealthBarBacking").Find("HealthSlider").Find("HealthFillArea").Find("HealthFill").GetComponent<Image>();
        innerSliderImage.enabled = sliderImage.enabled = false;
    }

    // Updates health
    public void ChangeHealth(float amount)
    {
        innerSliderImage.enabled = sliderImage.enabled = true;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthFill.value = currentHealth;

        if (currentHealth <= 0f)
        {
            Die();
        }
        else // if they are still alive when shot they follow the player even if the yare outside of their normal range
        {
            Transform tempTransform = gameObject.transform.Find("PlayerFinder");

            if (tempTransform != null)  // Ensures only the melee enemies executes the following code
            {
                tempTransform.GetComponent<MeleeBehaviour>().shouldFollowPlayer = true;
                tempTransform.GetComponent<MeleeBehaviour>().target = Camera.main.transform;
            }
        }
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

    void Die()
    {
        Destroy(gameObject);
    }
}

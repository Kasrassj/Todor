using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Damageable playerDamageable; // Reference to the player's Damageable component
    public Slider healthBarSlider; // Reference to the Slider component of the health bar

    void Start()
    {
        // Find the player GameObject and get its Damageable component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerDamageable = player.GetComponent<Damageable>();
        }
    }

    void Update()
    {
        if (playerDamageable != null)
        {
            // Calculate fill amount based on player's current health and maximum health
            float fillAmount = (float)playerDamageable.GetCurrentHealth() / playerDamageable.GetMaxHealth();

            // Update the value of the slider
            healthBarSlider.value = fillAmount;
        }
    }
}

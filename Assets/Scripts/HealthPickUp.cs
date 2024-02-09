using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healAmount = 20; // Amount of health restored by the pickup

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Get the Damageable component of the player
            Damageable playerDamageable = other.GetComponent<Damageable>();

            // Check if the player has the Damageable component
            if (playerDamageable != null)
            {
                // Heal the player
                playerDamageable.Heal(healAmount);

                // Destroy the potion object after healing
                Destroy(gameObject);
            }
        }
    }
}

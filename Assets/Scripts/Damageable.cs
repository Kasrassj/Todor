using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the object
    public int currentHealth; // Current health of the object

    void Start()
    {
        // Initialize current health to max health when the object is spawned
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Reduce current health by the damage amount
        currentHealth -= damageAmount;

        // Check if the object's health has dropped to zero or below
        if (currentHealth <= 0)
        {
            // If the object's health is zero or below, destroy the object
            Destroy(gameObject);
        }
    }
}

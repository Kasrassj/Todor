using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the object
    public int currentHealth; // Current health of the object
    public GameObject healthPotionPrefab; // Reference to the health potion prefab
    public float potionSpawnChance = 1f;
    public int currentSceneIndex;

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    void Start()
    {
        // Initialize current health to max health when the object is spawned
        currentHealth = maxHealth;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void TakeDamage(int damageAmount, bool isBlocking)
    {
        // Check if the player is blocking
        if (isBlocking)
        {
            // Player is blocking, so don't apply any damage
            currentHealth = currentHealth;
            return;
        }

        // Reduce current health by the damage amount
        currentHealth -= damageAmount;

        // Check if the object's health has dropped to zero or below
        if (currentHealth <= 0)
        {
            
            // Check if a health potion should spawn
            if (Random.value < potionSpawnChance)
                {
                    // Spawn a health potion at the enemy's position
                    Instantiate(healthPotionPrefab, transform.position, Quaternion.identity);
                }

            // Destroy the enemy object
            Destroy(gameObject);

        }
    }
    public void Heal(int healAmount)
    {
        // Increase current health by the heal amount
        currentHealth += healAmount;

        // Ensure current health does not exceed max health
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public void endGame()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{
    public float blockPushForce = 5f; // Force applied to the player and enemy when blocking
    public float blockDuration = 0.7f; // Duration of the block in seconds
    private bool isBlocking = false; // Flag to track if the player is currently blocking

    void Update()
    {
        // Check if the player is currently blocking
        if (isBlocking)
        {
            // Reduce the block duration
            blockDuration -= Time.deltaTime;

            // Check if block duration has expired
            if (blockDuration <= 0)
            {
                // Stop blocking
                isBlocking = false;
            }
        }

        // Check if the player can block
        if (!isBlocking && Input.GetButtonDown("Fire2")) // Assuming "Fire2" is the block button (right mouse button)
        {
            // Start blocking
            isBlocking = true;
            blockDuration = 0.5f; // Reset block duration

            // Apply force to push the player back
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-transform.right.x * blockPushForce, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player is currently blocking and the collision is with an enemy
        if (isBlocking && other.CompareTag("Enemy"))
        {
            // Push both the player and the enemy back
            Rigidbody2D playerRb = GetComponent<Rigidbody2D>();
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();

            // Calculate the direction to push the player and the enemy
            Vector2 pushDirection = (transform.position - other.transform.position).normalized;

            // Apply force to push the player and the enemy
            playerRb.velocity = pushDirection * blockPushForce;
            enemyRb.velocity = -pushDirection * blockPushForce;
        }
    }
}

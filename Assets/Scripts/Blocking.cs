using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{
    public float blockPushForce = 5f; // Force applied to the player and enemy when blocking
    public float blockHoldDuration = 0.5f; // Minimum duration of block hold in seconds
    public float blockCooldown = 1f; // Cooldown period before player can block again after releasing the block button
    private bool isBlocking = false; // Flag to track if the player is currently blocking
    private bool canBlock = true; // Flag to track if the player can currently block

    void Update()
    {
        // Check if the player is currently blocking
        if (isBlocking)
        {
            // Reduce the block hold duration
            blockHoldDuration -= Time.deltaTime;

            // Check if the block hold duration has expired
            if (blockHoldDuration <= 0)
            {
                // Stop blocking
                StopBlocking();
            }
        }

        // Check if the player can block
        if (canBlock && Input.GetButton("Fire2")) // Assuming "Fire2" is the block button (right mouse button)
        {
            // Start blocking
            StartBlocking();
        }

        // Check if the player releases the block button
        if (!Input.GetButton("Fire2"))
        {
            // Stop blocking
            StopBlocking();
        }
    }

    void StartBlocking()
    {
        isBlocking = true;
        canBlock = false; // Disable blocking until cooldown expires
        blockHoldDuration = 0.5f; // Reset block hold duration

        // Apply force to push the player back
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-transform.right.x * blockPushForce, rb.velocity.y);
    }

    void StopBlocking()
    {
        isBlocking = false;
        Invoke("ResetBlockCooldown", blockCooldown); // Start the block cooldown
    }

    void ResetBlockCooldown()
    {
        canBlock = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player is currently blocking and the collision is with an enemy
        if (isBlocking && other.CompareTag("Fire"))
        {
            // Push both the player and the enemy back
            Rigidbody2D playerRb = GetComponent<Rigidbody2D>();
            Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();

            // Calculate the direction to push the player and the enemy
            Vector2 pushDirection = (transform.position - other.transform.position).normalized;

            // Apply force to push the player and the enemy
            playerRb.velocity = pushDirection * blockPushForce;
            enemyRb.velocity = -pushDirection * blockPushForce;
            Debug.Log("Blocking!");
        }
    }

    public bool IsBlocking()
    {
        return isBlocking;
    }
}

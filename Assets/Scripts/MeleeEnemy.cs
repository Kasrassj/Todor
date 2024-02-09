using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float attackRange = 1.5f; // Range within which the enemy attacks
    public float windUpDuration = 1.0f; // Duration of the wind-up before attacking
    public float attackDuration = 0.5f; // Duration of the attack animation
    public LayerMask playerLayer; // Layer mask for the player objects
    public GameObject attackEffectPrefab; // Reference to the attack effect prefab
    public float attackOffset = 1.0f; // Offset distance for spawning attack effect

  //  private Animator animator; // Reference to the enemy's animator component
    private Transform player; // Reference to the player's transform
    private bool isAttacking = false; // Flag to track if the enemy is currently attacking
    private float windUpTimer = 0f; // Timer for the wind-up duration
    private float attackTimer = 0f; // Timer for the attack duration

    void Start()
    {
        //animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the player is within attack range
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // Start wind-up animation
            if (!isAttacking)
            {
                windUpTimer += Time.deltaTime;
                if (windUpTimer >= windUpDuration)
                {
                    isAttacking = true;
                    windUpTimer = 0f;

                    // Start attack animation
                   // animator.SetTrigger("Attack");

                    // Spawn attack effect if available
                    if (attackEffectPrefab != null)
                    {
                        // Calculate offset position in front of the enemy
                        Vector2 attackOffsetPosition = (Vector2)transform.position + (Vector2)transform.right * attackOffset;

                        GameObject attackEffectInstance = Instantiate(attackEffectPrefab, attackOffsetPosition, Quaternion.identity);

                        // Destroy the attack effect after 1 second
                        Destroy(attackEffectInstance, 1f);
                    }
                }
            }
            else
            {
                // Continue attack animation
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackDuration)
                {
                    // Stop attack animation
                    isAttacking = false;
                    attackTimer = 0f;
                }
            }
        }
        else
        {
            // Reset timers if player is out of range
            windUpTimer = 0f;
            attackTimer = 0f;
            isAttacking = false;
        }
    }

    // Called by animation event to deal damage to the player
    void DealDamage()
    {
        // Check if the player is within attack range
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // Get the Damageable component of the player
            Damageable playerDamageable = player.GetComponent<Damageable>();

            // Check if the player has the Damageable component
            if (playerDamageable != null)
            {
                // Deal damage to the player
                playerDamageable.TakeDamage(10, false); // Adjust damage amount as needed
            }
        }
    }
}

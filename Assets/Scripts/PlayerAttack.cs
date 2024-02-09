using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f; // Range of the player's attack
    public LayerMask enemyLayer; // Layer mask for enemy objects

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetButtonDown("Fire1"))
        {
            // Perform the attack
            Attack();
        }
    }

    void Attack()
    {
        // Get the position and direction of the player's attack
        Vector2 attackPosition = transform.position;
        Vector2 attackDirection = transform.right; // Assuming the player is facing right

        // Raycast to detect enemies in front of the player
        RaycastHit2D hit = Physics2D.Raycast(attackPosition, attackDirection, attackRange, enemyLayer);

        // Check if an enemy is hit by the raycast
        if (hit.collider != null)
        {
            // Get the enemy's Damageable component and apply damage
            Damageable enemy = hit.collider.GetComponent<Damageable>();
            if (enemy != null)
            {
                // Deal damage to the enemy (you can adjust the damage amount as needed)
                enemy.TakeDamage(10,false);
                Debug.Log(enemy.currentHealth.ToString());
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float followDistance = 5f; // Distance at which the enemy starts following the player
    public float shootDistance = 2f; // Distance at which the enemy starts shooting fireballs
    public Transform spawnArea;

    public float fireballSpeed = 5f;
    public GameObject fireballPrefab; // Reference to the fireball prefab
    public float fireballCooldown = 2f;
    private float lastFireTime;


    private Animator animator;
    private bool isFollowing = false;

    void Start()
    {
        //animator = GetComponent<Animator>();
        lastFireTime = -fireballCooldown;
    }

    void Update()
    {
        // Check if player is within follow distance
        if (Vector2.Distance(transform.position, player.position) <= followDistance)
        {
            isFollowing = true;
           // animator.SetBool("IsWalking", true);

            // Move towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * 2f);
            Vector2 direction = (player.position - transform.position).normalized;
            

            // Check if player is within shooting distance
            if (Vector2.Distance(transform.position, player.position) <= shootDistance && isFollowing == true)
            {
                // animator.SetBool("IsWalking", false);
                // animator.SetTrigger("Shoot");
                // Fire a fireball
                if (Time.time - lastFireTime > fireballCooldown)
                {
                    // Fire a fireball
                    ShootFireball();
                    lastFireTime = Time.time;
                }
            }
            // If you change the size of the enemy change these vectors as well
            if (direction.x > 0)
                transform.localScale = new Vector3(-1f, 1f, 1f); // Flip left
            else if (direction.x < 0)
                transform.localScale = new Vector3(1f, 1f, 1f); // Flip right
        }
        else
        {
            isFollowing = false;
           // animator.SetBool("IsWalking", false);
        }
    }

    void ShootFireball()
    {
        Vector2 direction = (player.position - spawnArea.transform.position).normalized;

        // Instantiate a fireball prefab at the enemy's position
        GameObject fireball = Instantiate(fireballPrefab, spawnArea.transform.position, Quaternion.identity);

        // Get the Rigidbody2D component of the fireball
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        // Apply force to the fireball in the direction towards the player
        rb.AddForce(direction * fireballSpeed, ForceMode2D.Impulse);
    }
}

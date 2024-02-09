using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageZone : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the fireball deals

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the fireball triggers with anything that can take damage
        Damageable target = other.GetComponent<Damageable>();
        if (target != null)
        {
            // Deal damage to the target
            target.TakeDamage(damageAmount, false);
            Debug.Log(target.currentHealth.ToString());
            Destroy(gameObject);
        }


    }
}

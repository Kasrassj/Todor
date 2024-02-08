using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireball : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the fireball triggers with any other collider
        // If it does, destroy the fireball game object
        Destroy(gameObject);
    }
   
}

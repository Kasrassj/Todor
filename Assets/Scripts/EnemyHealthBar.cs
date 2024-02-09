using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image Hpbar;
    public Damageable enemy;

    float health;

    private void Start()
    {
        enemy= GetComponent<Damageable>();
    }

    private void Update()
    {
        health = (float)enemy.currentHealth / (float)enemy.maxHealth;

        Hpbar.fillAmount = health;
    }
}

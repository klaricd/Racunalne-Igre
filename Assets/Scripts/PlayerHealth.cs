using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;

    void Start()
    {
        currentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetMaxHealth(currentHealth);
    }
}

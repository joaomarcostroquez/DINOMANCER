using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float startingHealthOffset = 0;

    protected float health;

    protected virtual void Start()
    {
        health = maxHealth + startingHealthOffset;
        startingHealthOffset = 0;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public bool ChangeHealth(float amount)
    {
        float previousHealth = health;

        health = Mathf.Clamp(health + amount, 0f, maxHealth);

        if (previousHealth != health)
        {
            OnHealthChanged(previousHealth);

            return true;
        }
        else
            return false;
    }

    public bool SetHealth(float newHealth)
    {
        float previousHealth = health;

        health = Mathf.Clamp(newHealth, 0f, maxHealth);

        if (previousHealth != health)
        {
            OnHealthChanged(previousHealth);

            return true;
        }
        else
            return false;
    }

    public bool ChangeMaxHealth(float amount)
    {
        float previousMaxHealth = maxHealth;

        if (maxHealth + amount > 0)
        {
            maxHealth += amount;

            OnMaxHealthChanged(previousMaxHealth);

            return true;
        }
        else
            return false;
    }

    public bool SetMaxHealth(float newMaxHealth)
    {
        float previousMaxHealth = maxHealth;

        if (newMaxHealth > 0)
        {
            maxHealth = newMaxHealth;

            OnMaxHealthChanged(previousMaxHealth);

            return true;
        }
        else
            return false;
    }

    protected virtual void OnHealthChanged(float previousHealth)
    {
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void OnMaxHealthChanged(float previousMaxHealth)
    {
        //code to handle what the new health will be when maxHealth changes
    }

    protected virtual void Die()
    {
        //to be overriden in derived classes
    }
}

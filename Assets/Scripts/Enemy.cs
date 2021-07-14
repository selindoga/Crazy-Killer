using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float InitialHealth = 30f;
    private float Health;
    public Image HealthBar;

    private void Start()
    {
        Health = InitialHealth;
    }

    public void MakeDamage(float damageTaken)
    {
        Health -= damageTaken;

        HealthBar.fillAmount = Health / InitialHealth;
        
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

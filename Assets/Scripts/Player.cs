using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float InitialPlayerHealth = 50f;
    private float PlayerHealth;
    public Image PlayerHealthBar;

    public float TakenDamage = 5f;
    private MainMenu _mainMenu;

    private void Start()
    {
        PlayerHealth = InitialPlayerHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) // even tho only enemy can collide w/ player
        {
            MakeDamageToPlayer(TakenDamage);
        }
    }

    public void MakeDamageToPlayer(float damageTaken)
    {
        PlayerHealth -= damageTaken;

        PlayerHealthBar.fillAmount = PlayerHealth / InitialPlayerHealth;
        
        if (PlayerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _mainMenu.GetComponent<MainMenu>().GameLost();
        Debug.Log("I just died");
    }
}

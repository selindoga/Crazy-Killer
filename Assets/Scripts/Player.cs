using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    // I have to admit this will be the worst code ever
    
    private float InitialPlayerHealth = 50f;
    private float PlayerHealth;
    
    public Image PlayerHealthBar;

    public float TakenDamage = 5f; 
    // maybe the damage taken changes depending on the enemy type
    // (for future updates)
    

    private void Start()
    {
        PlayerHealth = InitialPlayerHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            MakeDamageToPlayer(TakenDamage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Boss"))
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
            PlayerDie();
        }
    }

    private void PlayerDie() // if player dies = player looses
    {
        MainMenu.playerDied = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    } 

    public static void PlayerWin() // call this method when boss got killed
    {
        MainMenu.playerWon = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float InitialPlayerHealth = 50f;
    private float PlayerHealth;
    
    public Image PlayerHealthBar;

    private float TakenDamage = 9f;
    private float TakenDamageFromBoss = 15f;
    
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
            MakeDamageToPlayer(TakenDamageFromBoss * Time.deltaTime);
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

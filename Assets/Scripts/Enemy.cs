using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private float InitialEnemyHealth;
    private float EnemyHealth;
    public Image EnemyHealthBar;
    
    private GameObject Player;
    private Vector3 vector;
    private float followingSpeed;

    private void Start()
    {
        InitialEnemyHealth = Random.Range(15f, 34f);
        followingSpeed = Random.Range(5f, 10f);
        
        EnemyHealth = InitialEnemyHealth;
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        FollowPlayer();
    }

    public void MakeDamage(float damageTaken)
    {
        EnemyHealth -= damageTaken;

        EnemyHealthBar.fillAmount = EnemyHealth / InitialEnemyHealth;
        
        if (EnemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void FollowPlayer()
    {
        vector = new Vector3(Player.transform.position.x, gameObject.transform.position.y, Player.transform.position.z);
        transform.LookAt(vector);
        transform.Translate((Vector3.forward) * (followingSpeed * Time.deltaTime));
    }
}

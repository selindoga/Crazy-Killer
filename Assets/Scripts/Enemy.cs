using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private float InitialHealth;
    private float Health;
    public Image HealthBar;
    
    private GameObject Player;
    private Vector3 vector;
    private float followingSpeed;

    private void Start()
    {
        InitialHealth = Random.Range(15f, 34f);
        followingSpeed = Random.Range(5f, 10f);
        
        Health = InitialHealth;
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        FollowPlayer();
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

    void FollowPlayer()
    {
        vector = new Vector3(Player.transform.position.x, gameObject.transform.position.y, Player.transform.position.z);
        transform.LookAt(vector);
        transform.Translate((Vector3.forward) * (followingSpeed * Time.deltaTime));
    }
}

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
    
    private GameObject Player;
    private Vector3 vector;
    public float followingSpeed = 3.7f;

    private void Start()
    {
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

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
    
    private GameObject PlayerObject;
    private Vector3 vector;
    private float followingSpeed;

    private void Start()
    {
        InitialEnemyHealth = Random.Range(15f, 34f);
        followingSpeed = Random.Range(5f, 10f);
        
        EnemyHealth = InitialEnemyHealth;
        PlayerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        FollowPlayer();
    }

    public void MakeDamageToEnemy(float damageTaken) // this method will stay in this class bc I access it from Gun class
    {
        EnemyHealth -= damageTaken;

        EnemyHealthBar.fillAmount = EnemyHealth / InitialEnemyHealth;
        
        if (EnemyHealth <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        GameManager.killedEnemiesNo ++;
        Destroy(gameObject);
    }

    void FollowPlayer()
    {
        vector = new Vector3(PlayerObject.transform.position.x, gameObject.transform.position.y, PlayerObject.transform.position.z);
        transform.LookAt(vector);
        transform.Translate((Vector3.forward) * (followingSpeed * Time.deltaTime));
    }
}

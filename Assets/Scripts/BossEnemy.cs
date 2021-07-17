using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    private float InitialBossHealth = 200f;
    private float BossHealth;
    public Image BossHealthBar;
    
    private GameObject PlayerObject;
    private Vector3 vector;
    private float followingSpeed = 9f;


    private void Start()
    {
        BossHealth = InitialBossHealth;
        PlayerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        FollowPlayer(); 
    }

    public void MakeDamageToBoss(float damageTaken)
    {
        BossHealth -= damageTaken;

        BossHealthBar.fillAmount = BossHealth / InitialBossHealth;
        
        if (BossHealth <= 0)
        {
            BossDie();
        }
    }

    private void BossDie() // make player win
    {
        gameObject.SetActive(false);
        Player.PlayerWin();
    }
    
    void FollowPlayer()
    {
        vector = new Vector3(PlayerObject.transform.position.x, gameObject.transform.position.y, PlayerObject.transform.position.z);
        transform.LookAt(vector);
        transform.Translate((Vector3.forward) * (followingSpeed * Time.deltaTime));
    }
}

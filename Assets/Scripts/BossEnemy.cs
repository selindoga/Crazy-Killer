using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    private float InitialBossHealth = 200f;
    private float BossHealth;
    public Image BossHealthBar;
    
    private GameObject PlayerObject;
    private float followingSpeed = 9f;

    private void Awake()
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
        Player.PlayerWin();
        gameObject.SetActive(false);
    }
    
    void FollowPlayer()
    {
        Vector3 _playerPos = PlayerObject.transform.position;
        Vector3 _vector = new Vector3(_playerPos.x, gameObject.transform.position.y, _playerPos.z);
        transform.LookAt(_vector);
        transform.Translate((Vector3.forward) * (followingSpeed * Time.deltaTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 9f;
    public float range = 100f;

    public GameObject shootingPoint;
    public ParticleSystem boom;

    private Enemy enemy;
    private BossEnemy boss;
    
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        boom.Play();
        RaycastHit hit;
        if (Physics.Raycast(shootingPoint.transform.position, shootingPoint.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                enemy = hit.transform.GetComponent<Enemy>();
                enemy.MakeDamageToEnemy(damage);
            } 
            else if (hit.transform.gameObject.CompareTag("Boss"))
            {
                boss = hit.transform.GetComponent<BossEnemy>();
                boss.MakeDamageToBoss(damage);
            }
        }
    }
}

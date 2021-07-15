using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 5f;
    public float range = 100f;

    public GameObject shootingPoint;
    public ParticleSystem boom;
    
    
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
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.MakeDamage(damage);
            }
        }
    }
}

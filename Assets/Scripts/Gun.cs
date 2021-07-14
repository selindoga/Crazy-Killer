using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    // to shoot automatically when pressed down
    
    // public float fireRate = 15f;
    
    public Camera cam;
    public ParticleSystem boom;
    
    // private float timeToFire = 0f;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // void Update()
    // {
    //     if (Input.GetButtonDown("Fire1") && Time.time >= timeToFire)
    //     {
    //         timeToFire = Time.time + 1f / fireRate;
    //         Shoot();
    //     }
    // }
    void Shoot()
    {
        boom.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (! hit.transform.CompareTag("Player") && enemy != null)
            {
                enemy.MakeDamage(damage);
            }
        }
    }
}

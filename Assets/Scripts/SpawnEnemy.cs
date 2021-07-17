using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject ZombiEnemy;
    
    private int SpawnedEnemy;
    
    public static int TotalSpawnedEnemy = 5;
    
    private float WaitToSpawn = 5f;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(ZombiEnemy, gameObject.transform);
            SpawnedEnemy++;
            if (SpawnedEnemy >= TotalSpawnedEnemy)
            {
                break;
            }
            yield return new WaitForSeconds(WaitToSpawn);
        }
    }
}

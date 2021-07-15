using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject ZombiEnemy;
    private int SpawnedEnemy;
    

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
            if (SpawnedEnemy >= 5)
            {
                break;
            }
            yield return new WaitForSeconds(5f);
        }
    }
}

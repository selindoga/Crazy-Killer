using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int killedEnemiesNo ;
    private static int totalEnemies ;

    public GameObject BossZombie;

    private void Start()
    {
        killedEnemiesNo = 0;
        totalEnemies = SpawnEnemy.TotalSpawnedEnemy * 4;
        BossZombie.SetActive(false);
    }

    private void Update()
    {
        if (killedEnemiesNo == totalEnemies)
        {
            BossZombie.SetActive(true);
        }
    }
}

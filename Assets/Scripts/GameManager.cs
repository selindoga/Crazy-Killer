using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int killedEnemiesNo;
    private static int totalEnemies = SpawnEnemy.TotalSpawnedEnemy * 4;

    private GameObject BossZombie;
    
    private void Start()
    {
        BossZombie = GameObject.Find("BossZombie");
    }

    private void Update()
    {
        if (killedEnemiesNo == totalEnemies)
        {
            BossZombie.SetActive(true);
        }
    }
}

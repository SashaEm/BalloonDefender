using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Ball[] balls = new Ball[0];
    [SerializeField] private float timeBetweenEachSpawn = 0.01f;
    private int waveNumber = 1;
    private int[] ballCount = new int[3];
    public static int enemiesAlive;

    private void Update()
    {
        if(enemiesAlive == 0)
        {
            waveNumber ++;
            GenerateEnemyList();
            Timing.RunCoroutine(SpawnEnemies());
        }
    }

    private void GenerateEnemyList()
    {
        if (waveNumber % 2 == 0)
        {
            ballCount[0] += 2;
        } 
        if(waveNumber % 3 == 0)
        {
            ballCount[1] += 2;
        }
        if(waveNumber % 5 == 0)
        {
            ballCount[2] ++;
        }
    }

    IEnumerator<float> SpawnEnemies()
    {
        for(int ballType = 0; ballType < ballCount.Length; ballType++)
        {
            for(int spawnCount = 0; spawnCount < ballCount[ballType]; spawnCount ++)
            {
                Instantiate(balls[ballType], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                enemiesAlive++;
                yield return Timing.WaitForSeconds(timeBetweenEachSpawn);
            }
        }
    }
}

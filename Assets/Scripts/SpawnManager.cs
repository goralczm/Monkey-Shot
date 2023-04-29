using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int startEnemies = 3;
    public float maxEnemies = 30f;
    public static int currentMonkeyCount=0;
    public float monkeyRespawnTime = 5f;
    private float countdown;
    public EnemySpawner[] spawners;

    void Start()
    {
        currentMonkeyCount = 0;

        if (maxEnemies > spawners.Length)
        {
            maxEnemies = spawners.Length;
            Debug.Log("maxEnemies is higher than the number of spawners");
        }
            
        if (startEnemies > spawners.Length)
        {
            startEnemies = spawners.Length;
            Debug.Log("startEnemies is higher than the number of spawners");
        }
            
            
        countdown = monkeyRespawnTime;

        for(int i=0;i<startEnemies;i++)
        {
            FindLocationAndSpawn();
            currentMonkeyCount++;
        }
    }

    private void Update()
    {
        if (countdown <= 0)
        {
            if (currentMonkeyCount < maxEnemies)
            {
                FindLocationAndSpawn();
                currentMonkeyCount++;
                countdown = monkeyRespawnTime; 
            }
        }
        else if(currentMonkeyCount != maxEnemies)
        {
            countdown -= Time.deltaTime;
        }
    }

    private void FindLocationAndSpawn()
    {
        List<EnemySpawner> EmptySpawners = new List<EnemySpawner>();

        foreach (EnemySpawner spawner in spawners)
        {
            if (spawner.isTaken == false)
                {
                    EmptySpawners.Add(spawner);
                }
        }
        int index = Random.Range(0, EmptySpawners.Count);

        EmptySpawners[index].SpawnMonkeyOnPosition();
    }

}

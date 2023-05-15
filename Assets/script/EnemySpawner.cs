using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int howManyEnemies;
    public GameObject enemyToSpawn;
    private Transform planeDimensions;


    private void Start()
    {
        howManyEnemies = 2;
        for(int i = 0; i < howManyEnemies; i++)
        {
            SpawnMonkey();
        }
    }

   public void SpawnMonkey()
    {
        Enemy newMonkey = Instantiate(enemyToSpawn,transform.position, Quaternion.identity).GetComponent<Enemy>();
        
    }









}

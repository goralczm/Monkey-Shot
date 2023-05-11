using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawning : MonoBehaviour
{

    public EnemyTemplate[] enemyTypes;

    public GameObject enemyToSpawn;
    public int howMuchEnemies;
    public Transform planeDimensions;
    void Start()
    {

        howMuchEnemies = Random.Range(1, 6);
        for(int i = 0; i < howMuchEnemies; i++)
        {
            spawnMonkey();
            
        }
        
    }

    void Update()
    {
       
    }

    public void spawnMonkey()
    {
        Enemy nowaMalpa = Instantiate(enemyToSpawn, transform.position, Quaternion.identity).GetComponent<Enemy>();
        nowaMalpa.enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
        nowaMalpa.planeDimensions = planeDimensions;
        nowaMalpa.spawner = this;
    }
}

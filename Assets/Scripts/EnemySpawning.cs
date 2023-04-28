using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    public GameObject enemyToSpawn;
    public int howMuchEnemies;
    public Transform planeDimensions;

    void Start()
    {

        howMuchEnemies = Random.Range(1, 6);
        for(int i = 0; i < howMuchEnemies; i++)
        {
            Enemy nowaMalpa = Instantiate(enemyToSpawn, transform.position, Quaternion.identity).GetComponent<Enemy>();
            nowaMalpa.planeDimensions = planeDimensions;
            
        }
        
    }

    
    void Update()
    {
       
    }
}

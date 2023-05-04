using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int spawnLimit = 5;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] EnemyType[] enemyTypes;
    
    public static int enemyCount;

    void Spawn() 
    {
        float x = transform.localScale.x / 2;
        float y = transform.localScale.y / 2;
        Monkey tempMonkey = Instantiate(enemyPrefab, new Vector2(Random.Range(-x,x),Random.Range(-y,y)), enemyPrefab.transform.rotation).GetComponent<Monkey>();
        tempMonkey.enemyType = enemyTypes[Random.Range(0,enemyTypes.Length)];
        tempMonkey.spawner = gameObject;
        enemyCount++;
    }

    void Start()
    {
        enemyCount = 0;
    }

    void Update()
    {
        if(enemyCount < spawnLimit) 
        {
            Spawn();
        }
    }
}

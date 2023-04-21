using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Monkey;
    public Transform square;
    public float spawnEnemies = 10f;
    
    void Start()
    {
        for(int i = 0; i < spawnEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        float x_border = Random.Range((-square.localScale.x/2)+1, (square.localScale.x/2)-1);
        float y_border = Random.Range((-square.localScale.y/2)+1, (square.localScale.y/2)-1);
        Monkey tempMonkey = Instantiate(Monkey, new Vector2(x_border, y_border), Quaternion.identity).GetComponent<Monkey>();
        tempMonkey.square = square;
        tempMonkey.spawner = this;
    }
}


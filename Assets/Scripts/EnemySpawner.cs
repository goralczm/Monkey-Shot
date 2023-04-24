using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawner;
    public static int enemyCount;

    [SerializeField] GameObject enemyPrefab;
    
    void Spawn() 
    {
        float x = spawner.transform.localScale.x / 2;
        float y = spawner.transform.localScale.y / 2;
        Monkey tempMonkey = Instantiate(enemyPrefab, new Vector2(Random.Range(-x,x),Random.Range(-y,y)), enemyPrefab.transform.rotation).GetComponent<Monkey>();
        tempMonkey.spawner = gameObject;
        enemyCount++;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;
            //spawner = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount < 5) 
        {
            Spawn();
        }
    }
}

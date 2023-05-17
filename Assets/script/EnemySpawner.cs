using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float interval = 2.5f;


    private void Start()
    {
        StartCoroutine(spawnEnemy(interval, enemyPrefab));
        
    }

   private IEnumerator spawnEnemy(float interval,GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-56, 6), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }









}

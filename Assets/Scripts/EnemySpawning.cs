using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawning : MonoBehaviour
{
    public EnemyTemplate[] enemyTypes;

    public Enemy enemyToSpawn;
    public int enemyCount;


    public Transform[] top;
    public Transform[] left;
    public Transform[] right;
    public Transform[] bottom;

    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            SpawnMonkey();
        }
    }

    public void SpawnMonkey()
    {
        //Wylosowaæ gdzie ma³pa ma siê pojawiæ
        //Stworzyæ ma³pê w tym miejscy
        //Wylosowaæ jej typ ma³py

        int side = Random.Range(1, 5); //Losuje stronê
        Enemy newMonkey = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        newMonkey.PopulateInfo(enemyTypes[Random.Range(0, enemyTypes.Length)]);

        
        switch (side)
        {
            case 1:
                int spawnPointIndex = Random.Range(0, top.Length); //Losuje spawnpoint z tej strony
                newMonkey.transform.position = top[spawnPointIndex].position;
                break;
            case 2:
                spawnPointIndex = Random.Range(0, right.Length); //Losuje spawnpoint z tej strony
                newMonkey.transform.position = right[spawnPointIndex].position;
                break;
            case 3:
                spawnPointIndex = Random.Range(0, bottom.Length); //Losuje spawnpoint z tej strony
                newMonkey.transform.position = bottom[spawnPointIndex].position;
                break;
            case 4:
                spawnPointIndex = Random.Range(0, left.Length); //Losuje spawnpoint z tej strony
                newMonkey.transform.position = left[spawnPointIndex].position;
                break;
        }

        //Wylosowaæ gdzie ma³pa ma iœæ
        int otherSide = Random.Range(1, 5);
        while (otherSide == side)
        {
            otherSide = Random.Range(1, 5);
        }

        switch (otherSide)
        {
            case 1:
                int spawnPointIndex = Random.Range(0, top.Length); //Losuje spawnpoint z tej strony
                newMonkey.destination = top[spawnPointIndex]; //Przypisaæ ma³piê gdzie ma iœæ
                break;
            case 2:
                spawnPointIndex = Random.Range(0, right.Length); //Losuje spawnpoint z tej strony
                newMonkey.destination = right[spawnPointIndex]; //Przypisaæ ma³piê gdzie ma iœæ
                break;
            case 3:
                spawnPointIndex = Random.Range(0, bottom.Length); //Losuje spawnpoint z tej strony
                newMonkey.destination = bottom[spawnPointIndex]; //Przypisaæ ma³piê gdzie ma iœæ
                break;
            case 4:
                spawnPointIndex = Random.Range(0, left.Length); //Losuje spawnpoint z tej strony
                newMonkey.destination = left[spawnPointIndex]; //Przypisaæ ma³piê gdzie ma iœæ
                break;
        }
        
        newMonkey.spawner = this;
    }
}

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
        //Wylosowa� gdzie ma�pa ma si� pojawi�
        //Stworzy� ma�p� w tym miejscy
        //Wylosowa� jej typ ma�py

        int side = Random.Range(1, 5); //Losuje stron�
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

        //Wylosowa� gdzie ma�pa ma i��
        int otherSide = Random.Range(1, 5);
        while (otherSide == side)
        {
            otherSide = Random.Range(1, 5);
        }

        switch (otherSide)
        {
            case 1:
                int spawnPointIndex = Random.Range(0, top.Length); //Losuje spawnpoint z tej strony
                newMonkey.destination = top[spawnPointIndex]; //Przypisa� ma�pi� gdzie ma i��
                break;
            case 2:
                spawnPointIndex = Random.Range(0, right.Length); //Losuje spawnpoint z tej strony
                newMonkey.destination = right[spawnPointIndex]; //Przypisa� ma�pi� gdzie ma i��
                break;
            case 3:
                spawnPointIndex = Random.Range(0, bottom.Length); //Losuje spawnpoint z tej strony
                newMonkey.destination = bottom[spawnPointIndex]; //Przypisa� ma�pi� gdzie ma i��
                break;
            case 4:
                spawnPointIndex = Random.Range(0, left.Length); //Losuje spawnpoint z tej strony
                newMonkey.destination = left[spawnPointIndex]; //Przypisa� ma�pi� gdzie ma i��
                break;
        }
        
        newMonkey.spawner = this;
    }
}

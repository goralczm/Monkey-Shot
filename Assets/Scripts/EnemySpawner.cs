using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Monkey;
    public Transform square;
    public List<Transform> points;
    [HideInInspector]
    public bool isTaken;
    
    [SerializeField]
    MovementEnum MovementType = new MovementEnum();

    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f, angularSpeed = 2f;

    [SerializeField]
    float xDivider, yDivider = 1f;

    [SerializeField]
    bool isFreezing;

    [SerializeField]
    int freezeIndex;

    [SerializeField]
    float howLongToFreeze;

    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            points.Add(transform.GetChild(i));
        }
        isTaken = false;
    }

    public void SpawnMonkeyOnPosition()

    {
        Monkey tempMonkey = Instantiate(Monkey, transform.position, Quaternion.identity).GetComponent<Monkey>();
        tempMonkey.square = square;
        tempMonkey.waypoints = points;
        tempMonkey.originSpawner = this;
        tempMonkey.MovementType = MovementType;
        tempMonkey.rotationCenter = rotationCenter;
        tempMonkey.rotationRadius = rotationRadius;
        tempMonkey.angularSpeed = angularSpeed;
        tempMonkey.xDivider = xDivider;
        tempMonkey.yDivider = yDivider;
        tempMonkey.isFreezing = isFreezing;
        tempMonkey.freezeIndex = freezeIndex;
        tempMonkey.howLongToFreeze = howLongToFreeze;
        isTaken = true;
    }
    /*public void SpawnEnemyInRandomLocation()
    {
        float x_border = Random.Range((-square.localScale.x/2)+1, (square.localScale.x/2)-1);
        float y_border = Random.Range((-square.localScale.y/2)+1, (square.localScale.y/2)-1);
        Monkey tempMonkey = Instantiate(Monkey, new Vector2(x_border, y_border), Quaternion.identity).GetComponent<Monkey>();
        tempMonkey.square = square;
    }
    */
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public float speed = 5f;
    public Transform square;
    //Vector2 direction;
    public bool canEnemyMove;
    public List<Transform> waypoints;
    public EnemySpawner originSpawner;

    public MovementEnum MovementType;

    public Transform rotationCenter;
    public float rotationRadius;
    public float angularSpeed;
    public float xDivider;
    public float yDivider;
    public int freezeIndex;
    public bool isFreezing;
    public float howLongToFreeze;
    public GameObject monkeyHitEffect;
    public bool useVine;
    public LineRenderer lineRenderer;
    public Transform vinePoint;
    void Start()
    {
        //direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    void Update()
    {
        if(useVine)
        {
            lineRenderer.enabled = true;

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, vinePoint.position);
        }
        /*if (!canEnemyMove)
            return;

        if (Mathf.Abs(transform.position.x) >= (square.localScale.x / 2) - 1)
        {
            direction = new Vector2(-direction.x, direction.y);
        }

        if (Mathf.Abs(transform.position.y) >= (square.localScale.y / 2) - 1)
        {
            direction = new Vector2(direction.x, -direction.y);
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);
        */

    }

    public void KillMonkey()
    {
        Instantiate(monkeyHitEffect, transform.position, Quaternion.identity);
        GameManager.money++;
        SpawnManager.currentMonkeyCount--;
        originSpawner.isTaken = false;
        Destroy(gameObject);
    }

}

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
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }

            lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 2));
            lineRenderer.SetPosition(1, new Vector3(vinePoint.position.x, vinePoint.position.y, 2));
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

    public void PlayHit(Vector3 hitPosition)
    {
        Instantiate(monkeyHitEffect, hitPosition, Quaternion.identity);
    }

    public void KillMonkey()
    {
        if (useVine)
        {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }
        GameManager.money++;
        SpawnManager.currentMonkeyCount--;
        originSpawner.isTaken = false;
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public float speed = 5f;
    public Transform square;
    Vector2 direction;
    public EnemySpawner spawner;

    void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x) >= (square.localScale.x/2)-1)
        {
            direction = new Vector2(-direction.x, direction.y);
        }

        if (Mathf.Abs(transform.position.y) >= (square.localScale.y/2)-1)
        {
            direction = new Vector2(direction.x, -direction.y);
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public void KillMonkey()
    {
        GameManager.money++;
        Destroy(gameObject);
    }

}

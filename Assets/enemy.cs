using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class enemy : MonoBehaviour
{
    public float speed = 1f;
    
    private float cooldownTimer = 0.05f;
    private Vector2 dir;

    public Transform planeDimensions;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

    }
    void Update()
    {



        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            if (Mathf.Abs(transform.position.x) + transform.localScale.x / 2 >= planeDimensions.localScale.x / 2)
            {
                dir = new Vector2(-dir.x,dir.y);
            }
            if (Mathf.Abs(transform.position.y) + transform.localScale.y / 2 >= planeDimensions.localScale.y / 2)
            {
                dir = new Vector2(dir.x, -dir.y);
            }
            cooldownTimer = 0.05f;
        }
        
        transform.Translate(dir.normalized * Time.deltaTime * speed);

    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }


}

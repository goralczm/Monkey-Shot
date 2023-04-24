using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public GameObject spawner;
    private Vector3 direction;

    [SerializeField] GameObject shotEffect;
    [SerializeField] float speed;

    //Usage of lastX and lastY - to refer which wall was last touched by monkey, to avoid changing direction multiple times by one wall
    bool lastX = false; // Last touched wall by monkey, false - left wall, true - right wall 
    bool lastY = false; // Last touched wall by monkey, false - down wall, true - up wall 

    void Start()
    {
        float x;
        float y;
        do
        {
            x = Random.Range(-1f, 1f);
        }
        while (x == 0);
        do
        {
            y = Random.Range(-1f, 1f);
        }
        while (y == 0);

        if (x < 0) lastX = true;
        if (y < 0) lastY = true;

        direction = new Vector3(x, y, 0);
    }

    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;

        if ((transform.position.x >= spawner.transform.localScale.x / 2 && !lastX)
            || 
            (transform.position.x <= spawner.transform.localScale.x / 2 * -1 && lastX)) 
        {
            direction.x *= -1;
            if (transform.position.x > 0) lastX = true;
            else lastX = false;
        }
        if ((transform.position.y >= spawner.transform.localScale.y / 2 && !lastY)
            ||
            (transform.position.y <= spawner.transform.localScale.y / 2 * -1 && lastY))
        {
            direction.y *= -1;
            if (transform.position.y > 0) lastY = true;
            else lastY = false;
        }
    }
    private void OnMouseDown() // To delete when shoting using raycast will be done
    {
        Debug.Log(Gun.currAmmo);
        if (Gun.currAmmo <= 0)
        {
            
            return; 
        }
        EnemySpawner.enemyCount--;
        GameManager.points++;
        Gun.currAmmo--;
        Instantiate(shotEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}

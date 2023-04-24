using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public GameObject spawner;
    public GameObject shotEffect;
    Vector3 direction;
    public float speed;
    int ostatniaX = 0; // 0-lewa, 1-prawa
    int ostatniaY = 0; // 0-lewa, 1-prawa
    // Start is called before the first frame update

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

        if (x < 0) ostatniaX = 1;
        if (y < 0) ostatniaY = 1;

        direction = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * speed *Time.deltaTime;

        if ((transform.position.x >= spawner.transform.localScale.x / 2 && ostatniaX == 0)
            || 
            (transform.position.x <= spawner.transform.localScale.x / 2 * -1 && ostatniaX == 1)) 
        {
            direction.x *= -1;
            if (transform.position.x > 0) ostatniaX = 1;
            else ostatniaX = 0;
        }
        if ((transform.position.y >= spawner.transform.localScale.y / 2 && ostatniaY == 0)
            ||
            (transform.position.y <= spawner.transform.localScale.y / 2 * -1 && ostatniaY == 1))
        {
            direction.y *= -1;
            if (transform.position.y > 0) ostatniaY = 1;
            else ostatniaY = 0;
        }
    }
    private void OnMouseDown()
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

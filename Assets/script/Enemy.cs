using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public float speed = 4f;
    private float x;
    private float y;
    public GameObject fajerwerki;
   
   
   


    private void Start()
    {
       
      // x = Random.Range(-2f, 2f);
      // y = Random.Range(-2f, 2f);
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(x, y).normalized * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) >= 10)
        {
            x = -x;

        }
        if (Mathf.Abs(transform.position.y) >= 4.5)
        {
            y = -y;
        }
    }

    public void HitMonkey()
    {
        Destroy(gameObject);

        Instantiate(fajerwerki, transform.position, Quaternion.identity);
        if (Gun.currentAmmo <= 0)
        {
            return;
        }
        points.scoreNum += 10;

    }

}

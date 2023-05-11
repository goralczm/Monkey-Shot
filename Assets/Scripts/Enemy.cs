using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.PlasticSCM.Editor.WebApi;
using TMPro;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public EnemyTemplate enemyType;

    int hp;

    private float cooldownTimer = 0.05f;
    private Vector2 dir;

    public Transform planeDimensions;

    private SpriteRenderer rend;

    public EnemySpawning spawner;


    private void Start()
    {
        //GetComponent<SpriteRenderer>().color = Color.orange  new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        rend = GetComponent<SpriteRenderer>();
        rend.sprite = enemyType.nazwaSprite;
        rend.color = Color.white;
        
        PopulateInfo(enemyType);

        hp = enemyType.health;

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
        
        transform.Translate(dir.normalized * Time.deltaTime * enemyType.speed);



    }
    public void HitMonkey(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            
            StopAllCoroutines();
            Destroy(gameObject);

            GameManager.Instance.AddPoints(enemyType.pointsReward);

            spawner.spawnMonkey();

            return;
        }

        StartCoroutine(HitEffect());

    }
    IEnumerator HitEffect()
    {
        rend.color = Color.red;
        yield return new WaitForSeconds(.3f);
        rend.color = Color.white;
    }

    public void PopulateInfo(EnemyTemplate newEnemy)
    {
        enemyType = newEnemy;

    }


}

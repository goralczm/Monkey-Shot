using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.PlasticSCM.Editor.WebApi;
using TMPro;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public EnemyTemplate enemyType;
    public EnemySpawning spawner;
    public Transform destination;

    private SpriteRenderer rend;
    private int hp;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (destination == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, destination.position, Time.deltaTime * enemyType.speed);

        if (transform.position == destination.position)
        {
            spawner.SpawnMonkey();
            Destroy(gameObject);
        }
    }

    public void HitMonkey(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {

            StopAllCoroutines();
            Destroy(gameObject);

            GameManager.Instance.AddPoints(enemyType.pointsReward);

            spawner.SpawnMonkey();

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
        hp = enemyType.health;

        if (rend == null)
            rend = GetComponent<SpriteRenderer>();
        rend.sprite = enemyType.sprite;
    }
}

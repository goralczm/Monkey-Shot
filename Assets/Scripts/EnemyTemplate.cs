using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemys/New Enemy")]
public class EnemyTemplate : ScriptableObject
{
    public new string name;
    public int health;
    public float speed = 1f;
    public int pointsReward;
    //public string monkeySound;
    //public string deathSound;

    public Sprite nazwaSprite;

}

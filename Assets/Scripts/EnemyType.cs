using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemyType : ScriptableObject
{
    public string enemyName;
    public Sprite enemySprite;
    public int enemyMaxHP;
    public int enemyPoints;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guns/New Gun")]
public class GunTemplate: ScriptableObject
{
    public new string name;
    public int damage;
    public int reloadSpeed;
    public int magCapacity;
    public int maxAmmo;
    //public string shotSound;
    //public string reloadSound;

    public Sprite nazwaSprite;

}

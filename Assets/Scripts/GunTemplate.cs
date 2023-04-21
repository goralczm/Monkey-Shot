using UnityEngine;

[CreateAssetMenu(menuName = "Guns/New Gun")]
public class GunTemplate : ScriptableObject
{
    public new string name;
    public float rateOfFire;
    public int magSize;
    public float reloadTime;
    public GameObject shootEffect;
    public Sprite crosshair;
    public Sprite handSprite;
}

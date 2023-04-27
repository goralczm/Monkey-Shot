using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Gun")]
public class GunType : ScriptableObject
{
    public string gunName;
    public Sprite gunSprite;
    public int magSize;
    public AnimatorController animController;
}
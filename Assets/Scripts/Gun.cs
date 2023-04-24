using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI reloadText;

    [SerializeField] GunType weapon;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] int totalAmmo;
    public static int currAmmo;
    private int magSize;

    private void Start()
    {
        reloadText.gameObject.SetActive(false);

        spriteRenderer.sprite = weapon.gunSprite;
        magSize = weapon.magSize;
        currAmmo = magSize;
    }

    private void Update()
    {
        ammoText.text = "Ammo: " + currAmmo.ToString() + "/" + totalAmmo.ToString();
    }

    public void Reload()//In future to reload info text work properly, do this method: IEnumerator start coroutine
    {

        if (currAmmo < magSize && totalAmmo > 0)
        {
            if (totalAmmo - (magSize - currAmmo) < 0)
            {
                currAmmo += totalAmmo;
                totalAmmo = 0;
            }
            else
            { 
                totalAmmo -= magSize - currAmmo;
                currAmmo += magSize - currAmmo;
            }
            reloadText.gameObject.SetActive(true);
        }
    }

    public void Shot() 
    {
        return;//In future do shoting using raycasting
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI reloadText;

    [SerializeField] GameObject shotEffect;
    ParticleSystem.MainModule shotPSMain;

    [SerializeField] GunType weapon;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] int totalAmmo;
    public static int currAmmo;
    private int magSize;
    private bool canShot; // stores info if you can start shot function (e.g. you can't during reloading)
    private bool isShooting; // stores info if is shot function still going

    private void Start()
    {
        canShot = true;
        isShooting = false;
        reloadText.gameObject.SetActive(false);
        shotPSMain = shotEffect.GetComponent<ParticleSystem>().main;
        spriteRenderer.sprite = weapon.gunSprite;
        magSize = weapon.magSize;
        currAmmo = magSize;
    }

    private void Update()
    {
        ammoText.text = "Ammo: " + currAmmo.ToString() + "/" + totalAmmo.ToString();
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Shot());
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {

        if (totalAmmo <= 0 || currAmmo >= magSize || isShooting) yield break;
        reloadText.gameObject.SetActive(true);
        canShot = false;
        yield return new WaitForSeconds(1f);

        reloadText.gameObject.SetActive(false);

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
        
        canShot = true;
        
    }

    public IEnumerator Shot()
    {
        if (Gun.currAmmo > 0 && canShot)
        {
            isShooting = true;
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(rayOrigin.origin, rayOrigin.direction, Mathf.Infinity);

            if (hitInfo.collider != null)
            {
                Monkey target = hitInfo.transform.GetComponent<Monkey>();
                target.KillMonkey();
                GameManager.points++;
                shotPSMain.startColor = Color.red;
            }
            else 
            {
                shotPSMain.startColor = Color.yellow;
            }
            currAmmo--;
            Instantiate(shotEffect, rayOrigin.origin, Quaternion.identity);
            canShot = false;
            yield return new WaitForSeconds(0.4f);
            canShot = true;
            isShooting = false;

        }
    }
}

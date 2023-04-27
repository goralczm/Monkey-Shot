using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class Gun : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI reloadText;

    [SerializeField] GameObject shotEffect;
    private ParticleSystem.MainModule shotPSMain;

    [SerializeField] GunType weapon;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] int totalAmmo;
    public static int currAmmo;
    private int magSize;
    private bool canShot; // stores info if you can start shot function (e.g. you can't during reloading)
    private bool isShooting; // stores info if is shot function still going
    private bool isReloading;// stores info if gun is reloading;

    public Transform cameraTransform;
    private Vector2 startPos;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();

        isReloading = false;
        canShot = true;
        isShooting = false;
        reloadText.gameObject.SetActive(false);
        shotPSMain = shotEffect.GetComponent<ParticleSystem>().main;

        spriteRenderer.sprite = weapon.gunSprite;
        magSize = weapon.magSize;
        currAmmo = magSize;
        anim.runtimeAnimatorController = weapon.animController;
        startPos = (Vector2)transform.position + new Vector2(1,-0.5f) ;

    }

    private void Update()
    {
        ammoText.text = "Ammo: " + currAmmo.ToString() + "/" + totalAmmo.ToString();
        if (Input.GetMouseButtonDown(0))
            Shot();
        if (Input.GetKeyDown(KeyCode.R))
            Reload();

        if (!PauseMenu.isPaused)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = startPos + (mousePos * 0.2f) + (Vector2)cameraTransform.position;
        }
    }   

    public async void Reload()
    {

        if (totalAmmo <= 0 || currAmmo >= magSize || isShooting || isReloading || PauseMenu.isPaused) return;
        reloadText.gameObject.SetActive(true);
        canShot = false;
        isReloading = true;
        await Task.Delay(1000);

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
        isReloading = false;
        
    }

    public async void Shot()
    {
        if (Gun.currAmmo > 0 && canShot && !PauseMenu.isPaused)
        {
            isShooting = true;
            anim.Play("Gun_Shot");
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hitInfos = Physics2D.Raycast(rayOrigin.origin, rayOrigin.direction, Mathf.Infinity);

            if (hitInfos.collider != null)
            {
                Monkey target = hitInfos.transform.GetComponent<Monkey>();
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
            await Task.Delay(200);
            canShot = true;
            isShooting = false;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Gun : MonoBehaviour
{
    public GunTemplate gunType;

    public static Vector2 mouseLocation;
    public float rateOfFire = 1f;
    public float shootDelay = 0;         //shooting
    bool canShoot = true;
    bool isReloading = false;
    bool canMove = true;

    public int totalAmmo=20;
    public int ammoInMag;
    public TextMeshProUGUI reloadText;
    public TextMeshProUGUI ammoText;
    public int magSize = 7;
    public float reloadTime;

    public GameObject shootEffect;
    public EnemySpawner enemySpawner;
    public SpriteRenderer crosshairRend;
    public SpriteRenderer handRend;
    public Transform cameraTransform;
    //HandMovement
    [Range(0.2f, 1f)] public float movementSensitivity;

    private Vector2 startPos;

    private void Start()
    {
        PopulateInfo(gunType);
        startPos = transform.position;
    }
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 newPos = (Vector2)cameraTransform.position + startPos + (mousePos * movementSensitivity);

        if (canMove)
            transform.position = newPos;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isReloading == false && ammoInMag!=magSize && totalAmmo!=0)
            {
                canShoot = false;
                StartCoroutine(Reload());
            }
        }

        ammoText.text = "Ammo: " + ammoInMag.ToString() + "/" + totalAmmo.ToString();
        if (ammoInMag > 0)
        {
            if (shootDelay <= 0 && isReloading==false)
            {
                canShoot = true;
                //reloadText.text = "Ready to shoot!";
            }
            if (shootDelay > 0)
            {
                shootDelay -= Time.deltaTime;
                //reloadText.text = "Next bullet: " + countdown.ToString("F1");
            }
        }
        else
        {
            if(totalAmmo==0)
            {
                reloadText.text = "Out Of Ammo!";
            }
            else if (isReloading == false)
            {
                reloadText.text = "Need to reload!";
            }
        }
    }
    void Shoot()
    {
        if (canShoot)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit.collider != null)
            {
                Monkey target = hit.transform.GetComponent<Monkey>();
                target.KillMonkey();
                enemySpawner.SpawnEnemy();
            }
            Instantiate(shootEffect, ray.origin, Quaternion.identity);
            ammoInMag--;
            canShoot = false;
            shootDelay = rateOfFire;
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        reloadText.text = "Reloading";
        canMove = false;
        transform.position = new Vector3(transform.position.x, -17);
        yield return new WaitForSeconds(reloadTime);

        totalAmmo += ammoInMag;
        if (totalAmmo < magSize)
        {
            ammoInMag = totalAmmo;
            totalAmmo -= totalAmmo;
        }
        else
        {
            ammoInMag = magSize;
            totalAmmo -= magSize;
        }
        reloadText.text = "";
        isReloading = false;
        canMove = true;
    }

    public void PopulateInfo(GunTemplate newGun)
    {
        gunType = newGun;
        rateOfFire = gunType.rateOfFire;
        reloadTime = gunType.reloadTime;
        magSize = gunType.magSize;
        ammoInMag = magSize;
        shootDelay = rateOfFire;
        crosshairRend.sprite = gunType.crosshair;
        handRend.sprite = gunType.handSprite;
    }
}

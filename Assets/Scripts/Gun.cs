using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunTemplate gunType;

    public int damage = 1;

    public int maxAmmo = 50;
    private int magCapacity = 8;
    private int currAmmo;

    public TextMeshProUGUI magazineText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI scoreText;

    public float reloadSpeed = 2f;
    private bool isReloading;
    private void Start()
    {
        currAmmo = magCapacity;

        Enemy.points = 0;

        PopulateInfo(gunType);

    }
    void Update()
    {

        if(Time.timeScale == 0f){
            return;
        }

        magazineText.SetText("Magazine: " + currAmmo.ToString());
        ammoText.SetText("Ammo left: " + maxAmmo.ToString());
        scoreText.SetText("Score: " + Enemy.points.ToString());

        if (Input.GetMouseButtonDown(0) && !isReloading && currAmmo > 0)
        {
            Shoot();
        }
        

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
        float modifier = 0;

        if (mousePos.x >= 0)
        {
            targetRot = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            modifier = -180;
        }
        else
        {
            targetRot = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }

            transform.rotation = Quaternion.Euler(0, targetRot.z * 100 + modifier, 0);
        
    }
    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);



        if (hit.collider != null)
        {
            Enemy target = hit.transform.GetComponent<Enemy>();
            target.HitMonkey(damage);
        }
        currAmmo -= 1;

        if (currAmmo == 0 && maxAmmo > 0)
        {
            StartCoroutine(ReloadEffect());
            
        }
       
    }
    IEnumerator ReloadEffect()
    {

        isReloading = true;
        magazineText.SetText("OUT OF AMMO");
        ammoText.SetText("OUT OF AMMO");
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        yield return new WaitForSeconds(reloadSpeed);
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);

        maxAmmo -= magCapacity;
        if (maxAmmo < 0)
        {
            currAmmo = magCapacity - Mathf.Abs(maxAmmo);
            maxAmmo = 0;

        }
        else
        {
            currAmmo = magCapacity;
        }
        
        isReloading = false;
    }

    public void PopulateInfo(GunTemplate newGun)
    {
        gunType = newGun;

        damage = gunType.damage;
        reloadSpeed = gunType.reloadSpeed;
        magCapacity = gunType.magCapacity;
        maxAmmo = gunType.maxAmmo;
    }

}
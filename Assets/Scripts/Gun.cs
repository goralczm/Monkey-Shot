using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 1;

    public int maxAmmo = 50;
    private int magCapacity = 8;
    private int currAmmo;

    public TextMeshProUGUI magazineText;
    public TextMeshProUGUI ammoText;

    private void Start()
    {
        currAmmo = magCapacity;
    }
    void Update()
    {

        magazineText.SetText("Magazine: " + currAmmo.ToString());
        ammoText.SetText("Ammo left: " + maxAmmo.ToString());
        


        if (Input.GetMouseButtonDown(0))
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
       
        transform.rotation = Quaternion.Euler(0, targetRot.z * 100+modifier, 0);


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
        
        if (currAmmo == 0)
        {
            
            maxAmmo -= magCapacity; //42 34 26 18 10 2
            currAmmo = magCapacity; //8
        }
            //0       // 8
        if (maxAmmo < magCapacity && maxAmmo != 0)
        {
            currAmmo = maxAmmo;//2
            maxAmmo = 0; // maxammo - maxammo
            
        }
        

        if(currAmmo == 0 && maxAmmo == 0)
        {
            magazineText.SetText("OUT OF AMMO");
            ammoText.SetText("OUT OF AMMO");
        }



    }
}

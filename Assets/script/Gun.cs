using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gun : MonoBehaviour
{

    public TextMeshProUGUI MaxAmmotext;
    public static int currentAmmo;
    
    void Start()
    {
        currentAmmo = 5;
        MaxAmmotext.text = "Ammo 5 /" + currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        MaxAmmotext.text = "Ammo 5/" + currentAmmo.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }
    }

    public void reload()
    {
        if (!Pause.isPaused) {
            currentAmmo += 5;
            MaxAmmotext.text = "Ammo 5/" + currentAmmo.ToString();
        } }

    public void Shoot()
    {
        if (currentAmmo > 0 && !Pause.isPaused) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider != null)
            {
                Enemy target = hit.transform.GetComponent<Enemy>();
                target.HitMonkey();
            }
            Gun.currentAmmo -= 1;
        } }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour
{
    public TextMeshProUGUI MaxAmmotext;
    public static int currentAmmo;
    

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = 5;
        MaxAmmotext.text = "Ammo 5 /" + currentAmmo.ToString();
    }

   
    // Update is called once per frame
    void Update()
    {
        MaxAmmotext.text = "Ammo 5/" + currentAmmo.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }
        
    }

    public void reload()
    {
        currentAmmo += 5;
        MaxAmmotext.text = "Ammo 5/" + currentAmmo.ToString();
    }

}

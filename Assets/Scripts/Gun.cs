using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    int magSize = 7;
    public static int currAmmo;
    int totalAmmo = 4;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI reloadText;

    private void Start()
    {
        currAmmo = magSize;
        reloadText.gameObject.SetActive(false);
    }

    private void Update()
    {
        ammoText.text = "Ammo: " + currAmmo.ToString() + "/" + totalAmmo.ToString();
    }

    public void Reload()//IEnumerator start coroutine
    {




        if (currAmmo < magSize && totalAmmo > 0)
        {
            if (magSize > totalAmmo)
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

}

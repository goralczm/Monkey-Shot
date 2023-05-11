using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopPanelUI;
    public static bool shopVisible;

    private void Start()
    {
        shopVisible = false;
    }

    public void OpenShopPanel() 
    {
        shopPanelUI.SetActive(true);
        shopVisible = true;
    }
    public void CloseShopPanel() 
    {
        shopPanelUI.SetActive(false);
        shopVisible = false;
    }
    public void BuyAmmo() 
    {
        if (GameManager.points > 0)
        {
            Gun.totalAmmo+=10;
            GameManager.points--;
        }
    }

}

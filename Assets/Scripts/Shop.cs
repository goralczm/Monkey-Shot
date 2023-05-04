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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !PauseMenu.isPaused) 
        {
            if (shopVisible)
            {
                CloseShopPanel();
            }
            else 
            {
                OpenShopPanel();
            }
        }   
    }

    void OpenShopPanel() 
    {
        shopPanelUI.SetActive(true);
        shopVisible = true;
    }
    void CloseShopPanel() 
    {
        shopPanelUI.SetActive(false);
        shopVisible = false;
    }
    public void BuyAmmo() 
    {
        if (GameManager.points > 0)
        {
            Gun.totalAmmo++;
            GameManager.points--;
        }
    }

}

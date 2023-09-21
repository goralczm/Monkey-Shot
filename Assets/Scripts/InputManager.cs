using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public Shop shopMenu;
    public Gun gun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.isGameOver) 
        {
            if (PauseMenu.isPaused && !PauseMenu.isControls)
            {
                StartCoroutine(pauseMenu.Resume());
            }
            else if (PauseMenu.isPaused && PauseMenu.isControls) 
            {
                pauseMenu.Controls();
            }
            else if (Shop.shopVisible) 
            {
                shopMenu.CloseShopPanel();
            }
            else
            {
                pauseMenu.Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && !PauseMenu.isPaused)
        {
            if (Shop.shopVisible)
            {
                shopMenu.CloseShopPanel();
            }
            else
            {
                shopMenu.OpenShopPanel();
            }
        }
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(gun.Shot());
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(gun.Reload());
    }
}

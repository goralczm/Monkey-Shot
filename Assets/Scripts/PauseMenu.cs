using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject crosshair;
    [SerializeField] Animator anim;

    private void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) 
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public async void Resume() 
    {
        Time.timeScale = 1f;
        anim.Play("PauseMenu_FadeOut");
        await Task.Delay(260);
        pauseMenuUI.SetActive(false);
        
        isPaused = false;
        crosshair.SetActive(true);
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        crosshair.SetActive(false);
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

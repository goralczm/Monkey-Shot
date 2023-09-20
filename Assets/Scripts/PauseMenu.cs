using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public static bool isControls;
    private bool isResuming;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject crosshair;
    [SerializeField] Animator anim;
    [SerializeField] GameObject controlsPanelUI;

    private void Start()
    {
        isControls = false;
        isPaused = false;
        isResuming = false;
    }

    public IEnumerator Resume() 
    {
        Time.timeScale = 1f;
        anim.Play("PauseMenu_FadeOut");
        isResuming = true;
        yield return new WaitForSeconds(0.26f);
        isResuming = false;
        pauseMenuUI.SetActive(false);
        
        isPaused = false;
        crosshair.SetActive(true);
        Cursor.visible = false;
    }
    public void ResumeWrapper() 
    {
        if (!isResuming)
        {
            StartCoroutine(Resume());
        }
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        crosshair.SetActive(false);
        Cursor.visible = true;
    }

    public void Controls() 
    {
        controlsPanelUI.SetActive(!isControls);
        isControls = !isControls;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

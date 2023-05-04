using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    private bool isResuming;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject crosshair;
    [SerializeField] Animator anim;

    private void Start()
    {
        isPaused = false;
        isResuming = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) 
            {
                StartCoroutine(Resume());
            }
            else
            {
                Pause();
            }
        }
    }

    IEnumerator Resume() 
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

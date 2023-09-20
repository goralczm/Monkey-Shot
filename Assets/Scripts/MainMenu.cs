using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject controlsTab;

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ControlsButton() 
    {
        controlsTab.SetActive(true);
    }

    public void ExitButton() 
    { 
        Application.Quit();
    }
}

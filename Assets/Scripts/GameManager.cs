using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject crosshair;
    public static int points;
    [SerializeField] TextMeshProUGUI pointsText;
    public static bool isGameOver;

    public float timeRemaining;
    public bool timerRunning = false;
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] GameObject GameOverPanelUI;
    [SerializeField] TextMeshProUGUI GameOverPoints;
    [SerializeField] TextMeshProUGUI highScorePoints;

    private void Start()
    {
        
        isGameOver = false;

        timeRemaining = 60f;
        timerRunning = true;
        points = 0;
        Time.timeScale = 1f;
    }
    private void Update()
    {
        pointsText.SetText( "Points: " + points.ToString());
        if (timerRunning) 
        {
            if(timeRemaining >= 1) 
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "Time Left: " + ((int)timeRemaining / 60).ToString() + ":";
                
                if((int)timeRemaining%60 < 10) 
                {
                    timerText.text += ("0"+((int)timeRemaining % 60).ToString());
                }
                else
                {
                    timerText.text += ((int)timeRemaining % 60).ToString();
                }
                
            }
            else 
            {
                timerRunning = false;
            }
        }
        else
        {
            if (!isGameOver) //Done this to prevent doing this step over and over after game is already over
            {
                Time.timeScale = 0f;
                PauseMenu.isPaused = true;
                GameOverPoints.text = "Your Score: " + points.ToString();

                if (PlayerPrefs.HasKey("highScore"))
                {
                    if (points > PlayerPrefs.GetInt("highScore")) 
                    {
                        PlayerPrefs.SetInt("highScore", points);
                    }
                }
                else 
                {
                    PlayerPrefs.SetInt("highScore", points);
                }

                highScorePoints.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();

                GameOverPanelUI.SetActive(true);
                crosshair.SetActive(false);
                Cursor.visible = true;
                isGameOver = true;

            }
        }
    }
}

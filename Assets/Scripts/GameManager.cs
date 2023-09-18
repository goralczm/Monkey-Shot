using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public static int points;
    [SerializeField] TextMeshProUGUI pointsText;

    public float timeRemaining;
    public bool timerRunning = false;
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] GameObject GameOverPanelUI;
    [SerializeField] TextMeshProUGUI GameOverPoints;

    private void Start()
    {
        timeRemaining = 60f;
        timerRunning = true;
        points = 0;
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
            Time.timeScale = 0f;
            GameOverPoints.text = "Your Score: " + points.ToString();
            GameOverPanelUI.SetActive(true);

        }
    }
}

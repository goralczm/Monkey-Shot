using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class points : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    public TextMeshProUGUI HighscoreText;
    public static int scoreNum;
    public static int highscoreNum;
    
    // Start is called before the first frame update

   
    void Start()
    {
        scoreNum = 0;
        highscoreNum = PlayerPrefs.GetInt("highscore", highscoreNum);
        MyscoreText.text = "Score : " + scoreNum.ToString();
        HighscoreText.text = "Highscore : "+ highscoreNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MyscoreText.text = "Score : " + scoreNum.ToString();
        HighscoreText.text = "Highscore : " + highscoreNum.ToString();

        if (scoreNum > highscoreNum)
        {
            highscoreNum = scoreNum;
            SaveHighscore();
        }

    }

    public void SaveHighscore()
    {
        PlayerPrefs.SetInt("highscore", highscoreNum); 

    }
   }

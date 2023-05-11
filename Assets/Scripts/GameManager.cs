using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public int points;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        AddPoints(0);
    }

    public void AddPoints(int newPoints)
    {
        points += newPoints;
        scoreText.SetText("Score: " + points);
    }
}

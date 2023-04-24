using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int points;
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        points = 0;        
    }
    private void Update()
    {
        pointsText.text = points.ToString(); 
    }
}

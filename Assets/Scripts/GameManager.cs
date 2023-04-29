using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum MovementEnum
{
    Backtracking,
    Linear,
    Circle
}
public class GameManager : MonoBehaviour
{
    public int startingMoney = 0;
    public static int money = 0;
    public TextMeshProUGUI moneyText;
    

    void Start()
    {
        money = startingMoney;
    }
    void Update()
    {
        moneyText.SetText("POINTS: " + money.ToString());
    }
}



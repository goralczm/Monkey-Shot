using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Combo : MonoBehaviour
{
    public TextMeshProUGUI combo;
   
    public static int comboNum;
    
    // Start is called before the first frame update
    void Start()
    {
        comboNum = 0;
        combo.text = "  ";
    }

    // Update is called once per frame
    void Update()
    {
        combo.text = "COMBO X " + combo.ToString();
    }

   
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlsPanel : MonoBehaviour
{ 
    public void BackButton() 
    {
        PauseMenu.isControls = false;
        gameObject.SetActive(false);
    }
}

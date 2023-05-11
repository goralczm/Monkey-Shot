using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    bool blockMovementRight = false;
    bool blockMovementLeft = false;
    void FixedUpdate()
    {
        if (EnemySpawner.spawner.transform.localScale.x / 2 <= transform.position.x)
        {
            blockMovementRight = true;
        }
        else
            blockMovementRight = false;

        if ((EnemySpawner.spawner.transform.localScale.x / 2) * (-1) >= transform.position.x)
        {
            blockMovementLeft = true;
        }
        else
            blockMovementLeft = false;

        if(Input.mousePosition.x < 200 && !blockMovementLeft) 
        {
            transform.position += new Vector3(-0.2f,0,0) ;
        }
        if(Input.mousePosition.x > 1720 && !blockMovementRight) 
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }
    }
}

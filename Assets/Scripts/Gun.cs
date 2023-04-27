using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static int damage;
    public int jakiDamage = 1;
    private void Start()
    {
        damage = jakiDamage;
    }
    void Update()
    {


        
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        Quaternion targetRot = Quaternion.AngleAxis(angle, Vector3.forward);
        float modifier = 0;
        if (mousePos.x >= 0)
        {
            targetRot = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            modifier = -180;
        }
        else
        {
            targetRot = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
       
        transform.rotation = Quaternion.Euler(0, targetRot.z * 100+modifier, 0);


    }
    
}

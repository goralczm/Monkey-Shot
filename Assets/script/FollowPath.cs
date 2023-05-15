using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 5f;
    private int waypointsIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointsIndex].transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(waypointsIndex <= waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if(transform.position == waypoints[waypointsIndex].transform.position)
            {
                waypointsIndex += 1;
            }
        }
        else
        {
            waypointsIndex = 0;
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, moveSpeed * Time.deltaTime);

            
        }
    }
}

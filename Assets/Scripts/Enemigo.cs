using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField]List<Transform> wayPoints;
    float vel = 1;
    float distance = 0.2f;
    byte sigPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[sigPos].transform.position,
            vel*Time.deltaTime);

        if (Vector3.Distance(transform.position, wayPoints[sigPos].transform.position) < distance)
        {
            sigPos++;
            if (sigPos >= wayPoints.Count)
            {
                sigPos = 0;
            }

        }
    }
}

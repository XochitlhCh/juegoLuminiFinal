using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionCorazones : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pl;
    void Start()
    {

    }

    public GameObject[] corazones = new GameObject[3];

   

    // Update is called once per frame
    void Update()
    {
        transform.position = pl.transform.position;

        float pos = transform.position.x +12 ;
    }
}

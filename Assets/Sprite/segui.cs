using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segui : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pl.transform.position;
    }
}

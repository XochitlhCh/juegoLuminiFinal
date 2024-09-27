using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class segui : MonoBehaviour
{
    // Start is called before the first frame update

    public float masx;
    
    public GameObject pl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = pl.transform.position.x+masx;
        pos.y=pl.transform.position.y+2f;
        transform.position = pos;
  
    }
}

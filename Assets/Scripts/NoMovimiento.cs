using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMovimiento : MonoBehaviour
{
    GameObject Lumini;
    // Start is called before the first frame update
    void Start()
    {

    }


    public float up, down, left, right;
    // Update is called once per frame
    void Update()
    {
    }
    public void OnCollisionEnter(Collision collision)
    {
        print("xd123");
    }
    public float[] NoMov()
    {
        print("xd");
        return new float[4] { up, down, left, right };
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("x6");
    }

}

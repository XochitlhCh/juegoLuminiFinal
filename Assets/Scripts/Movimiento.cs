using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D RigidBody2D;
    public Text Ganaste;
    private byte speed = 5;
    void Start()
    {
       
        RigidBody2D = GetComponent<Rigidbody2D>();//toma el componente de rigidbody y lo mete al script

    }

    // Update is called once per frame

    float x, y;
    private byte health = 3;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        //transform.Translate(x, y, 0);

        RigidBody2D.velocity = new Vector2(x*speed, y*speed);
    }


   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Debug.Log("Wall hit");
            health--;
            if (health == 0)
            {
                Ganaste.text = "PERDISTE :(";
            }
        }
        else if (collision.gameObject.tag == "Tierra")
        {
            Ganaste.text = "¡GANASTE!";
        }
      
    }
}

   

    



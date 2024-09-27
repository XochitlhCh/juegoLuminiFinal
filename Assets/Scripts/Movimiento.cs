using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movimiento : MonoBehaviour
{
   
    private Rigidbody2D RigidBody2D;
    public GameObject Ganaste;
    public byte speed = 5;
    float x, y;
    private float[] movements = new float[4] { 1, 1, 1, 1 }; //up, down, left, right 

    private byte health = 3;
    public GameObject[] corazones = new GameObject[3];
    public Transform PuntoDPartida;

    private bool canMove = true; // Nueva variable para controlar el movimiento

    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove) return; // Si no puede moverse, sale del método

        x = Input.GetAxis("Horizontal");

        if (movements[2]==0) //si abajo = 0/inactivo
        {
            if (x < 0)// si es hacia la izquierda x se vuelve 0
            {
                x= 0;
            }

        }

        if (movements[3] == 0)
        {
            if (x > 0)
            {
                x = 0;
            }

        }


        y = Input.GetAxis("Vertical");


        if (movements[0] == 0)
        {
            if (y > 0)
            {
                y = 0;
            }

        }

        if (movements[1] == 0)
        {
            if (y < 0)
            {
                y = 0;
            }

        }

        RigidBody2D.velocity = new Vector2(x * speed, y * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("x6");

        if (collision.gameObject.tag == "Walls")
        {
            Debug.Log("Wall hit");
            health--;
            if (health > 0)
            {
                RespawnPlayer();
                ActualizarCorazones();
            }
            else
            {
                Ganaste.SetActive(true);
                print("LOSER");
                canMove = false; // Deshabilitar el movimiento
                //Invoke("ResetearJuego", 2f); // Reiniciar el juego después de 2 segundos
            }
        }
        



    }

    private void Winn(Collider2D collision)
    {
        if (collision.gameObject.tag == "NextLevel")
        {
            Ganaste.SetActive(true);
            canMove = false; // Deshabilitar el movimiento al ganar
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        NoMovimiento noMovimiento = collision.GetComponent<NoMovimiento>();
        print("xd2");
        
        if (noMovimiento !=null)
        {
            print("xd3");

            movements = noMovimiento.NoMov();
        }
    }


    void RespawnPlayer()
    {
        transform.position = PuntoDPartida.position;
        RigidBody2D.velocity = Vector2.zero;
    }

    void ActualizarCorazones()
    {
        if (health >= 0 && health < corazones.Length)
        {
            corazones[health].SetActive(false);
        }
    }

    void ResetearJuego()
    {
        health = 3;
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].SetActive(true);
        }
        Ganaste.SetActive(false);// Limpiar el mensaje de "Perdiste"
        canMove = true; // Volver a habilitar el movimiento
        RespawnPlayer(); // Regresar al punto de inicio
    }



}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

//public class Movimiento : MonoBehaviour
//{
//    private Rigidbody2D RigidBody2D; // este es el player
//    public Text Ganaste; // text es una propiedad q pertenece a un objeto en el juego
//    private byte speed = 5;
//    float x, y;

//    private byte health = 3;
//    public GameObject[] corazones = new GameObject[3];  //arreglo de objetos dentro del juego
//    public Transform PuntoDPartida; // transform es una propiedad de un objeto que guarda unas coordenadas para que cuando se reinicie aparezca en cierto punto

//    private bool canMove = true; // Variable para controlar el movimiento

//    // Variables para evitar retrocesos
//    private string lastDirection = ""; // Mantendrá la última dirección de movimiento (up, down, left, right)

//    void Start()
//    {
//        RigidBody2D = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        if (!canMove) return; // Si no puede moverse, sale del método

//        x = Input.GetAxis("Horizontal");
//        y = Input.GetAxis("Vertical");

//        // Lógica para evitar retrocesos
//        if (x > 0 && lastDirection != "left") // Movimiento hacia la derecha permitido si no vino de la izquierda
//        {
//            lastDirection = "right";
//        }
//        else if (x < 0 && lastDirection != "right") // Movimiento hacia la izquierda permitido si no vino de la derecha
//        {
//            lastDirection = "left";
//        }
//        else if (y > 0 && lastDirection != "down") // Movimiento hacia arriba permitido si no vino de abajo
//        {
//            lastDirection = "up";
//        }
//        else if (y < 0 && lastDirection != "up") // Movimiento hacia abajo permitido si no vino de arriba
//        {
//            lastDirection = "down";
//        }
//        else
//        {
//            // Si no cumple ninguna de las condiciones, bloquear el movimiento
//            x = 0;
//            y = 0;
//        }

//        // Aplicamos el movimiento
//        RigidBody2D.velocity = new Vector2(x * speed, y * speed);
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.tag == "Walls")
//        {
//            Debug.Log("Wall hit");
//            health--;
//            if (health > 0)
//            {
//                RespawnPlayer();
//                ActualizarCorazones();
//            }
//            else if(health<=0)
//            {
//                Ganaste.text = "Perdiste :(";
//                canMove = false; // Deshabilitar el movimiento
//                Invoke("ResetearJuego", 2f); // Reiniciar el juego después de 2 segundos
//            }
//        }
//        else if (collision.gameObject.tag == "Meta")
//        {
//            Ganaste.text = "¡GANASTE!";
//            canMove = false; // Deshabilitar el movimiento al ganar
//        }
//    }

//    void RespawnPlayer()
//    {
//        transform.position = PuntoDPartida.position;
//        RigidBody2D.velocity = Vector2.zero;
//        lastDirection = ""; // Reseteamos la dirección al reaparecer
//    }

//    void ActualizarCorazones()
//    {
//        if (health >= 0 && health < corazones.Length)
//        {
//            corazones[health].SetActive(false);
//        }
//    }

//    void ResetearJuego()
//    {
//        health = 3;
//        for (int i = 0; i < corazones.Length; i++)
//        {
//            corazones[i].SetActive(true);
//        }
//        Ganaste.text = ""; // Limpiar el mensaje de "Perdiste"
//        canMove = true; // Volver a habilitar el movimiento
//        RespawnPlayer(); // Regresar al punto de inicio
//    }
//}







using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movimiento : MonoBehaviour
{

    public AudioListener audioListener;

    public GameObject MiniMap;
    private Rigidbody2D RigidBody2D;
    public GameObject Ganaste;
    public byte speed = 3;
    public GameObject YouWin;
    float x, y;
    private float[] movements = new float[4] { 1, 1, 1, 1 }; //up, down, left, right 

    private byte health = 3;
    public GameObject[] corazones = new GameObject[3];
    public Transform PuntoDPartida;

    private bool canMove = true; // Nueva variable para controlar el movimiento

    void Start()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
        audioListener = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioListener>();

    }
    void Update()
    {
        if (!canMove) return; // Si no puede moverse, sale del método

        x = Input.GetAxis("Horizontal");

        if (movements[2] == 0) //si abajo = 0/inactivo
        {
            if (x < 0)// si es hacia la izquierda x se vuelve 0
            {
                x = 0;
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
                audioListener.PlaySFX(audioListener.loser);
                //RespawnPlayer();
                MiniMap.SetActive(false);
                canMove = false;
                Ganaste.SetActive(true);
                //why ganaste??? idk xochilth made this part well let me see that
                //ResetLevel(); // si quitas este jala la pantalla de game over creo

                //Invoke(nameof(ResetLevel), 2f);
                //print("LOSER");

                // Deshabilitar el movimiento
                //Invoke("ResetearJuego", 2f); // Reiniciar el juego después de 2 segundos
            }



        }
        else if (collision.gameObject.tag == "NextLevelMirror")/* pasar a 3er nivel*/
        {
            RespawnPlayer();
            MiniMap.SetActive(false);
            YouWin.SetActive(true);

            audioListener.PlaySFX(audioListener.YouWin);
            print("WINNER");
            canMove = false;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NoMovimiento noMovimiento = collision.GetComponent<NoMovimiento>();

        if (noMovimiento != null)
        {
            movements = noMovimiento.NoMov();
        }

        if (collision.CompareTag("NextLevel") /*|| collision.CompareTag("NextLevelMirror")*/)
        {
            StartCoroutine(EsperarYCambiarNivel()); // Llama a la corutina
        }
    }

    private IEnumerator EsperarYCambiarNivel()
    {
        canMove = false;
        RigidBody2D.velocity = Vector2.zero;       // se detiene por completo

        audioListener.PlaySFX(audioListener.YouWin);
        yield return new WaitForSeconds(1.5f);         // Espera 1seg

        SceneController.instance.NextLevel();        // Cambia de escena

    }

    void RespawnPlayer()
    {
        // Mover al jugador al punto de partida
        transform.position = PuntoDPartida.position;
        RigidBody2D.velocity = Vector2.zero;

        // falta hacer que cuando aparezca se tarde en poder moverse otra vez 

    }

    void ResetLevel()
    {
        //RespawnPlayer();

        // Reinicia el nivel actual
        SceneController.instance.LoadScene(SceneManager.GetActiveScene().name);

        // Restablecer el estado del jugador
        health = 3; // Reiniciar vidas
        ActualizarCorazones(); // Mostrar corazones nuevamente
        canMove = true; // Permitir movimiento
        Ganaste.SetActive(false); // Ocultar mensaje
        MiniMap.SetActive(true); // Mostrar minimapa
    }

    void ActualizarCorazones()
    {
        // Desactivar corazones según las vidas restantes
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].SetActive(i < health);
        }
    }
}

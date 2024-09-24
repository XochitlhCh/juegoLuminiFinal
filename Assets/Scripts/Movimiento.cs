using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

//public class Movimiento : MonoBehaviour
//{
//    // Start is called before the first frame update

//    private Rigidbody2D RigidBody2D;
//    public Text Ganaste;

//    private byte speed = 5;
//	float x, y;

//	private byte health = 3;
//    public GameObject[] corazones;
//    // public GameObject skull;

//    public Transform PuntoDPartida;
//    void Start()
//    {

//        RigidBody2D = GetComponent<Rigidbody2D>();//toma el componente de rigidbody y lo mete al script
//        //skull.setActive(false);
//    }

//    // Update is called once per frame


//    void Update()
//    {
//        x = Input.GetAxis("Horizontal");
//        y = Input.GetAxis("Vertical");


//        //transform.Translate(x, y, 0);

//        RigidBody2D.velocity = new Vector2(x*speed, y*speed);
//    }




//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.tag == "Walls")
//        {
//            Debug.Log("Wall hit");
//            health--;
//            if (health == 0)
//            {
//                Ganaste.text = "Perdiste :(";
//            }
//        }
//        else if (collision.gameObject.tag == "Tierra")
//        {
//            Ganaste.text = "¡GANASTE!";
//        }

//    }
//}
//public class Movimiento : MonoBehaviour
//{
//	private Rigidbody2D RigidBody2D;
//	public Text Ganaste;
//	private byte speed = 5;
//	float x, y;

//	private byte health = 3; 
//	public GameObject[] corazones = new GameObject[3]; // Arreglo de corazones en pantalla
//	//public GameObject skull; // Sprite que aparece cuando se terminan las vidas

//	public Transform PuntoDPartida; // Punto de partida

//	private float lastXDirection; // Variable para verificar la dirección del jugador

//	void Start()
//	{
//		RigidBody2D = GetComponent<Rigidbody2D>(); // Referencia al RigidBody
//		//skull.SetActive(false); // Desactivamos el sprite de la calavera inicialmente
//	}

//	void Update()
//	{
//		// Control de dirección, evitando retroceder
//		x = Input.GetAxis("Horizontal");
//		y = Input.GetAxis("Vertical");

//		if (x < 0 && lastXDirection > 0) // Si se intenta retroceder en el eje X
//		{
//			x = 0; // Bloqueamos el retroceso
//		}

//		lastXDirection = x; // Guardamos la dirección actual

//		RigidBody2D.velocity = new Vector2(x * speed, y * speed);
//	}

//	private void OnCollisionEnter2D(Collision2D collision)
//	{
//		if (collision.gameObject.tag == "Walls")
//		{
//			Debug.Log("Wall hit");
//			health--; // Reducimos una vida
//			if (health > 0)
//			{
//				RespawnPlayer(); // Volvemos al punto de partida
//				ActualizarCorazones(); // Actualizamos los corazones visibles
//			}
//			else
//			{
//				Ganaste.text = "Perdiste :("; // Mensaje de derrota
//				//skull.SetActive(true); // Mostramos el sprite de la calavera
//				RespawnPlayer(); // Volvemos al punto de partida
//				ResetearJuego(); // Reiniciamos el juego
//			}
//		}
//		else if (collision.gameObject.tag == "Tierra")
//		{
//			Ganaste.text = "¡GANASTE!"; // Mensaje de victoria
//		}
//	}

//	// Método que regresa al jugador al punto de inicio
//	void RespawnPlayer()
//	{
//		transform.position = PuntoDPartida.position; // Colocamos al jugador en el punto de partida
//		RigidBody2D.velocity = Vector2.zero; // Detenemos el movimiento al reaparecer
//	}

//	// Método para actualizar los corazones visibles
//	void ActualizarCorazones()
//	{
//		if (health >= 0 && health < corazones.Length)
//		{
//			corazones[health].SetActive(false); // Ocultamos el corazón correspondiente
//		}
//	}

//	// Método para reiniciar el juego
//	void ResetearJuego()
//	{
//		health = 3; // Reiniciamos las vidas
//		//skull.SetActive(false); // Ocultamos el sprite de la calavera
//		for (int i = 0; i < corazones.Length; i++)
//		{
//			corazones[i].SetActive(true); // Reactivamos los corazones
//		}
//	}
//}
public class Movimiento : MonoBehaviour
{
	private Rigidbody2D RigidBody2D;
	public Text Ganaste;
	private byte speed = 5;
	float x, y;

	private byte health = 3;
	public GameObject[] corazones = new GameObject[3]; // Arreglo de corazones en pantalla
													   //public GameObject skull; // Sprite que aparece cuando se terminan las vidas

	public Transform PuntoDPartida; // Punto de partida

	private Vector2 lastDirection; // Variable para verificar la última dirección del jugador

	void Start()
	{
		RigidBody2D = GetComponent<Rigidbody2D>(); // Referencia al RigidBody
		lastDirection = Vector2.zero; // Iniciamos la última dirección en cero
	}

	void Update()
	{
		// Capturamos la dirección del jugador
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		// Bloqueamos el retroceso en el eje X (horizontal)
		if ((x > 0 && lastDirection.x < 0) || (x < 0 && lastDirection.x > 0))
		{
			x = 0; // Bloqueamos el cambio de dirección horizontal
		}

		// Bloqueamos el retroceso en el eje Y (vertical)
		if ((y > 0 && lastDirection.y < 0) || (y < 0 && lastDirection.y > 0))
		{
			y = 0; // Bloqueamos el cambio de dirección vertical
		}

		// Actualizamos la última dirección
		if (x != 0 || y != 0)
		{
			lastDirection = new Vector2(x, y); // Guardamos la dirección actual si hubo movimiento
		}

		RigidBody2D.velocity = new Vector2(x * speed, y * speed);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Walls")
		{
			Debug.Log("Wall hit");
			health--; // Reducimos una vida
			if (health > 0)
			{
				RespawnPlayer(); // Volvemos al punto de partida
				ActualizarCorazones(); // Actualizamos los corazones visibles
			}
			else
			{
				Ganaste.text = "Perdiste :("; // Mensaje de derrota
				RespawnPlayer(); // Volvemos al punto de partida
				ResetearJuego(); // Reiniciamos el juego
			}
		}
		else if (collision.gameObject.tag == "Tierra")
		{
			Ganaste.text = "¡GANASTE!"; // Mensaje de victoria
		}
	}

	// Método que regresa al jugador al punto de inicio
	void RespawnPlayer()
	{
		transform.position = PuntoDPartida.position; // Colocamos al jugador en el punto de partida
		RigidBody2D.velocity = Vector2.zero; // Detenemos el movimiento al reaparecer
		lastDirection = Vector2.zero; // Reiniciamos la última dirección al reaparecer
	}

	// Método para actualizar los corazones visibles
	void ActualizarCorazones()
	{
		if (health >= 0 && health < corazones.Length)
		{
			corazones[health].SetActive(false); // Ocultamos el corazón correspondiente
		}
	}

	// Método para reiniciar el juego
	void ResetearJuego()
	{
		health = 3; // Reiniciamos las vidas
		for (int i = 0; i < corazones.Length; i++)
		{
			corazones[i].SetActive(true); // Reactivamos los corazones
		}
	}
}









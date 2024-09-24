using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movimiento : MonoBehaviour
{
	private Rigidbody2D RigidBody2D;
	public Text Ganaste;
	private byte speed = 5;
	float x, y;

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
		y = Input.GetAxis("Vertical");

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
				Ganaste.text = "Perdiste :(";
				canMove = false; // Deshabilitar el movimiento
				Invoke("ResetearJuego", 2f); // Reiniciar el juego después de 2 segundos
			}
		}
		else if (collision.gameObject.tag == "Meta")
		{
			Ganaste.text = "¡GANASTE!";
			canMove = false; // Deshabilitar el movimiento al ganar
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
		Ganaste.text = ""; // Limpiar el mensaje de "Perdiste"
		canMove = true; // Volver a habilitar el movimiento
		RespawnPlayer(); // Regresar al punto de inicio
	}
}








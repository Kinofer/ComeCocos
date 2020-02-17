using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
	// Start is called before the first frame update
	GameObject fantasma1, fantasma2, fantasma3, fantasma4, jugador;
	GameObject barreraInicial;
	float velocidadInicial = 50f;
	float tiempo, tiempo1;
	float numeroEnemigos;
	bool activo1;
	bool activo2;
	float velocidadFantasma;
	public GameObject delQueViene, siguiente;
	public Vector2 posicionAnterior;
	void Start()
	{
		activo1 = false;
		activo2 = false;
		tiempo1 = 5;
		numeroEnemigos = 0;
		delQueViene = GameObject.Find("ColeccionableDireccion (11)");
		velocidadFantasma = Time.deltaTime * 5;
		GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
		barreraInicial = GameObject.Find("PuertaBichos");
		fantasma1 = GameObject.Find("Fantasma1");
		fantasma2 = GameObject.Find("Fantasma2");
		jugador = GameObject.Find("Jugador");
		fantasma1.transform.position = new Vector2(0, -5);
		//fantasma1.transform.position = new Vector2(-111, 60);
		fantasma2.transform.position = new Vector2(10, 0);
	}

	// Update is called once per frame
	void Update()
	{
		
			tiempo += Time.deltaTime;
			if (tiempo >= tiempo1) {
				tiempo = 0;
				if (numeroEnemigos <= 4) {

					if (numeroEnemigos == 0) {
						Vector2 aparecer = posicionAleatoria();
					fantasma1.transform.position = aparecer;
					activo1 = true;
					} else if (numeroEnemigos == 1) {
					Vector2 aparecer = posicionAleatoria();
					fantasma2.transform.position = aparecer;
						activo2 = true;
					}
					numeroEnemigos++;
				}
			}
		if (jugador.GetComponent<Jugador>().contrario == false){
			if (activo1 == true) {
				velocidadFantasma = Time.deltaTime * 15;
				fantasma1.transform.position = Vector2.MoveTowards(fantasma1.transform.position, jugador.transform.position, velocidadFantasma);

			}
			if (activo2 == true) {
				velocidadFantasma = Time.deltaTime * 15;
				fantasma2.transform.position = Vector2.MoveTowards(fantasma2.transform.position, jugador.transform.position, velocidadFantasma);
			}
		}
		else
		{
			velocidadFantasma = Time.deltaTime * 17;
			transform.position = Vector2.MoveTowards(transform.position, siguiente.transform.position, velocidadFantasma);

		}
	} 
	
	
	void OnCollisionEnter2D(Collision2D micolision){
	
	if(micolision.gameObject.name=="Pasillo (3)"){
	
			int x = 1;

			int y = direccionY(transform.position, micolision.transform.position);

			Vector2 direccion = new Vector2(x, y);

			GetComponent<Rigidbody2D>().velocity = direccion * velocidadInicial;
	}
	if(micolision.gameObject.name=="Pasillo (2)"){

			int x = -1;

			int y = direccionY(transform.position, micolision.transform.position);

			Vector2 direccion = new Vector2(x, y);

			GetComponent<Rigidbody2D>().velocity = direccion * velocidadInicial;
	}
	if(micolision.gameObject.name=="Pasillo (25)"){

			int x = direccionX(transform.position, micolision.transform.position);

			int y = 1;

			Vector2 direccion = new Vector2(x, y);

			GetComponent<Rigidbody2D>().velocity = direccion * velocidadInicial;
	}
	if(micolision.gameObject.name=="Pasillo (5)"){

			int x = direccionX(transform.position, micolision.transform.position);

			int y = -1;

			Vector2 direccion = new Vector2(x, y);

			GetComponent<Rigidbody2D>().velocity = direccion * velocidadInicial;
	}
	if(micolision.gameObject.name=="Pasillo (6)"){

			int x = direccionX(transform.position, micolision.transform.position);

			int y = -1;

			Vector2 direccion = new Vector2(x, y);

			GetComponent<Rigidbody2D>().velocity = direccion * velocidadInicial;
	}
	if(micolision.gameObject.name=="Pasillo (27)" || micolision.gameObject.name=="Pasillo (26)" || micolision.gameObject.name=="Pasillo (40)" || micolision.gameObject.name=="Pasillo (4)" || micolision.gameObject.name=="Pasillo (40)"){

			int x = direccionX(transform.position, micolision.transform.position);

			int y = -1;

			Vector2 direccion = new Vector2(x, y);

			GetComponent<Rigidbody2D>().velocity = direccion * velocidadInicial;
	}

	}

	int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){

		if (posicionBola.y > posicionRaqueta.y){
			return 1;
		}
		else if (posicionBola.y < posicionRaqueta.y){
			return -1;
		}
		else{
			return 0;
		}
	}

	int direccionX(Vector2 posicionBola, Vector2 posicionRaqueta){

		if (posicionBola.y > posicionRaqueta.y){
			return 1;
		}
		else if (posicionBola.y < posicionRaqueta.y){
			return -1;
		}
		else{
			return 0;
		}
	}
	public Vector2 posicionAleatoria()
    {
		Vector2 posicion;
		float aleatorio2 = Random.Range(1, 11);
		if (aleatorio2 == 1)
		{
			posicion =new Vector2(-0.7f, 15.6f) ;
			activo1 = true;
			return posicion;
		}
		else if (aleatorio2 == 2)
		{
			posicion = new Vector2(-14f, 21.6f);
			activo1 = true;
			return posicion;
		}
		else if (aleatorio2 == 3)
		{
			posicion =new Vector2(79f, 1.5f);
			activo1 = true;
			return posicion;
		}
		else if (aleatorio2 == 4)
		{
			posicion =new Vector2(1f, 45.5f);
			activo1 = true;
			return posicion;
		}
		else if (aleatorio2 == 5)
		{
			posicion =new Vector2(0f, -48.5f);
			activo1 = true;
			return posicion;
		}
		else if (aleatorio2 == 6)
		{
			posicion =new Vector2(-2f, -34f);
			activo1 = true;
			return posicion;
		}
		else if (aleatorio2 == 7)
		{
			posicion =new Vector2(-38f, -2f);
			activo1 = true;
			return posicion;
		}
		else if (aleatorio2 == 8)
		{
			posicion =new Vector2(30f, 62.5f) ;
			activo1 = true;
			return posicion;
		}
		else if (aleatorio2 == 9)
		{
			posicion =new Vector2(-61f, 30.5f);
			activo1 = true;
			return posicion;
		}
		else
		{
			posicion =new Vector2(60f, -29f);
			activo1 = true;
			return posicion;
		}
	}

	

	public void reiniciar(){
		fantasma1.transform.position = new Vector2(0, -5);
		fantasma2.transform.position = new Vector2(10, 0);
		numeroEnemigos = 0;
		activo1 = false;
		activo2 = false;
		tiempo = 0;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Coleccionables"))
		{
			delQueViene.GetComponent<Coleccionable>().estaActivo = false;


			other.gameObject.GetComponent<Coleccionable>().siguiente = other.gameObject.GetComponent<Coleccionable>().coleccionableAleatorio(other.gameObject.GetComponent<Coleccionable>().izquierda, other.gameObject.GetComponent<Coleccionable>().derecha, other.gameObject.GetComponent<Coleccionable>().arriba, other.gameObject.GetComponent<Coleccionable>().abajo);
			siguiente = other.gameObject.GetComponent<Coleccionable>().siguiente;
			if (other.gameObject.GetComponent<Coleccionable>().siguiente.name == delQueViene.name)
			{
				while (other.gameObject.GetComponent<Coleccionable>().siguiente.name == delQueViene.name)
				{
					other.gameObject.GetComponent<Coleccionable>().siguiente = other.gameObject.GetComponent<Coleccionable>().coleccionableAleatorio(other.gameObject.GetComponent<Coleccionable>().izquierda, other.gameObject.GetComponent<Coleccionable>().derecha, other.gameObject.GetComponent<Coleccionable>().arriba, other.gameObject.GetComponent<Coleccionable>().abajo);

				}
			}

			//fantasma1.GetComponent<Fantasma>().delQueViene.GetComponent<Coleccionable>().transform.position = fantasma1.GetComponent<Fantasma>().posicionAnterior;
			//fantasma1.GetComponent<Fantasma>().posicionAnterior = transform.position;
			delQueViene = GameObject.Find(other.gameObject.name);


			//saberFantasma = 1;
			other.gameObject.GetComponent<Coleccionable>().estaActivo = true;
		}
	}
	}

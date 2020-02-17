using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmasInstanciados : MonoBehaviour
{
    float velocidadFantasma;
    public GameObject jugador,delQueViene,siguiente;

    // Start is called before the first frame update
    void Start()
    {
        delQueViene = GameObject.Find("ColeccionableDireccion");
        velocidadFantasma = Time.deltaTime * 5;
        jugador = GameObject.Find("Jugador");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.GetComponent<Jugador>().contrario==false) {
            velocidadFantasma = Time.deltaTime * 15;
            transform.position = Vector2.MoveTowards(transform.position, jugador.transform.position, velocidadFantasma);
        }
        else
        {
            velocidadFantasma = Time.deltaTime * 17;
            transform.position = Vector2.MoveTowards(transform.position, siguiente.transform.position, velocidadFantasma);

        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coleccionables"))
        {
            delQueViene.GetComponent<Coleccionable>().estaActivo = false;


            other.gameObject.GetComponent<Coleccionable>().siguiente = other.gameObject.GetComponent<Coleccionable>().coleccionableAleatorio(other.gameObject.GetComponent<Coleccionable>().izquierda, other.gameObject.GetComponent<Coleccionable>().derecha, other.gameObject.GetComponent<Coleccionable>().arriba, other.gameObject.GetComponent<Coleccionable>().abajo);
            siguiente = other.gameObject.GetComponent<Coleccionable>().siguiente;
            if (other.gameObject.GetComponent <Coleccionable>().siguiente.name == delQueViene.name)
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

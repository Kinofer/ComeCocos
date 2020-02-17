using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public GameObject izquierda, derecha,fantasma1,fantasma2,arriba,abajo;
    float velocidadFantasma;
    int saberFantasma;
    public GameObject siguiente,fantasma;
    public bool estaActivo;
    // Start is called before the first frame update
    void Start()
    {
        velocidadFantasma = Time.deltaTime * 5;
        saberFantasma = 0;
        estaActivo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Jugador").GetComponent<Jugador>().contrario == true  && estaActivo==true ) {
            velocidadFantasma = Time.deltaTime * 17;
            fantasma.transform.position = Vector2.MoveTowards(fantasma1.transform.position, siguiente.transform.position, velocidadFantasma);




        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("fantasmas") ) {
            /*
            fantasma = other.gameObject;
            Debug.Log(other.gameObject.name);
            
            fantasma.GetComponent<Fantasma>().delQueViene.GetComponent<Coleccionable>().estaActivo = false;
            

            siguiente = coleccionableAleatorio(izquierda, derecha, arriba, abajo);
            if (siguiente.name == fantasma.GetComponent<Fantasma>().delQueViene.name)
            {
                while (siguiente.name == fantasma.GetComponent<Fantasma>().delQueViene.name)
                {
                    siguiente = coleccionableAleatorio(izquierda, derecha, arriba, abajo);
                   
                }
            }
            Debug.Log(siguiente.name);
            
            //fantasma1.GetComponent<Fantasma>().delQueViene.GetComponent<Coleccionable>().transform.position = fantasma1.GetComponent<Fantasma>().posicionAnterior;
            //fantasma1.GetComponent<Fantasma>().posicionAnterior = transform.position;
            fantasma.GetComponent<Fantasma>().delQueViene = GameObject.Find(name);

            
            //saberFantasma = 1;
            estaActivo = true;*/
        }
        if (other.gameObject.CompareTag("fantasmasInstaciados"))
        {
            /*fantasma = other.gameObject;
            Debug.Log(other.gameObject.name);

            
            fantasma.GetComponent<FantasmasInstanciados>().delQueViene.GetComponent<Coleccionable>().estaActivo = false;


            siguiente = coleccionableAleatorio(izquierda, derecha, arriba, abajo);
            if (siguiente.name == fantasma.GetComponent<FantasmasInstanciados>().delQueViene.name)
            {
                while (siguiente.name == fantasma.GetComponent<FantasmasInstanciados>().delQueViene.name)
                {
                    siguiente = coleccionableAleatorio(izquierda, derecha, arriba, abajo);

                }
            }
            Debug.Log(siguiente.name);

            //fantasma1.GetComponent<Fantasma>().delQueViene.GetComponent<Coleccionable>().transform.position = fantasma1.GetComponent<Fantasma>().posicionAnterior;
            //fantasma1.GetComponent<Fantasma>().posicionAnterior = transform.position;
            fantasma.GetComponent<FantasmasInstanciados>().delQueViene = GameObject.Find(name);


            //saberFantasma = 1;
            estaActivo = true;*/
        }
        }
    public GameObject coleccionableAleatorio(GameObject primero, GameObject segundo,GameObject tercero,GameObject cuarto)
    {
        GameObject[] array = new GameObject[] { primero,segundo,tercero,cuarto};
        List<GameObject> bueno = new List<GameObject>();
        for (int i = 0; i < array.Length;i++)
        {
            if (array[i].name!="Vacio") {
                bueno.Add(array[i]);
            }
        }
        
        int saber = Random.Range(0, bueno.Count);
        if (saber == 0)
        {
            return bueno[0];
        }
        else if(saber == 1)
        {
            return bueno[1];
        }
        else if (saber == 2)
        {
            return bueno[2];
        }
        else 
        {
            return bueno[3];
        }
    }
}

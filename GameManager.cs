using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	float tiempo, tiempo1;
	public GameObject fantasma3, fantasma4;
	public bool activo3, activo4;
	List<GameObject> bueno = new List<GameObject>();
	// Start is called before the first frame update
	void Start()
    {
		tiempo1 = 5;
		activo3 = false;
		activo4 = false;
	}

    // Update is called once per frame
    void Update()
    {
		tiempo += Time.deltaTime;
        if(tiempo>=30){
			tiempo = 20;
			if (bueno.Count < 3)
			{
				if (activo4 == false || activo3 == false)
				{
					if (activo4 == false )
					{
						Vector2 posicionEnemigo = posicionAleatoria();
						Quaternion rotacionEnemigo = Quaternion.identity;
						bueno.Add(Instantiate(fantasma4, posicionEnemigo, rotacionEnemigo));
						activo4 = true;
					}
					if (activo3 == false)
					{
						Vector2 posicionEnemigo = posicionAleatoria();
						Quaternion rotacionEnemigo = Quaternion.identity;
						bueno.Add(Instantiate(fantasma3, posicionEnemigo, rotacionEnemigo));
						activo3 = true;
					}
				}
			}
		}
		
	}
	public Vector2 posicionAleatoria()
	{
		Vector2 posicion;
		float aleatorio2 = Random.Range(1, 11);
		if (aleatorio2 == 1)
		{
			posicion = new Vector2(-0.7f, 15.6f);
			return posicion;
		}
		else if (aleatorio2 == 2)
		{
			posicion = new Vector2(-14f, 21.6f);
			return posicion;
		}
		else if (aleatorio2 == 3)
		{
			posicion = new Vector2(79f, 1.5f);
			return posicion;
		}
		else if (aleatorio2 == 4)
		{
			posicion = new Vector2(1f, 45.5f);
			return posicion;
		}
		else if (aleatorio2 == 5)
		{
			posicion = new Vector2(0f, -48.5f);
			return posicion;
		}
		else if (aleatorio2 == 6)
		{
			posicion = new Vector2(-2f, -34f);
			return posicion;
		}
		else if (aleatorio2 == 7)
		{
			posicion = new Vector2(-38f, -2f);
			return posicion;
		}
		else if (aleatorio2 == 8)
		{
			posicion = new Vector2(30f, 62.5f);
			return posicion;
		}
		else if (aleatorio2 == 9)
		{
			posicion = new Vector2(-61f, 30.5f);
			return posicion;
		}
		else
		{
			posicion = new Vector2(60f, -29f);
			return posicion;
		}
	}

	public void reiniciar(){
		GameObject[] array = GameObject.FindGameObjectsWithTag("fantasmasInstaciados");
		for(int i = 0; i < array.Length; i++){
			Destroy(array[i]);
		}
		for (int i = 0; i < bueno.Count; i++)
		{
			bueno.Remove(bueno[i]);
		}
		activo3 = false;
		activo4 = false;
	}
}

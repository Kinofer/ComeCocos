using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noSeQuedenTontos : MonoBehaviour
{
GameObject fantasma1,jugador;
float velocidadFantasma;
    // Start is called before the first frame update
    void Start()
    {
	velocidadFantasma=15;
        fantasma1=GameObject.Find("Fantasma1");
		jugador=GameObject.Find("Jugador");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnCollisionEnter2D(Collision2D micolision){
	if(micolision.gameObject.name=="Fantasma1"){
	velocidadFantasma=Time.deltaTime*10;
	fantasma1.transform.position=Vector2.MoveTowards(fantasma1.transform.position,jugador.transform.position,velocidadFantasma);
	}
	}
}

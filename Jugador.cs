using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    
	[SerializeField]
	public float velocidad ;
	
	public string ejeVertical;

	public string ejeHorizontal;
	float tiempo=90;
	public float tiempoStart;
	public float tiempoEnd;
	public float tiempoHuida;

	GameObject laser;
	GameObject jabaObjeto, naveObjeto;
	float tiempoLaser;
	bool laserBool;
	public bool contrario;
	float tiempoContrario;
	int puntos;
	float puntuacion;
	public Text temporizador;
	private string minutos, segundos;
	public Text textoPuntos;
	int vidas;
	public Text vidasTexto;
	bool jaba;
	bool nave;
	bool reaparicionJaba;
	float tiempoReaparicionJaba;
	float tiempoReaparicionNave;
	bool reaparicionNave;
	float tiempoNave;
	float tiempoJaba;
	int fantasmasComidos;
	int numeroColeccionables;

	void Start()
    {
		contrario = false;
		laser = GameObject.Find("laser");
		jabaObjeto= GameObject.Find("jaba");
		naveObjeto= GameObject.Find("Nave");
		velocidad = 30;
		fantasmasComidos = 0;
		laserBool = true;
		reaparicionJaba=true;
		tiempoReaparicionJaba=15;
		tiempoReaparicionNave=15;
		reaparicionNave=true;
		tiempoLaser = 15;
		puntos = 0;
		jaba = false;
		nave = false;
		tiempoJaba = 5;
		tiempoNave = 5;
		tiempoContrario=5;
		vidas = 3;
		contrario = true;
		float aleatorio = Random.Range(1, 5);
		if (aleatorio == 1)
		{
			GetComponent<Rigidbody2D>().position = new Vector2(-116f, 63f);
		}
		else if (aleatorio == 2)
		{
			GetComponent<Rigidbody2D>().position = new Vector2(116f, 63f);
		}
		else if (aleatorio == 3)
		{
			GetComponent<Rigidbody2D>().position = new Vector2(-116, -63);
		}
		else
		{
			GetComponent<Rigidbody2D>().position = new Vector2(116, -63);
		}


	}

    // Update is called once per frame
    void Update()
    {
	float v = Input.GetAxisRaw(ejeVertical);
	float h = Input.GetAxisRaw(ejeHorizontal);
		//Modifico la velocidad de la raqueta
		tiempo -= Time.deltaTime;
		minutosSegundos(tiempo);


		if(Input.GetKeyDown(KeyCode.DownArrow)){
		GetComponent<Rigidbody2D>().velocity = new Vector2(h * velocidad, v * velocidad);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
		GetComponent<Rigidbody2D>().velocity = new Vector2(h * velocidad, v * velocidad);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
		GetComponent<Rigidbody2D>().velocity = new Vector2(h * velocidad, v * velocidad);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
		GetComponent<Rigidbody2D>().velocity = new Vector2(h * velocidad, v * velocidad);
		}


        if (jaba == true)
        {
			tiempoJaba -= Time.deltaTime;
			velocidad = 15;
            if (tiempoJaba <= 0)
            {
				velocidad = 30;
				jaba = false;
				tiempoJaba=5;
            }
            
        }
		if (nave == true)
		{
			tiempoNave -= Time.deltaTime;
			velocidad = 45;
			if (tiempoNave <= 0)
			{
				velocidad = 30;
				nave = false;
				tiempoNave = 5;
			}

		}
        if (contrario == true)
        {
			tiempoContrario -= Time.deltaTime;
			velocidad = 40;
			if (tiempoContrario <= 0)
			{
				velocidad = 30;
				contrario = false;
				tiempoContrario = 5;
			}
		}
		if (laserBool == false)
		{
			tiempoLaser -= Time.deltaTime;
			if (tiempoLaser <= 0)
			{
				laser.transform.position = GameObject.Find("Fantasma1").GetComponent<Fantasma>().posicionAleatoria();
				while (naveObjeto.transform.position == jabaObjeto.transform.position || naveObjeto.transform.position == laser.transform.position || laser.transform.position == jabaObjeto.transform.position)
				{
					naveObjeto.transform.position = GameObject.Find("Fantasma1").GetComponent<Fantasma>().posicionAleatoria();
					if (naveObjeto.transform.position == jabaObjeto.transform.position && naveObjeto.transform.position == laser.transform.position && laser.transform.position == jabaObjeto.transform.position)

					{
						break;
					}
				}
				laser.SetActive(true);
				tiempoLaser = 15;
				laserBool = true;
			}
		}
		if (reaparicionJaba == false)
		{
			tiempoReaparicionJaba -= Time.deltaTime;
			if (tiempoReaparicionJaba <= 0)
			{
				jabaObjeto.transform.position = GameObject.Find("Fantasma1").GetComponent<Fantasma>().posicionAleatoria();
				while (naveObjeto.transform.position == jabaObjeto.transform.position || naveObjeto.transform.position == laser.transform.position || laser.transform.position == jabaObjeto.transform.position)
				{
					naveObjeto.transform.position = GameObject.Find("Fantasma1").GetComponent<Fantasma>().posicionAleatoria();
					if (naveObjeto.transform.position == jabaObjeto.transform.position && naveObjeto.transform.position == laser.transform.position && laser.transform.position == jabaObjeto.transform.position)

					{
						break;
					}
				}
				jabaObjeto.SetActive(true);
				tiempoReaparicionJaba = 15;
				reaparicionJaba = true;
			}
		}
		if (reaparicionNave == false)
		{
			tiempoReaparicionNave -= Time.deltaTime;
			if (tiempoReaparicionNave <= 0)
			{
				naveObjeto.transform.position = GameObject.Find("Fantasma1").GetComponent<Fantasma>().posicionAleatoria();
				while(naveObjeto.transform.position==jabaObjeto.transform.position || naveObjeto.transform.position == laser.transform.position || laser.transform.position == jabaObjeto.transform.position)
                {
					naveObjeto.transform.position = GameObject.Find("Fantasma1").GetComponent<Fantasma>().posicionAleatoria();
                    if (naveObjeto.transform.position == jabaObjeto.transform.position && naveObjeto.transform.position == laser.transform.position && laser.transform.position == jabaObjeto.transform.position)
               
                    {
						break;
                    }
				}
				naveObjeto.SetActive(true);
				tiempoReaparicionNave = 15;
				reaparicionNave = true;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D micolision){

		if (micolision.gameObject.name == "EntradaIzquierda" ){
		
		float aleatorio=Random.Range(1,4);

		 if(aleatorio==1){
		GetComponent<Rigidbody2D>().position=new Vector2(119f,0.3f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0f);
		}else if(aleatorio==2){
		GetComponent<Rigidbody2D>().position=new Vector2(0f,63.72f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -30f);
		}else {
		GetComponent<Rigidbody2D>().position=new Vector2(0f,-63.72f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30f);
		}
		}
		if( micolision.gameObject.name == "EntradaDerecha"){

		float aleatorio=Random.Range(1,4);

		if(aleatorio==1){
		GetComponent<Rigidbody2D>().position=new Vector2(-119f,0.3f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0f);
		}else if(aleatorio==2){
		GetComponent<Rigidbody2D>().position=new Vector2(0f,63.72f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -30f);
		}else {
		GetComponent<Rigidbody2D>().position=new Vector2(0f,-63.72f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30f);
		}
			
		}
		if(micolision.gameObject.name == "EntradaArriba"){

		float aleatorio=Random.Range(1,4);

		if(aleatorio==1){
		GetComponent<Rigidbody2D>().position=new Vector2(-119f,0.3f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0f);
		}else if(aleatorio==2){
		GetComponent<Rigidbody2D>().position=new Vector2(119f,0.3f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0f);
		}else {
		GetComponent<Rigidbody2D>().position=new Vector2(0f,-63.72f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, 30f);
		}
		}
		if(micolision.gameObject.name == "EntradaAbajo"){

		float aleatorio=Random.Range(1,4);

		if(aleatorio==1){
		GetComponent<Rigidbody2D>().position=new Vector2(-119f,0.3f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0f);
		}else if(aleatorio==2){
		GetComponent<Rigidbody2D>().position=new Vector2(119f,0.3f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0f);
		}else {
		GetComponent<Rigidbody2D>().position=new Vector2(0f,63.72f);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -30f);
		}
		}
		
        if (micolision.gameObject.CompareTag("fantasmas") || micolision.gameObject.CompareTag("fantasmasInstaciados"))
		{
            if (contrario == false)
            {
				if (comprobarFinal() == false)
				{

				}
				else
				{
					reiniciar();
					GameObject.Find("Fantasma1").GetComponent<Fantasma>().reiniciar();
					GameObject.Find("GameManager").GetComponent<GameManager>().reiniciar();
				}
            }
            else
            {
                if (micolision.gameObject.CompareTag("fantasmas"))
                {
					micolision.gameObject.transform.position = new Vector2(0, -5);
					fantasmasComidos++;
					puntuacion += 150;
					textoPuntos.text = "Puntos: " + puntuacion.ToString();
				}
                else
                {
					Destroy(micolision.gameObject);
					fantasmasComidos++;
					puntuacion += 150;
					textoPuntos.text = "Puntos: " + puntuacion.ToString();
				}

			}
            
		
		}
		
		}

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cocos"))
        {
			other.gameObject.SetActive(false);
			puntos++;
			numeroColeccionables++;
			contarPuntos();
		}
        if (other.gameObject.name=="laser") {
			laserBool = false;
			contrario = true;
			other.gameObject.SetActive(false);
			GameObject[] array = GameObject.FindGameObjectsWithTag("fantasmasInstaciados");
			GameObject[] array2 = GameObject.FindGameObjectsWithTag("fantasmas");
			/*for (int i = 0; i < array.Length; i++)
			{
				array[i].GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
			}
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].GetComponent<Rigidbody2D>().velocity = Vector2.right * 10;
			}*/

		}
        if (other.gameObject.name == "jaba") 
        {
			jabaObjeto.SetActive(false);
			reaparicionJaba = false;
			jaba = true;
        }
		if (other.gameObject.name == "Nave")
		{
			reaparicionNave = false;
			naveObjeto.SetActive(false);
			nave = true;
		}
	}
	void minutosSegundos(float tiempo)
	{

		//Minutos
		if (tiempo > 120)
		{
			minutos = "02";
		}
		else if (tiempo >= 60)
		{
			minutos = "01";
		}
		else
		{
			minutos = "00";
		}

		//Segundos
		int numSegundos = Mathf.RoundToInt(tiempo % 60);
		if (numSegundos > 9)
		{
			segundos = numSegundos.ToString();
		}
		else
		{
			segundos = "0" + numSegundos.ToString();
		}

		//Escribo en la caja de texto
		temporizador.text = minutos + ":" + segundos;

	}
	void contarPuntos(){
		puntuacion = puntuacion +  50;
		//string enPantalla = ;
		textoPuntos.text = "Puntos: " + puntuacion.ToString();

    }
	bool comprobarFinal(){
		if (vidas == 0)
		{
			return false;
		}
		else
		{
			return true;
		}
    }
	void reiniciar(){
		float aleatorio = Random.Range(1, 5);
		if (aleatorio == 1)
		{
			GetComponent<Rigidbody2D>().position = new Vector2(-116f, 63f);
		}
		else if (aleatorio == 2)
		{
			GetComponent<Rigidbody2D>().position = new Vector2(116f, 63f);
		}
		else if (aleatorio == 3)
		{
			GetComponent<Rigidbody2D>().position = new Vector2(-116, -63);
		}
		else
		{
			GetComponent<Rigidbody2D>().position = new Vector2(116, -63);
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		vidas--;
		vidasTexto.text = "Vidas: " + vidas;
	}
}

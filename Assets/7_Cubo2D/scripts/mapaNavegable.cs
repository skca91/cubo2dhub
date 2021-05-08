using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(contenedorObjetosConTag))]

public class mapaNavegable : MonoBehaviour {

	contenedorObjetosConTag contenedorTodosLosDesafios;
	public List<simpleTag> todosLosDesafios;
	LineRenderer ruta;
	public GameObject personajePrincipal;
	movimiento2DCubo2d personajeMovimiento;
	int posicionActual = 0;

	void Awake(){
		ruta = GetComponentInChildren<LineRenderer> ();
		contenedorTodosLosDesafios =GetComponent<contenedorObjetosConTag> ();
		todosLosDesafios = new List<simpleTag> ();
		personajeMovimiento = personajePrincipal.GetComponent<movimiento2DCubo2d> ();
	}

	// Use this for initialization
	void Start () {

		//personajePrincipal.transform.position = 
		actualizarMapa ();

	}

	public void actualizarMapa(){

		int cont = 0;
		todosLosDesafios.Clear ();
		foreach(simpleTag go in contenedorTodosLosDesafios.GetComponentsInChildren<simpleTag> ()){
			simpleClick2D sc = go.gameObject.GetComponent<simpleClick2D> ();
			if (go.tagScript.Equals("puntoRuta")&&sc != null) {
				sc.usarID = true;
				sc.id = cont+"";
				sc.metedo = "clickEnPuntoDeRuta";
				cont++;
				todosLosDesafios.Add (go);
			}
		}
		//calcular linea
		ruta.positionCount = todosLosDesafios.Count;
		for(int i = 0; i < ruta.positionCount; i++ ){
			ruta.SetPosition (i,todosLosDesafios[i].transform.position);
		}

		personajeMovimiento.transform.position = todosLosDesafios [posicionActual].transform.position;

	}

	/**Se recomienda implementarlo en el padre o hermeno con las reglas del juego*/
	public void clickEnPuntoDeRuta(string _id){
		// el padre hace algo
	}

	public void moverPuntoRuta(string _nuevoId){

		//Debug.Log ("trato de mover" + _nuevoId);

		int nuevoId = int.Parse (_nuevoId);

		/*if (nuevoId - posicionActual< 1 || posicionActual - nuevoId < 1) {
			return;
		}*/
			//avanzar
		if (posicionActual < nuevoId) {
			personajeMovimiento.mover2D (todosLosDesafios[posicionActual].transform.position,todosLosDesafios[nuevoId].transform.position,1);
			//retroceder
			posicionActual++;
		}else if(posicionActual > nuevoId){
			personajeMovimiento.mover2D (todosLosDesafios[nuevoId].transform.position,todosLosDesafios[posicionActual].transform.position,1);
			//esperar
			posicionActual--;
		}else{
			movimientoCompleto ();
		}
	}

	public void movimientoCompleto(){
		SendMessageUpwards ("movimientoMapaCompleto");
	}


	public void fijarPosicionActual(int _posActual){
		posicionActual = _posActual;
		actualizarMapa ();
		//personajeMovimiento.transform.position = todosLosDesafios [posicionActual].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

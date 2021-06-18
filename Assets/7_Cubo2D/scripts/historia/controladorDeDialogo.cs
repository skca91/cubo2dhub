using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class controladorDeDialogo : MonoBehaviour {

	public listaTextoXML listaTexto;
	public historiaXML historia;
	public nodoXML nodoXMLAcual;
	string nodoAcutal = "1";
	int TextoActual;
	public controladorImagenPersonaje personaje;
	public botonOpcionDialogo[] opcion;

	public bool buscarJuegoAutomatico;
	public GameObject juego;

	public bool dialogoVisible = false;
	public Text dialogo;
    public string NombreJugador = "Player";
	// Use this for initialization
	void Start () {
		TextoActual = 0;
		personaje = GetComponentInChildren<controladorImagenPersonaje> ();
		opcion = GetComponentsInChildren<botonOpcionDialogo> ();
		cargarDialogo ();

		buscarJuego ();
		ocultarDialogo ();

		//Debug.Log ("Nodo Perfil" + nodoAcutal);
		//actualizarDialogo ();
	}

	public void buscarJuego(){
		if(buscarJuegoAutomatico){
			juego = GameObject.FindWithTag ("Juego");
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void cargarDialogo(){

		if (historia.listaDeNodos.Count < 1) {
			Debug.Log ("No hay nodos");
		}

		TextoActual = -1;
		foreach(nodoXML nodo in historia.listaDeNodos){
			//Debug.Log ("nodo id "+ nodo.id);
			if(nodo.id.Equals(nodoAcutal)){
				nodoXMLAcual = nodo;
				break;
			}
		}

		foreach(botonOpcionDialogo b in opcion){
			b.desActivar ();
		}

		proximoTexto ();
	}

	public void mostrarDialogo(){
		dialogoVisible = true;
	//	nodoAcutal = variablesGlobales4x4.jugador.nodoHistoriaActual;
		BroadcastMessage ("showMenu");
		cargarDialogo ();
	}

	public void ocultarDialogo(){
		dialogoVisible = false;
		BroadcastMessage ("hideMenu");
	}

	public void actualizarDialogo(){
		int conTexto = 0;

		foreach(TextoXML t in nodoXMLAcual.textos){
			//Debug.Log ("texto dialogo: "+ t.dialogo);
			if(conTexto == TextoActual){
                //idiomaV2.textoTraducido (t.dialogo);
                string NombrePersonaje = t.personaje.Equals("nombrejugador") ? NombrePersonaje = "<color=#0010FF>" + NombreJugador + ":</color> " : "<color=#FFFF00>" + idiomaV2.textoTraducido(t.personaje).ToUpper()+ ":</color> ";

                dialogo.text = NombrePersonaje + idiomaV2.textoTraducido( t.dialogo);
				personaje.cargarPersonaje (t.personaje,t.expresion);
				//BroadcastMessage ("actualizarTexto");
				//Debug.Log ("Hola ?? ");
				break;
			}
			conTexto++;

		}
	}

	public void ejecutarAccion(string accion){
		if (accion.Equals ("") || accion.Equals ("nada")) {
			return;
		}
		//Debug.Log ("Accion : " + accion);
		juego.SendMessage (accion);
	}

	public string getNodoActual(){
		return nodoAcutal;
	}

	public void proximoTexto(){

		if (nodoXMLAcual == null) {
			Debug.Log ("Nodo Actual nulo");
			return;
		}
		//TextoActual++;
		if (TextoActual < nodoXMLAcual.textos.Count) {
			TextoActual++;
		}

		if((TextoActual + 1) == nodoXMLAcual.textos.Count){
			
			if (nodoXMLAcual.opciones.Count < 2) {
				opcionXML opc = nodoXMLAcual.opciones[0];

				//variablesGlobales4x4.textoOpcion1 = opc.textoOpcion;
				opcion [0].activar ();
				opcion [0].nodo = opc.nodo;
				opcion [0].accion = opc.accion;
				opcion [0].setText (opc.textoOpcion);
			} else {

				opcionXML opc = nodoXMLAcual.opciones[0];
				//variablesGlobales4x4.textoOpcion1 = opc.textoOpcion;
				opcion [0].activar ();
				opcion [0].nodo = opc.nodo;
				opcion [0].accion = opc.accion;
				opcion [0].setText (opc.textoOpcion);

				opc = nodoXMLAcual.opciones[1];
				//variablesGlobales4x4.textoOpcion2 = opc.textoOpcion;

				opcion [1].activar ();
				opcion [1].nodo = opc.nodo;
				opcion [1].accion = opc.accion;
				opcion [1].setText (opc.textoOpcion);
			}
		}else{
			opcion [0].activar ();
			opcion [0].nodo = nodoAcutal;
			opcion [0].accion = "";
			opcion [0].setText ("siguiente");
			//variablesGlobales4x4.textoOpcion1 = "Siguiente" /*Idioma.siguiente*/;
		}

		actualizarDialogo ();
	}

	public void textoAnterior(){
		//TextoActual--;
		if (TextoActual > 0) {
			TextoActual--;
		}
		actualizarDialogo ();
	}

	public void nuevoNodo(string nuevoNodo){
		if (nuevoNodo.Equals (nodoAcutal)) {
			proximoTexto ();
		} else {
			nodoAcutal = nuevoNodo;
			Debug.Log ("nuevo nodo es valido: " +nuevoNodo );
			/*Este metodo se debe implementar en el juego*/
			juego.SendMessage("actualizarNodoDeHistoria");
			if (dialogoVisible) {
				cargarDialogo ();
			}

		}
	}

}
